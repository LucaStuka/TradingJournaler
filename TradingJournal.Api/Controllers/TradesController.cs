using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradingJournal.Data;          // für JournalContext
using TradingJournal.Data.Models;   // für Trade
using TradingJournal.DB;

namespace TradingJournal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradesController : ControllerBase
    {
        private readonly JournalContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public TradesController(JournalContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET api/GetTrades
        [HttpGet]
        public async Task<IActionResult> GetTrades()
        {
            return Ok(await _context.Trades.AsNoTracking().ToListAsync());
        }

        // GET api/GetTradeById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTradeById(int id)
        {
            var trade = await _unitOfWork.Trades.GetByIdAsync(id);

            if (trade == null)
            {
                return NotFound();
            }

            return Ok(trade);
        }

        // 
        [HttpPost]
        public async Task<IActionResult> AddTrade(Trade trade)
        {
            _unitOfWork.Add(trade);
            await _unitOfWork.BeginTransactionAsync();

            return CreatedAtAction("GetTradeById", new { id = trade.Id }, trade);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            var trade = await _unitOfWork.Trades.GetByIdAsync(id);
            if (trade == null)
            {
                return NotFound();
            }

            _unitOfWork.Remove(trade);
            await _unitOfWork.BeginTransactionAsync();
            System.Console.WriteLine("Trade Deleted");

            return NoContent();
        }
    }
}

// Wir brauchen Get, Put, Post, Delete