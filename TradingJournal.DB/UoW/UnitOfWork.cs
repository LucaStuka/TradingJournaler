using TradingJournal.Data;
using TradingJournal.Data.Models;
using TradingJournal.DB.TradeModels;

namespace TradingJournal.DB.UoW
{
    // Implementiert das Unit-of-Work-Pattern für die Datenbankzugriffe
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JournalContext _context; // Datenbankkontext
        public ITradeRepository Trades { get; }   // Repository für Trades

        // Konstruktor: Initialisiert Kontext und Repository
        public UnitOfWork(JournalContext context)
        {
            _context = context;
            Trades = new TradeRepository(_context);
        }

        // Gibt Ressourcen frei
        public void Dispose()
        {
            _context.Dispose();
        }

        // Speichert alle Änderungen asynchron in der Datenbank
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Beginnt eine Transaktion, speichert Änderungen und committet oder rollt zurück bei Fehlern
        public async Task BeginTransactionAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var output = await SaveChangesAsync();
                var itemsOutput = await SaveChangesAsync();
                System.Console.WriteLine("DB Changes: " + output);
                System.Console.WriteLine("ItemChanges: " + itemsOutput);

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                Console.WriteLine("Rollback");
                throw;
            }
        }

        // Fügt ein neues Entity hinzu (nur Trade unterstützt)
        public async void Add<T>(T entity) where T : class
        {
            switch (entity)
            {
                case Trade:
                    var newSong = entity as Trade ?? throw new Exception("Entity is not a Trade");
                    await Trades.AddAsync(newSong);
                    System.Console.WriteLine("Added Trade");
                    break;

                default:
                    break;
            }
        }

        // Entfernt ein Entity (nur Trade unterstützt)
        public void Remove<T>(T entity) where T : class
        {
            switch (entity)
            {
                case Trade:
                    var toRemoveSong = entity as Trade ?? throw new Exception("Entity is not a Trade");
                    Trades.Remove(toRemoveSong);
                    break;

                default:
                    break;
            }
        }

        // Aktualisiert ein Entity (nur Trade unterstützt)
        public void Update<T>(T entity) where T : class
        {
            switch (entity)
            {
                case Trade:
                    var toUpdateSong = entity as Trade ?? throw new Exception("Entity is not a Trade");
                    Trades.Update(toUpdateSong);
                    break;

                default:
                    break;
            }
        }
    }
}