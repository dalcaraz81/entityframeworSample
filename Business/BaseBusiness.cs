using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business
{
    public abstract class BaseBusiness
    {
        public abstract bool Create(ViewModel model);

        public abstract bool Update(ViewModel model);

        public abstract bool Delete(ViewModel model);
    }
}
