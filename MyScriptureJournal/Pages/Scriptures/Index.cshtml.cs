using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Notes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ScriptureNote { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> noteQuery = from s in _context.Scripture
                                           orderby s.Note
                                           select s.Note;

            var scriptures = from s in _context.Scripture
                         select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureNote))
            {
                scriptures = scriptures.Where(x => x.Note == ScriptureNote);
            }

            switch (SortOrder)
            {
                case "book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "date_asc":
                    scriptures = scriptures.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Date);
                    break;
                default:
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
            }

            Notes = new SelectList(await noteQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync(); 
        }
    }
}
