using DAO.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Exceptions
{
    public class GenerateQueryException : Exception
    {
        public GenerateQueryException(string msg) : base(msg) { }
    }   
}
