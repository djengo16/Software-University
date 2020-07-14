using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintAllMinionNames
{
    //Write a program that prints all minion names from the minions table in the following order:
    //    first record, last record, first + 1, last - 1, first + 2, last - 2 … first + n, last - n.
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=.;Database=MinionsDB;Integrated Security=true";
            using SqlConnection dbCon = new SqlConnection(connection);

            dbCon.Open();

            PrintAllMinionNames(dbCon);
        }

        private static void PrintAllMinionNames(SqlConnection dbCon)
        {
            using SqlCommand command = new SqlCommand("SELECT Name FROM Minions",dbCon);

            using SqlDataReader reader = command.ExecuteReader();

            List<string> minions = new List<string>();

            while (reader.Read())
            {
                minions.Add((string)reader["Name"]);
            }

            while(minions.Count != 0)
            {
                Console.WriteLine(minions.First());
                minions.RemoveAt(0);
                if(minions.Count != 0)
                {
                    Console.WriteLine(minions.Last());
                    minions.RemoveAt(minions.Count - 1);
                }

            }
        }


    }
}
