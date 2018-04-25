using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDB.Models;

namespace MovieDB.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly MovieDB.Models.MovieContext<Movie> _context;

        public EditModel(MovieDB.Models.MovieContext<Movie> context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.UpdateItemAsync(Movie.id, Movie);

            return RedirectToPage("./Index");
        }
    }
}
