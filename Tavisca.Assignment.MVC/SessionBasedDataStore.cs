using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tavisca.Assignment.MVC.Store;

namespace Tavisca.Assignment.MVC
{
    public class SessionBasedDataStore : ITodoStore
    {
        private static List<TaskItem> Items
        {
            get
            {
                var tasks = HttpContext.Current.Session["Todos"] as List<TaskItem>;
                return tasks ?? new List<TaskItem>();
            }
            set
            {
                HttpContext.Current.Session.Add("Todos",value);
            }
        }

        public TaskItem Add(TaskItem taskItem)
        {
            if (taskItem == null) throw new Exception("Failed To Create Task");

            var tds = Items;
            taskItem.Id = tds.Count;
            tds.Add(taskItem);
            Items = tds;
            return GetTask(taskItem.Id);
        }

        public bool Delete(long id, bool isSoftDelete = false)
        {
            if (isSoftDelete)
            {
                Archive(id);
                return true;
            }
            var tds = Items;
            tds.RemoveAll(item => item.Id == id);
            Items = tds;
            
            return true;

        }

        public TaskItem Update(TaskItem taskItem)
        {
            Delete(taskItem.Id);
            Add(taskItem);
            return GetTask(taskItem.Id);
        }

        public TaskItem GetTask(long id)
        {
            return Items.FirstOrDefault(item => item.Id == id);
        }


        public TaskItem Archive(long id)
        {
            var task = GetTask(id);
            task.IsArchived = true;
            return Update(task);
        }


        public List<TaskItem> GetAllTask()
        {
            return Items.Where(item=>item.IsArchived==false).ToList();
        }
    }
}