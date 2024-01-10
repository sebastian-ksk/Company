using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Models.Entities.Users;
using Company.Models.Models.Users;
using Microsoft.Data.SqlClient;

namespace Company.DAL.Repositories
{
    public interface IUsersRepository
    {
        public Task<List<User>> GetUsersRep();
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeactivateUser(int userId);
      
    }
    public class UsersRepository: IUsersRepository
    {
        public readonly string _connectionString;
       
        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Methods

        public async Task<List<User>> GetUsersRep()
        {
            var users = new List<User>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_GET_Users", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(new User()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Usuario = reader["Usuario"].ToString(),
                            Clave = reader["Clave"].ToString(),
                        });
                    }
                }
            }
            return users;
        }

        public void CreateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_POST_CreateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Usuario", user.Usuario);
                command.Parameters.AddWithValue("@Clave", user.Clave);
                command.Parameters.AddWithValue("@TipoUsr", user.TipoUsr);
                command.Parameters.AddWithValue("@Active", user.Active);
                command.Parameters.AddWithValue("@Nombre", user.Nombre);
                command.Parameters.AddWithValue("@Img", user.Img);
                command.Parameters.AddWithValue("@Other", user.Other);
                command.Parameters.AddWithValue("@PermissionsChecks", user.PermissionsChecks);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_PUT_UpdateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", user.Id);
                // Add other parameters as in CreateUser

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeactivateUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_DELETE_DeactivateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    
        #endregion

    }
}
