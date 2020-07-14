using P03_SalesDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Seeding
{
    public interface ISeeder
    {
        void Seed(SalesContext db);
    }
}
