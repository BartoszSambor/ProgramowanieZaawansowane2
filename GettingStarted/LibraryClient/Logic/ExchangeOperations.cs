using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibraryClient.Logic
{
    public class ExchangeOperations
    {
        public static readonly Dictionary<string, decimal> ExchangeRateToEuro = new Dictionary<string, decimal>();
        public static List<string> FromCurrency = new List<string>();
        public static List<string> ToCurrency = new List<string>();

        public static void LoadRates()
        {
            if(FromCurrency.Count > 0)
            {
                return;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            Debug.WriteLine("Start currencies");

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            {
                Debug.WriteLine("\"" + node.Attributes["currency"].Value + "\",\n");
                ExchangeRateToEuro.Add(node.Attributes["currency"].Value, decimal.Parse(node.Attributes["rate"].Value, new System.Globalization.CultureInfo("en-US")));
                FromCurrency.Add(node.Attributes["currency"].Value);
                ToCurrency.Add(node.Attributes["currency"].Value);
            }
        }

        public static string[] GetNames()
        {
            var s = new string[31] {"USD", "JPY", "BGN", "CZK", "DKK", "GBP", "HUF", "PLN", "RON", "SEK", "CHF", "ISK", "NOK", "HRK", "TRY", "AUD", "BRL", "CAD", "CNY",
                "HKD", "IDR", "ILS", "INR", "KRW", "MXN", "MYR", "NZD", "PHP", "SGD", "THB", "ZAR" };
            return s;
        }
    }
}
