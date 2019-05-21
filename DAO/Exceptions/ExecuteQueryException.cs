using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Exceptions
{
    public class ExecuteQueryException : Exception
    {
        public ExecuteQueryException(string msg) : base(msg) {

        }
    }
}
