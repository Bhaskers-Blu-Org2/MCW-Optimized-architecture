using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Contoso.Financial.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Initialize DB schema at startup
            // This is just here to make the code sample easier to run,
            // you don't really want to do this in a production app. :)
            for(var i = 0; i <= 5; i++)
            {
                RunSqlInitScript(i.ToString());
            }


        }


        private void RunSqlInitScript(string fileNumber)
        {
            using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransactionDb"].ConnectionString))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = File.ReadAllText(Server.MapPath("~/App_Data/InitDB" + fileNumber + ".sql"));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
