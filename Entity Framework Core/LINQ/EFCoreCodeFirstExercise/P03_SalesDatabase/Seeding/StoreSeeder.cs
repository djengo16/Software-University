using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Seeding
{
    public class StoreSeeder : ISeeder
    {
        Random rnd = new Random();
        public StoreSeeder(SalesContext context)
        {
            this.Context = context;
        }

        public SalesContext Context { get; set; }

        public void Seed()
        {
            string[] storeNames = new string[]
            {
                "Sport Depot",
                "Sport Vision",
                "Big Outlet",
                "Sports Direct",
                "Nike Store",
                "Puma Store",
                "Reebook Store"
            };
            ICollection<Store> stores = new List<Store>();

            for (int i = 0; i < 30; i++)
            {
                int nameIndex = rnd.Next(0, storeNames.Length);
                string currentName = storeNames[nameIndex];



                Store store = new Store
                {
                    Name = currentName
                };
                stores.Add(store);
            }
            this.Context.AddRange(stores);
            this.Context.SaveChanges();
        }
    }
}
