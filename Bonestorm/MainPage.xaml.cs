using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System.Net;
using System.Text.Json;
using System.Data;
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
            DateTime dzis = DateTime.Now;
            dpData.MaximumDate = dzis;

        }

       private void BcurrencyUSD(object sender, EventArgs e )
        {
            string data = dpData.Date.ToString("yyyy-MM-dd");

            string json;
            string urlUSD = "https://api.nbp.pl/api/exchangerates/rates/c/usd/"+data+"/?format=json";

           
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

        private void BcurrencyEUR(object sender, EventArgs e)
        {
            string data = dpData.Date.ToString("yyyy-MM-dd");

            string json;
            string urlEUR = "https://api.nbp.pl/api/exchangerates/rates/c/eur/"+data+"/?format=json";


            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(urlEUR);
            }

            Currency c = JsonSerializer.Deserialize<Currency>(json);
            string s = $"nazwa waluty : {c.currency}\n";
            s += $"kod waluty {c.code} \n";
            s += $"Data : {c.rates[0].effectiveDate} \n";
            s += $"Cena skupu : {c.rates[0].bid} \n";
            s += $"Cena sprzedazy : {c.rates[0].ask} \n ";
            textCurrencyEUR.Text = s;

        }
    }

}
