using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contoso.Financial.Api.Models;
using System.Data.SqlClient;

namespace Contoso.Financial.Api.Controllers
{
    public class BalanceController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<BalanceModel> Get()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["TransactionDb"].ConnectionString;

            using (var con = new SqlConnection(connString))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetBalance";

                    con.Open();
                    double? availableBalance = cmd.ExecuteScalar() as double?;
                    con.Close();

                    return new BalanceModel[] {
                        new BalanceModel
                        {
                            AvailableBalance = availableBalance.Value
                        }
                    };

                }
            }
        }

    }
}