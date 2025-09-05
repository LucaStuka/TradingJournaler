namespace TradingJournal.Data.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public double Lots { get; set; }
        public double RisikoProzent { get; set; }
        public double RisikoEuro { get; set; }
        public double ProfitProzent { get; set; }
        public double ProfitEuro { get; set; }
        public string Gedanken { get; set; } = string.Empty;
        public string DailyBias { get; set; } = string.Empty; // Bullish, Bearish, NRB
        public DateTime Datum { get; set; } = DateTime.UtcNow;
    }
}
