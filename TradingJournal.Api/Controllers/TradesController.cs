using Microsoft.AspNetCore.Mvc;
using TradingJournal.Data;          // für JournalContext
using TradingJournal.Data.Models;   // für Trade

namespace TradingJournal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradesController : ControllerBase
    {
        private readonly JournalContext _context;

        public TradesController(JournalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTrades()
        {
            return Ok(_context.Trades.ToList());
        }

        [HttpPost]
        public IActionResult AddTrade([FromBody] Trade trade)
        {
            _context.Trades.Add(trade);
            _context.SaveChanges();
            return Ok(trade);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrade(int id)
        {
            return NoContent();
        }
    }
}

// Wir brauchen Get, Put, Post, Delete