using TradingJournal.Data.Models;

namespace TradingJournal.DB
{
    // Interface für das Trade-Repository, definiert CRUD-Operationen für Trades
    public interface ITradeRepository
    {
        // Holt einen Trade anhand der ID asynchron
        Task<Trade?> GetByIdAsync(int ID);

        // Fügt einen neuen Trade asynchron hinzu
        Task AddAsync(Trade song);

        // Aktualisiert einen bestehenden Trade
        void Update(Trade song);

        // Entfernt einen bestehenden Trade
        void Remove(Trade song);
    }
}