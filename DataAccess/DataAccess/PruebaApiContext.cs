using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;

namespace PruebaAppApi.DataAccess.DataAccess
{
    public class PruebaApiContext: LinkticEcomerceContext
    {
        public PruebaApiContext(CustomDbSettings options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        
        }
    }
}
