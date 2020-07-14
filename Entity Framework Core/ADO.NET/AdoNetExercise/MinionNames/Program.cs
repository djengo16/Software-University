using System;
using Microsoft.Data.SqlClient;
namespace MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=.;Database=MinionsDB;Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connection);

            dbCon.Open();

            using (dbCon)
            {
                int villainId = int.Parse(Console.ReadLine());
                using SqlCommand getVillainNamecommand = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id",dbCon);

                getVillainNamecommand.Parameters.AddWithValue("@Id", villainId);

                string villainName = 
                    getVillainNamecommand.ExecuteScalar()?.ToString();

                if(villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                  using  SqlCommand getMinionsInfoCommand = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name AS minionName, 
                                         m.Age AS minionAge
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name",dbCon);
                    getMinionsInfoCommand.Parameters.AddWithValue("@Id", villainId);

                    using SqlDataReader reader = getMinionsInfoCommand.ExecuteReader();

                    

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["RowNum"]}. {reader["minionName"]} {reader["minionAge"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Villain: {villainName}");
                        Console.WriteLine("(no minions)");
                    }
                }


            }

        }
    }
}
