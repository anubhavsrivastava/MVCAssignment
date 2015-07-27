using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Assignment.MVC.Store
{
    public interface ITodoStore
    {
        TaskItem Add(TaskItem taskItem);

        bool Delete(long id,bool isSoftDelete);

        TaskItem Archive(long id);

        TaskItem Update(TaskItem taskItem);

        TaskItem GetTask(long id);

        List<TaskItem> GetAllTask();

    }
}
