using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Assignment.MVC.Store
{
    public class DefaultInMemoryTodoStore : ITodoStore
    {

        public DefaultInMemoryTodoStore()
        {
            Items =new List<TaskItem>();
        }
        private static List<TaskItem> Items { get; set; }

        public TaskItem Add(TaskItem taskItem)
        {
            if (taskItem == null) throw new Exception("Failed To Create Task");
            taskItem.Id = Items.Count;
            Items.Add(taskItem);
            return GetTask(taskItem.Id);
        }

        public bool Delete(long id, bool isSoftDelete = false)
        {
            if (isSoftDelete)
            {
                Archive(id);
                return true;
            }

            Items.RemoveAll(item=>item.Id==id);
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
           return Items;
        }
    }
}
