using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Models.Entities.Users;
using Microsoft.Data.SqlClient;

namespace Company.DAL.Repositories
{
    public interface IUsersRepository
    {
        public List<UserEntity> GetUsersRep();
    }
    public class UsersRepository: IUsersRepository
    {
        public readonly string _connectionString;
       
        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserEntity> GetUsersRep()
        {
            var users = new List<UserEntity>();
            using (SqlConnection connection = new SqlConnection(_connectionString) )
            {
                SqlCommand command = new SqlCommand("SP_GET_Users", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UserEntity()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Nombre"].ToString(),
                        user = reader["Usuario"].ToString()
                    });
                }
            }
            return users;
            
        }
          

    }
}
