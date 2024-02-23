using System.ComponentModel.DataAnnotations;

namespace Company.API.DTOs.Users
{
    public class UserDTO
    {
 
        [Required(ErrorMessage = "The {0} is Required")]
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
        public string? TipoUsr { get; set; }
        public bool Active { get; set; }
        public string? Nombre { get; set; }
        public string? Img { get; set; }
        public string? Other { get; set; }
        public string? PermissionsChecks { get; set; }


    }
}
