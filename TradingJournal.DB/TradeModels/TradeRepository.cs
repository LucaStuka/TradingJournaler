using Microsoft.EntityFrameworkCore;
using TradingJournal.Data;
using TradingJournal.Data.Models;

namespace TradingJournal.DB.TradeModels
{
    // Implementierung des Trade-Repositories für CRUD-Operationen auf Trades
    public class TradeRepository(JournalContext context) : ITradeRepository
    {
        // Referenz auf den Datenbankkontext
        private readonly JournalContext _context = context;

        // Holt einen Trade anhand der ID asynchron aus der Datenbank
        public async Task<Trade?> GetByIdAsync(int ID)
        {
            return await _context.Trades.FindAsync(ID);
        }

        // Fügt einen neuen Trade asynchron zur Datenbank hinzu
        public async Task AddAsync(Trade song)
        {
            await _context.Trades.AddAsync(song);
        }

        // Aktualisiert einen bestehenden Trade, falls dieser nicht bereits getrackt wird
        public void Update(Trade song)
        {
            if (_context.Entry(song).State == EntityState.Detached)
            {
                _context.Trades.Update(song);
            }
        }

        // Entfernt einen bestehenden Trade aus der Datenbank
        public void Remove(Trade song)
        {
            _context.Trades.Remove(song);
        }
    }
}