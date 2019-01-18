using Contoso.Financial.Website.Areas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contoso.Financial.Website.Areas.API.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        readonly string transactionAPIUrl;

        public TransactionsController()
        {
            transactionAPIUrl = System.Configuration.ConfigurationManager.AppSettings["transactionAPIUrl"];
        }

        public async Task<JsonResult> Recent()
        {
            var data = await CallApi<IEnumerable<TransactionModel>>("api/transactions/get");

            // format DateTime for display
            foreach(var d in data)
            {
                d.DateTime = DateTime.Parse(d.DateTime).ToString("MM/dd/yyyy hh:mm:ss");
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Balance()
        {
            var data = await CallApi<IEnumerable<BalanceModel>>("api/balance/get");
            return Json(data.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        #region Helpers

        private async Task<T> CallApi<T>(string requestUri)
        {
            // Call the API to get data
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.transactionAPIUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    var txt = await response.Content.ReadAsStringAsync();
                    throw new Exception(string.Format("'{0}' failed: {1}", requestUri, txt));
                }
            }
        }

        #endregion
    }
}