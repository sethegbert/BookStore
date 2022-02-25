using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Set up interface

namespace BookStore.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Purchases { get; }

        void SavePurchase(Purchase purchase);
    }
}
