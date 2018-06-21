using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using StoreCar.Models;
using StoreCar.Logic;

namespace StoreCar
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Kod uruchamiany podczas uruchamiania aplikacji
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Kod uruchamiany podczas łączenia z bazą danych
            Database.SetInitializer(new ProductDatabaseInitializer());

            RA rA = new RA();
            rA.AddUserAndRole();
        }
    }
}