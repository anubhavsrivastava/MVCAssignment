using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tavisca.Assignment.MVC.Store.Test
{
    [TestClass]
    public class TodoStoreTest
    {

        public ITodoStore TodoStore = new DefaultInMemoryTodoStore();


        [TestInitialize]
        public void SEED()
        {
            TaskItems.ForEach(taskItem => TodoStore.Add(taskItem));
        }

        [TestMethod]
        [TestCategory("CRUD")]
        public void Create()
        {
            TodoStore.GetAllTask().ToList().ForEach(t=>TodoStore.Delete(t.Id,false));
            Assert.IsTrue(TodoStore.GetAllTask().Count==0);
            TodoStore.Add(TaskItems.First());
            Assert.IsTrue(TodoStore.GetAllTask().Count ==1);
        }


        [TestMethod]
        [TestCategory("CRUD")]
        public List<TaskItem> GetAll()
        {
            var tasks = TodoStore.GetAllTask();
            Assert.IsNotNull(tasks);
            Assert.IsTrue(tasks.Count > 0);
            return tasks;
        }

        [TestMethod]
        [TestCategory("CRUD")]
        public void GetParticular()
        {
            var tasks = GetAll();
            var taskToGet = tasks.First();
            var task = TodoStore.GetTask(taskToGet.Id);
            Assert.IsNotNull(task);
            Assert.IsTrue(taskToGet.Id==task.Id);
            Assert.IsTrue(String.Equals(taskToGet.Description,task.Description));
            Assert.IsTrue(String.Equals(taskToGet.Title, task.Title));
        }

        [TestMethod]
        [TestCategory("CRUD")]
        public void Update()
        {
            var tasks = GetAll();
            var id = tasks.First().Id;
            tasks.First().Priority = Priority.Medium;
            TodoStore.Update(tasks.First());
            var task = TodoStore.GetTask(id);
            Assert.IsNotNull(task);
        }

        [TestMethod]
        [TestCategory("CRUD")]
        public void Delete()
        {
            var tasks = GetAll();
            var id = tasks.First().Id;
            TodoStore.Delete(id, false);
            var task = TodoStore.GetTask(id);
            Assert.IsNull(task);
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
                        MailTo = "asrivastava@tavisca.com",
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
                        MailTo = "asrivastava@tavisca.com",
                        Priority =  Priority.Low,
                        Tags = new List<string>(){"C#","MVC"},
                        Title = "Package it into dll."
                    },

                };
    }






}
