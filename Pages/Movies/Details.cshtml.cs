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
    public class DetailsModel : PageModel
    {
        private readonly MovieDB.Models.MovieContext<Movie> _context;

        public DetailsModel(MovieDB.Models.MovieContext<Movie> context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.GetItemAsync(id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
