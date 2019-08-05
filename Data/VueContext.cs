using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vue.Data.Entities;

namespace vue.Data{
    public class VueContext: IdentityDbContext<AppUser,AppRole, int>{
        public VueContext(DbContextOptions<VueContext> options) :base(options){
            
        }
    }
}