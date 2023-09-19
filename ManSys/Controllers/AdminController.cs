using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ManSys.Data;
using ManSys.Models;
using ManSys.ViewModels.Admin;
using ManSys.Data.StatusScripts;
using Microsoft.EntityFrameworkCore;

namespace ManSys.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ManSysIdentityContext context;
        private readonly RoleManager<Role> roleManager;
        private readonly ManSysRequestContext reqContext;
        public AdminController(ManSysIdentityContext context, RoleManager<Role> roleManager, ManSysRequestContext reqContext)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.reqContext = reqContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ManageStatuses()
        {
            StatusViewModel model = new StatusViewModel();
            model.Statuses = reqContext.statuses.OrderByDescending(x => (int)x.GlobalStatus).Reverse().ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStatus(StatusViewModel model)
        {
            StatusManager statusManager = new StatusManager(reqContext);
            await statusManager.CreateAsync(model.Input);

            return RedirectToAction("ManageStatuses", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteStatus(int id)
        {
            StatusManager statusManager = new StatusManager(reqContext);
            var StatusForDeleting = reqContext.statuses.Where(x=> x.Id == id).FirstOrDefault();
            statusManager.Delete(StatusForDeleting);

            return RedirectToAction("ManageStatuses", "Admin");
        }

        [HttpPost]
        public ActionResult SaveStatusChanges(StatusViewModel model)
        {
            if (model != null && model.Statuses.Count > 0)
            {
                reqContext.statuses.UpdateRange(model.Statuses);
                reqContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult ManageRoles() 
        {
            RolesViewModel model = new RolesViewModel();
            model.Roles = context.Roles.ToList();
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> DeleteRole(RolesViewModel model) 
        {
            if(model == null)
                return BadRequest();
            var RoleForDeleting = context.Roles.Where(x => x.Name == model.input.Role.Name).FirstOrDefault();
            if (RoleForDeleting != null)
                await roleManager.DeleteAsync(RoleForDeleting);

            return RedirectToAction("ManageRoles", "Admin");
        }


        [HttpPost]
        public async Task<ActionResult> CreateRole(RolesViewModel model) 
        {
            Role role = new Role();
            role.Name = model.input.Role.Name;
            role.NormalizedName = role.Name?.ToUpper();

            await roleManager.CreateAsync(role);

            return RedirectToAction("ManageRoles", "Admin");
        }



        [HttpPost]
        public ActionResult EditPermissions(RolesViewModel RoleViewModel)
        {
            RolePermissions model = new RolePermissions();
            model.role = context.Roles.ToList().Where(x => x.Name == RoleViewModel.input.Role.Name).First();
            return View(model);
        }

        [HttpPost]
        public ActionResult SavePermissions(RolePermissions model)
        {
            model.role = context.Roles.ToList().Where(x=>x.Name == model.role.Name).First();

            int requestPermissionsTotal = 0;
            foreach (var value in model.requestPermissions)
            {
                if(int.TryParse(value, out var result))
                {
                    requestPermissionsTotal += result;
                }
                else
                {
                    Console.Error.WriteLine(value + "wrong value on saving request permissions");
                }
            }

            if((int)model.role.requestPermissions != requestPermissionsTotal)
            {
                model.role.requestPermissions = (RequestPermissions)requestPermissionsTotal;
                context.Roles.Update(model.role);
                context.SaveChanges();
            }

            return RedirectToAction(nameof(ManageRoles));
        }
    }
}
