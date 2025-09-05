using System.Net.Http.Json;
using TradingJournal.Data.Models;

var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5294/"); // API URL

// Beispiel-Trade hinzufügen
var trade = new Trade
{
    Symbol = "EURUSD",
    Lots = 1.5,
    RisikoProzent = 2,
    RisikoEuro = 100,
    ProfitProzent = 4,
    ProfitEuro = 200,
    Gedanken = "Entry nach Support Bounce",
    DailyBias = "Bullish",
    Datum = DateTime.UtcNow
};

Console.WriteLine("📤 Sende Trade...");
var response = await client.PostAsJsonAsync("api/trades", trade);
response.EnsureSuccessStatusCode();

Console.WriteLine("✅ Trade gespeichert!");

// Trades abrufen
Console.WriteLine("📥 Hole alle Trades...");
var trades = await client.GetFromJsonAsync<List<Trade>>("api/trades");

foreach (var t in trades!)
{
    Console.WriteLine($"#{t.Id}: {t.Symbol} - Profit: {t.ProfitEuro}€");
}
