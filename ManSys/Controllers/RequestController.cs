using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;
using ManSys.Data;
using ManSys.Data.CommentScripts;
using ManSys.Data.DraftScripts;
using ManSys.Data.ItemScripts;
using ManSys.Data.RequestScripts;
using ManSys.Models;
using ManSys.Models.Requests;
using ManSys.ViewModels;
using ManSys.ViewModels.Request;

namespace ManSys.Controllers
{
    public class RequestController : Controller
    {
        private readonly ManSysRequestContext _requestDb;
        private readonly RequestManager? _requestManager;
        private readonly ItemManager? _itemManager;
        private readonly CommentManager? _commentManager;
        private readonly DraftManager? _draftManager;
        private readonly UserManager<User> _userManager;

        public RequestController(UserManager<User> userManager, ManSysRequestContext requestDb)
        {
            _userManager = userManager;
            _requestDb = requestDb;
            _requestManager = new RequestManager(requestDb);
            _itemManager = new ItemManager(requestDb);
            _commentManager = new CommentManager(requestDb);
            //_draftManager = new DraftManager(requestDb);
        }

        [HttpGet]
        public ActionResult Index()
        {
            RequestViewModel model = new RequestViewModel();

            model.requestsForView = _requestDb.request.Include(x=> x.Creator)
                                                        .Include(x=> x.GeneralStatus)
                                                        .Include(x=> x.Items).ToList();

            return View(model);
        }




        [HttpGet]
        public ActionResult CreateRequestGet(CreateRequestViewModel model)
       {
            if(model.Items == null)
            {
                model.Items = new List<Item>();
                model.Items.Add(new Item());
            }

            return View("CreateRequest", model);
        }


        [HttpPost]
        public async Task<ActionResult> CreateRequestPost(CreateRequestViewModel model) 
        {
            if (model == null)
                throw new ArgumentNullException();

            if(model.Items == null)
                throw new ArgumentNullException(nameof(model.Items));

            if(model.Items.Count == 0)
                return RedirectToAction("CreateRequest", "Request");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.Where(user => user.Id ==  userId).FirstOrDefault();
            

            Request request = new Request(user.Id);
            request.Items = model.Items;
            foreach(Item item in request.Items) 
            {
                item.Request = request;
                item.Status = _requestDb.statuses.Where(x=>x.IsDefaultOnCreateItem == true).FirstOrDefault();
            }

             await _requestManager.CreateAsync(request);

            return RedirectToAction("CreateRequestGet", "Request");
        }


        [HttpGet]
        public ActionResult EditRequest(int id)
        {

            Request request = _requestDb.request.Where(x => x.Id == id).First();
            request.Items = _requestDb.items.Where(x => x.RequestId == id).ToList();
            request.Comments = _requestDb.comments.Where(x => x.RequestId == id).ToList();

            request.CodeName ??= "";

            var model = new EditRequestViewModel();
            model.request = request;

            if (request.DeliveryDateStart != null && request.DeliveryDateEnd != null)
                model.DeliveryDateRange = $"{request.DeliveryDateStart.Value.Day}/{request.DeliveryDateStart.Value.Month}/{request.DeliveryDateStart.Value.Year} - {request.DeliveryDateEnd.Value.Day}/{request.DeliveryDateEnd.Value.Month}/{request.DeliveryDateEnd.Value.Year}";

            if (request.Items != null)
            {

                foreach (var item in request.Items)
                {
                    item.Status ??= new Status();
                    item.Status.Name ??= "";
                }
            }
            model.statuses = _requestDb.statuses.ToList();
            model.users = _userManager.Users.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveEditRequest(EditRequestViewModel model)
        {
            
            var dates = model.DeliveryDateRange.Split(" - ");
            
            var startDate = dates[0].Split('/');
            var endDate = dates[1].Split('/');

            var request = _requestDb.request.Where(x => x.Id == model.request.Id).FirstOrDefault();

            request.DeliveryDateStart = new DateTime(int.Parse(startDate[2]), int.Parse(startDate[1]), int.Parse(startDate[0])).ToUniversalTime();
            request.DeliveryDateEnd = new DateTime(int.Parse(endDate[2]), int.Parse(endDate[1]), int.Parse(endDate[0])).ToUniversalTime();

            
            _requestDb.request.Update(request);
            _requestDb.SaveChanges();
            
            

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AddItem(CreateRequestViewModel model)
        {
            model.Items.Add(new Item());

            return CreateRequestGet(model);
        }
    } 
}
