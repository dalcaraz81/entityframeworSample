using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DAO.Models
{
    public class Role : Model
    {

        public Int32 Id { get; set; }

        public string Name { get; set; }
    }
}
