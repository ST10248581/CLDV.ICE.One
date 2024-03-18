using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_ICE_One.Models;

namespace MVC_ICE_One.Data
{
    public class MVC_ICE_OneContext : DbContext
    {
        public MVC_ICE_OneContext (DbContextOptions<MVC_ICE_OneContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_ICE_One.Models.WorkItemModel> WorkItemModel { get; set; } = default!;
    }
}
