using Microsoft.EntityFrameworkCore;

namespace Company.DAL
{
    public class MediaContext:DbContext
    {
        public MediaContext(DbContextOptions<MediaContext> options):base(options)
        {

        }
    }
}