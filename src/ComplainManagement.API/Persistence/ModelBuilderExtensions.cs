using ComplainManagement.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplainType>().HasData(
           new List<ComplainType>()
           {
           new ComplainType(){ ComplainTypeId=1,ComplainTypeName = "Network" },
           new ComplainType(){ ComplainTypeId=2,ComplainTypeName = "Billing" },
           new ComplainType(){ ComplainTypeId=3,ComplainTypeName = "Call Drop" },
           new ComplainType(){ ComplainTypeId=4,ComplainTypeName = "Internet" },
           }
       );
        }
    }
}
