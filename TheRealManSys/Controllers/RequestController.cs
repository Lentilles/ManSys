using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TheRealManSys.Data;
using TheRealManSys.Data.CommentScripts;
using TheRealManSys.Data.DraftScripts;
using TheRealManSys.Data.ItemScripts;
using TheRealManSys.Data.RequestScripts;
using TheRealManSys.Models;
using TheRealManSys.Models.Requests;
using TheRealManSys.ViewModels;
using TheRealManSys.ViewModels.Request;

namespace TheRealManSys.Controllers
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
            _draftManager = new DraftManager(requestDb);
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
        public ActionResult EditRequest(int id) 
        {
            Request request = _requestDb.request
                .Include(x => x.Creator)
                .Include(x => x.GeneralStatus)
                .Include(x => x.Delivery)
                .Where(x=>x.Id == id).FirstOrDefault();

            request.Items = _requestDb.items
                .Include(i => i.VendorContacts)
                .Include(i => i.Status)
                .Where(Item => Item.RequestId == request.Id).ToList();

            request.Comments = _requestDb.comments
                .Include(comment => comment.Creator)
                .Include(comment => comment.Reply)
                .Where(Comment => Comment.RequestId == request.Id).ToList();

            request.CodeName??= "";

            var model = new EditRequestViewModel();
            model.request = request;

            foreach(var item in request.Items)
            {
                item.Status??= new Status();
                item.Status.Name??= "";
            }
            model.statuses = _requestDb.statuses.ToList();
            model.users = _userManager.Users.ToList();

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
            //var user = _userManager.Users.First(x => x.Id == userId);

            Request request = new Request(userId);
            request.Items = model.Items;
            foreach(Item item in request.Items) 
            {
                item.Request = request;
                item.Status = _requestDb.statuses.Where(x=>x.IsDefaultOnCreateItem == true).FirstOrDefault();
            }

             _requestManager.CreateAsync(request);
             _itemManager.CreateRangeAsync(request.Items);

            return RedirectToAction("CreateRequestGet", "Request");
        }

        //TODO Some errors at adding new items request is null
        //but it doesnt

        public ActionResult SaveEditRequest(EditRequestViewModel model)
        {
            _requestDb.request.Update(model.request);
            _requestDb.SaveChanges();

            return RedirectToAction("index");
        }


        [HttpPost]
        public ActionResult AddItem(CreateRequestViewModel model)
        {
            model.Items.Add(new Item());

            return CreateRequestGet(model);
        }
    } 
}
