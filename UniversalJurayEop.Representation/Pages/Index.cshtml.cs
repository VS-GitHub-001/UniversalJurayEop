using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversalJurayEop.Domain.Models;
using UniversalJurayEop.Infrastructure.Context;

namespace UniversalJurayEop.Represenation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Food> Foods { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Foods = await _context.Foods.ToListAsync();
            return Page();
        }
    }
}