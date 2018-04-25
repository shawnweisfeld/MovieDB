using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieDB.Models;

namespace MovieDB.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly MovieDB.Models.MovieContext<Movie> _context;

        public DeleteModel(MovieDB.Models.MovieContext<Movie> context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Movie = await _context.GetItemAsync(id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            Movie = await _context.GetItemAsync(id);

            if (Movie != null)
            {
                await _context.DeleteItemAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
