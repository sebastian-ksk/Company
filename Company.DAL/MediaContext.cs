using Microsoft.EntityFrameworkCore;

namespace AdsPharma.DAL
{
    public class MediaContext:DbContext
    {
        public MediaContext(DbContextOptions<MediaContext> options):base(options)
        {

        }
    }
}