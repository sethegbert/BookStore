using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
    public class BooksViewModel
    {
        // grab info needed for the view, including page info and info from original repository
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
