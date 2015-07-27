using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tavisca.Assignment.MVC.Store;

namespace Tavisca.Assignment.MVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Seed()
        {
             
            TaskItems.ForEach(td => TodoStore.Add(td));
            return Index();
        }

        public ITodoStore TodoStore = MvcApplication.TodoStore;
        // GET: Home
        public ActionResult Index()
        {
           
            return View(TodoStore.GetAllTask());
        }
        
        public ActionResult Delete()
        {
            TodoStore.Delete(1, false);
            return Index();
        }

         public List<TaskItem> TaskItems = new List<TaskItem>()
                {
                    new TaskItem()
                    {
                        CreatedDate = DateTime.Now,
                        Description = "Create a Default Store",
                        Id = 1,
                        IsArchived = false,
                        LastUpdated = DateTime.Now,
                        MailTo = new List<string>(){"asrivastava@tavisca.com","tmaini@tavisca.com"},
                        Priority =  Priority.Highest,
                        Tags = new List<string>(){"C#","MVC"},
                        Title = "Implement Default Store"
                    },
                    new TaskItem()
                    {
                        CreatedDate = DateTime.Now,
                        Description = "Write Test Cases for DefaultStore",
                        Id = 2,
                        IsArchived = false,
                        LastUpdated = DateTime.Now,
                        MailTo = new List<string>(){"asrivastava@tavisca.com","tmaini@tavisca.com"},
                        Priority =  Priority.High,
                        Tags = new List<string>(){"C#","MVC"},
                        Title = "Do test that defaultStore works "
                    },
                    new TaskItem()
                    {
                        CreatedDate = DateTime.Now,
                        Description = "Deploy the artifacts",
                        Id = 3,
                        IsArchived = false,
                        LastUpdated = DateTime.Now,
                        MailTo = new List<string>(){"asrivastava@tavisca.com","tmaini@tavisca.com"},
                        Priority =  Priority.Low,
                        Tags = new List<string>(){"C#","MVC"},
                        Title = "Package it into dll."
                    },

                };
    }
    
}