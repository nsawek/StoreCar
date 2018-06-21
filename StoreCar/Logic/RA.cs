using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreCar.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StoreCar.Logic
{
    internal class RA
    {
        internal void AddUserAndRole()
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var roleS = new RoleStore<IdentityRole>(context);
 
            var rM = new RoleManager<IdentityRole>(roleS);

            if (!rM.RoleExists("Ed"))
            {
                IdRoleResult = rM.Create(new IdentityRole { Name = "Ed" });
            }

            var uM = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var aU = new ApplicationUser
            {
                UserName = "test@test.net",
                Email = "test@test.net"
            };
            IdUserResult = uM.Create(aU, "Pa$$word1");

           
            if (!uM.IsInRole(uM.FindByEmail("test@test.net").Id, "Ed"))
            {
                IdUserResult = uM.AddToRole(uM.FindByEmail("test@test.net").Id, "Ed");
            }
        }
    }
}