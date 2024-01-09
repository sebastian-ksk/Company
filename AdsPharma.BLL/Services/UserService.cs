using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL.Repositories;
using Company.Models.Entities.Users;

namespace Company.BLL.Services
{

    public interface IUserService
    {
        public List<UserEntity> GetUsers();
    }

    public class UserService: IUserService
    {
       
        public readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository repository)
        {
            _usersRepository = repository;
        }

        public List<UserEntity> GetUsers()
        {
            return _usersRepository.GetUsersRep();  
        }
    }
}
