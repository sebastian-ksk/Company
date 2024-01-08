using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Services
{

    public interface IUserService
    {

    }

    public class UserService
    {
        public readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }


    }
}
