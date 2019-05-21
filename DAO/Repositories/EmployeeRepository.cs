using DAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DAO.Repositories
{
    public class EmployeeRepository : Repository
    {
        public EmployeeRepository() {

            this.Init(new Employee());
        }
        public List<Employee> GetAll()
        {
            try
            {
                SqlDataReader reader = this.SelectItems();
                return reader.MapModelCollection<Employee>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                this.CloseConnection();
            }
        }

    }
}
