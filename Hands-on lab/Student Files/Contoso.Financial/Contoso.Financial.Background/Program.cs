using System;
using System.Data.SqlClient;

namespace Contoso.Financial.Background
{
    class Program
    {
        static Random rnd = new Random(DateTime.Now.Millisecond);

        static void Main(string[] args)
        {
            GenerateTransaction();
        }

        static void GenerateTransaction()
        {
            var amount = -10000d * rnd.NextDouble();
            var datetime = DateTime.UtcNow;

            var randomDepositNum = rnd.Next(1, 10);
            if (randomDepositNum > 7)
            {
                amount = amount * -1d;
            }
            amount = Math.Round(amount, 2);

            var description = GenerateDescription();

            InsertTransaction(datetime, amount, description);
        }

        private static void InsertTransaction(DateTime datetime, double amount, string description)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["TransactionDb"].ConnectionString;

            using (var con = new SqlConnection(connString))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = @"InsertTransaction";

                    cmd.Parameters.AddWithValue("@datetime", datetime);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        private static string GenerateDescription()
        {
            var companyFirstPart = new string[] {
                "Contoso",
                "Fabrikam",
                "AdventureWorks",
                "Acme",
                "Blue Yonder",
                "WingTip",
                "TailSpin"
            };

            var companySecondPart = new string[] {
                "Financial - Bank Fee",
                "Grocery",
                "Utility",
                "Power and Gas",
                "Online Services",
                "Telecommunications",
                "Automotive Repair",
                "Fuel",
                "Lawn Care",
                "Construction",
                "& Sons",
                "Clothing and More",
                "& Co.",
                "Inc.",
                "Industries",
                "Corporation",
                "Appliance Repair",
                "Bros.",
                "Bank",
                "Hotel",
                "Airlines",
                "Electronics",
                "Computer Repair",
                "Traders",
                "School of Fine Arts",
                "Toys and More",
                "Games",
                "Imports",
                "Company",
                "Coffee",
                "Healthcare"
            };

            var one = rnd.Next(0, companyFirstPart.Length);
            var two = rnd.Next(0, companySecondPart.Length);

            return string.Format("{0} {1}", companyFirstPart[one], companySecondPart[two]);
        }


    }
}
