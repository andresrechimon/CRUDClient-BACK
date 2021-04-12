using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBCRUDClient.Models;
using Microsoft.EntityFrameworkCore;

namespace FBCRUDClient
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<ClientsModel> CRUDClientDDBB { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
