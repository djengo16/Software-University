using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeTownNamesCasing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connection = @"Server=.;Database=MinionsDB;Integrated Security=true";
            using SqlConnection dbCon = new SqlConnection(connection);

            dbCon.Open();
            
            string countryName = Console.ReadLine();

            ChangeTownName(dbCon, countryName);

        }

        private static void ChangeTownName(SqlConnection dbCon, string countryName)
        {


            using SqlCommand changedTownsCmd = new SqlCommand("UPDATE Towns  SET Name = UPPER(Name)" +
                " WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)",dbCon);
            changedTownsCmd.Parameters.AddWithValue("@countryName", countryName);

            int changedTownsCount = changedTownsCmd.ExecuteNonQuery();

            if(changedTownsCount == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }
            else
            {
                List<string> affectedTowns = new List<string>();

               using SqlCommand getTownNamesCmd = new SqlCommand("SELECT Name FROM Towns " +
                    "WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", dbCon);
                getTownNamesCmd.Parameters.AddWithValue("@countryName", countryName);

                SqlDataReader reader = getTownNamesCmd.ExecuteReader();

                using (reader)
                {
                    int counter = 0;
                    while (reader.Read())
                    {
                        
                        affectedTowns.Add((string)reader["Name"]);
                        counter++;
                    }
                    Console.WriteLine($"{changedTownsCount} town names were affected");
                    Console.Write("[");
                    Console.Write(String.Join(", ", affectedTowns));
                    Console.Write("]");
                }
                
            }
        }
    }
}
