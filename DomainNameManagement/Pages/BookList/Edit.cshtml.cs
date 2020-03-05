using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }

        [BindProperty]
        public DomainName DomainName { get; set; }

        public async Task OnGet(int id)
        {
            DomainName = await _db.DomainName.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var DomainNameFromDb = await _db.DomainName.FindAsync(DomainName.Id);
                DomainNameFromDb.Name = DomainName.Name;
                DomainNameFromDb.GLCode = DomainName.GLCode;
                DomainNameFromDb.Owner = DomainName.Owner;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}