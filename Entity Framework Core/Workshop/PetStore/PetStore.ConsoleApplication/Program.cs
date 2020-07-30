using PetStore.Data;
using PetStore.Models;
using System;

namespace PetStore.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            PetStoreDbContext db = new PetStoreDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            Console.WriteLine("Created!");
        }
    }
}
