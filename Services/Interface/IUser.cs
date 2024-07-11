using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUser
    {
        public void GetAll();
        public int GetById(int id);

    }
}
