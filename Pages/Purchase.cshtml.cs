using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Building an instance of the basket and loading it so we can use it

namespace BookStore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookStoreRepository repo { get; set; }

        public PurchaseModel (IBookStoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        // Look to see if there is already info for the basket by session, if not create new
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        // Load item according to what is selected, then add it to the basket
        // Include info for user session
        public IActionResult OnPost(int BookID, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookID == BookID);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
