using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.DBConnections 
{
   public class CompanyContext: DbContext
    {
       public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
       {

       }
    }
}
