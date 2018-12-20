using Contoso.Financial.Api.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace Contoso.Financial.Api.Controllers
{
    public class TransactionsController : ApiController
    {
        public IEnumerable<TransactionModel> Get()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["TransactionDb"].ConnectionString;

            using (var con = new SqlConnection(connString))
            {
                var data = con.Query<TransactionModel>(
                    "SELECT TOP 25 * FROM [Transaction] ORDER BY [DateTime] DESC"
                    );

                return from d in data
                       orderby d.DateTime
                       select d;
            }
        }

    }
}