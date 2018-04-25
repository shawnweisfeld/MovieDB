using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieDB.Models;

namespace MovieDB.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieDB.Models.MovieContext<Movie> _context;

        public CreateModel(MovieDB.Models.MovieContext<Movie> context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.CreateItemAsync(Movie);

            return RedirectToPage("./Index");
        }
    }
}