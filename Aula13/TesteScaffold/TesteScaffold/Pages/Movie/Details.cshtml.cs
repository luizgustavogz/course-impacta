using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TesteScaffold.Data;
using TesteScaffold.Models;

namespace TesteScaffold.Pages.Movie
{
    public class DetailsModel : PageModel
    {
        private readonly TesteScaffold.Data.TesteScaffoldContext _context;

        public DetailsModel(TesteScaffold.Data.TesteScaffoldContext context)
        {
            _context = context;
        }

        public TesteScaffold.Models.Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
