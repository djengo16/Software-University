using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=.;Database=MinionsDB;Integrated Security=true";
            using SqlConnection dbCon = new SqlConnection(connection);

            dbCon.Open();

            var minionIds = Console.ReadLine().Split(" ").ToList();

            IncreaseMinionAge(dbCon, minionIds);
        }

        private static void IncreaseMinionAge(SqlConnection dbCon, List<string> minionIds)
        {
            foreach (var id in minionIds)
            {
                string minionId = id;

                using SqlCommand changeAgeAndNameCmd = new SqlCommand($@"UPDATE Minions
                                                            SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                            WHERE Id = {minionId}", dbCon);


                changeAgeAndNameCmd.ExecuteNonQuery();
            }

            using SqlCommand printMinionsCmd = new SqlCommand("SELECT Name, Age FROM Minions", dbCon);
            SqlDataReader reader = printMinionsCmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                }
            }

        }
    }
}
