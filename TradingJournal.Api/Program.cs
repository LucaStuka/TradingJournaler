using Microsoft.EntityFrameworkCore;
using TradingJournal.Data;

var builder = WebApplication.CreateBuilder(args);

// DB-Context
builder.Services.AddDbContext<JournalContext>(options =>
    options.UseSqlite("Data Source=tradingjournal.db"));

// Controller & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();