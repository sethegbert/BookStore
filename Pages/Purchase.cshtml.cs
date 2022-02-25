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

        public PurchaseModel (IBookStoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        // Look to see if there is already info for the basket by session, if not create new
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        
        }

        // Load item according to what is selected, then add it to the basket
        // Include info for user session
        public IActionResult OnPost(int BookID, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookID == BookID);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookID == BookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
