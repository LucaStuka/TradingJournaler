namespace TradingJournal.DB
{
    // Interface für das Unit-of-Work-Pattern, kapselt Transaktionen und Repositories
    public interface IUnitOfWork : IDisposable
    {
        // Zugriff auf das Trade-Repository
        ITradeRepository Trades { get; }

        // Speichert alle Änderungen asynchron in der Datenbank
        Task<int> SaveChangesAsync();

        // Beginnt eine Transaktion und speichert Änderungen
        Task BeginTransactionAsync();

        // Fügt ein neues Entity hinzu (generisch)
        void Add<T>(T entity) where T : class;

        // Entfernt ein Entity (generisch)
        void Remove<T>(T entity) where T : class;

        // Aktualisiert ein Entity (generisch)
        void Update<T>(T entity) where T : class;
    }
}