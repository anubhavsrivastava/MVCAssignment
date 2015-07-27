using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Assignment.MVC.Store
{
    public class TaskItem
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> MailTo { get; set; }

        public Priority Priority { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }

        public bool IsArchived { get; set; }

        public List<string> Tags { get; set; }


    }
}
