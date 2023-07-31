using Microsoft.EntityFrameworkCore;
using RentACar.Models.Views;

namespace RentACar.Models
{
    public class DataContex:DbContext
    {
        public DataContex(DbContextOptions<DataContex> options) : base(options)
        {

        }
        public DbSet<TBL_MARKA> TBL_MARKA { get; set; }
        public DbSet<TBL_ARAC> TBL_ARAC { get; set; }
        public DbSet<ILLER> ILLER { get; set; }
        public DbSet<RentView> RentView { get; set; }
        public DbSet<TBL_KULLANICI> TBL_KULLANICI { get; set; }
        
    }

}
