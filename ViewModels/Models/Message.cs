using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class Message
    {
        public string Msg { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public bool Success { get; set; }
    }
}
