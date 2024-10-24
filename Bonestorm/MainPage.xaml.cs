using System.Net;
using System.Text.Json;

namespace Bonestorm
{
    public partial class MainPage : ContentPage
    {
        public class Currency
        {
            public string? table { get; set; }
            public string? currency { get; set; }
            public string? code { get; set; }
            public IList<Rate> rates { get; set; }
        }
        public class Rate
        {
            public string? no { get; set; }
            public string? effectiveDate { get; set; }
            public double? bid { get; set; }
            public double? ask { get; set; }

        }
        
        public MainPage()
        {
            InitializeComponent();
        }

       private void BcurrencyUSD(object sender, EventArgs e )
        {
            string json;
            string urlUSD = "https://api.nbp.pl/api/exchangerates/rates/c/usd/2024-10-22/?format=json";

           
            using (var webClient = new WebClient() ) {
                json = webClient.DownloadString(urlUSD);
             }

            Currency c = JsonSerializer.Deserialize<Currency>(json);
            string s = $"nazwa waluty : {c.currency}\n";
            s += $"kod waluty {c.code} \n";
            s += $"Data : {c.rates[0].effectiveDate} \n";
            s += $"Cena skupu : {c.rates[0].bid} \n";
            s += $"Cena sprzedazy : {c.rates[0].ask} \n ";
            textCurrencyUSD.Text = s;
                 
        }

        private void BcurrencyPLN(object sender, EventArgs e)
        {
            string json;
            string urlPLN = "https://api.nbp.pl/api/exchangerates/rates/c/pln/2024-10-22/?format=json";


            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(urlPLN);
            }

            Currency c = JsonSerializer.Deserialize<Currency>(json);
            string s = $"nazwa waluty : {c.currency}\n";
            s += $"kod waluty {c.code} \n";
            s += $"Data : {c.rates[0].effectiveDate} \n";
            s += $"Cena skupu : {c.rates[0].bid} \n";
            s += $"Cena sprzedazy : {c.rates[0].ask} \n ";
            textCurrencyPLN.Text = s;

        }
    }

}
