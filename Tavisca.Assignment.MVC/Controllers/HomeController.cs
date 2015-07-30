using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Tavisca.Assignment.MVC.Extension;
using Tavisca.Assignment.MVC.Store;

namespace Tavisca.Assignment.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ITodoStore TodoStore = MvcApplication.TodoStore;


        public ActionResult Seed()
        {
            TaskItems.ForEach(td => TodoStore.Add(td));
            return RedirectToAction("Index");
        }


        public ActionResult Index()
        {
            return View(TodoStore.GetAllTask());
        }

        public ActionResult Edit(long id)
        {
            var item = TodoStore.GetTask(id);
            if (item == null)
                return RedirectToAction("Index");
            if (Request.IsAjaxRequest() == true)
            {
                return new JsonResult() { Data = this.RenderRazorViewToString("Edit", TodoStore.GetTask(id)),JsonRequestBehavior=JsonRequestBehavior.AllowGet };
            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(long id)
        {
            TodoStore.Delete(id, false);
            return RedirectToAction("Index");
        }

        public ActionResult Archive(long id)
        {
            TodoStore.Delete(id, true);
            RedirectToAction("index");
            return null;
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult Add(TaskItem item)
        {
            var task = new TaskItem()
            {
                CreatedDate = DateTime.Now,
                Priority = item.Priority,
                Description = item.Description,
                MailTo = item.MailTo,
                Title = item.Title


            };

            TodoStore.Add(task);
            return RedirectToAction("index");

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Update(TaskItem item, long id)
        {
            var task = TodoStore.GetTask(id);

            if (item == null)
                return RedirectToAction("Index");

            task.LastUpdated = DateTime.Now;
            task.Title = item.Title;
            task.Description = item.Description;
            task.Priority = item.Priority;
            task.MailTo = item.MailTo;

            TodoStore.Update(task);
            return RedirectToAction("index");

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
                        MailTo = "asrivastava@tavisca.com",
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
                        MailTo = "tmaini@tavisca.com",
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
                        MailTo = "tmaini@tavisca.com",
                        Priority =  Priority.Low,
                        Tags = new List<string>(){"C#","MVC"},
                        Title = "Package it into dll."
                    },

                };
    }

}