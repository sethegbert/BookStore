using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// create class that keeps track of information regarding what page we are on

namespace BookStore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // Calculate how many pages total we will need 
        // Does math to round up from the decimal calculate to figure out num pages needed
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
