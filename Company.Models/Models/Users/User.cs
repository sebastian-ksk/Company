using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Models.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string ? Usuario { get; set; }
        public string ? Clave { get; set; }
        public string ? TipoUsr { get; set; }
        public bool Active { get; set; }
        public string ? Nombre { get; set; }
        public string ? Img { get; set; }
        public string ? Other { get; set; }
        public string ? PermissionsChecks { get; set; }
    }
}
