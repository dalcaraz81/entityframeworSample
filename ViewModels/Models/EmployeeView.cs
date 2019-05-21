using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class EmployeeView : ViewModel
    {
        public EmployeeView() {
            this.CreatedOn = DateTime.Now;
            this.UpdatedOn = DateTime.Now;
            this.DeletedOn = DateTime.Now;
        }
        public Int64 Id { get; set; }

        public Int32 CompanyId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string Name { get; set; }

        public DateTime LastLogin { get; set; }

        public string Password { get; set; }

        public Int32 PortalId { get; set; }

        public Int32 RoleId { get; set; }

        public Int32 StatusId { get; set; }

        public string TelePhone { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string Username { get; set; }
    }
}
