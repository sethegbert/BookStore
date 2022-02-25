using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

// Used to define the component view of the shopping cart as an icon

namespace BookStore.Components
{
    public class BasketSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        
        public BasketSummaryViewComponent (Basket basketService)
        {
            basket = basketService;
        }

        public IViewComponentResult Invoke ()
        {
            return View(basket);
        }
    }
}
