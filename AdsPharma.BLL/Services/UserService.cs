using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL.Repositories;
using Company.Models.Entities.Users;
using Company.Models.Models.Users;

namespace Company.BLL.Services
{

    public interface IUserService
    {
        public List<User> GetUsers();
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeactivateUser(int userId);

    }

    public class UserService: IUserService
    {
       
        public readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository repository)
        {
            _usersRepository = repository;
        }

        public List<User> GetUsers()
        {
            return _usersRepository.GetUsersRep();  
        }

        public void CreateUser(User user)
        {
            _usersRepository.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            _usersRepository.UpdateUser(user);
        }

        public void DeactivateUser(int userId)
        {
            _usersRepository.DeactivateUser(userId);
        }


    }

}
