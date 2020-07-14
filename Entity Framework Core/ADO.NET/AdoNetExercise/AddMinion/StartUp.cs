using System;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace AddMinion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connection = @"Server=.;Database=MinionsDB;Integrated Security=true";
            SqlConnection dbCon = new SqlConnection(connection);
            dbCon.Open();
            using (dbCon)
            {
                string[] minionsInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] minionInfo = minionsInput[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string minionName = minionInfo[0];
                int minionAge = int.Parse(minionInfo[1]);
                string minionTown = minionInfo[2];

                string[] villainInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string villainName = villainInput[1];


                AddMinionToDb(dbCon, minionName, minionAge, minionTown, villainName);
            }
        }

            private static void AddMinionToDb(SqlConnection dbCon, string minionName,
                int minionAge, string minionTown, string villainName)
            {
                using SqlCommand getTownId = new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", dbCon);
                getTownId.Parameters.AddWithValue("@townName", minionTown);

                string townId = getTownId.ExecuteScalar()?.ToString();

                if (String.IsNullOrEmpty(townId))
                {
                    using SqlCommand addTownCmd = new SqlCommand("INSERT INTO Towns(Name,CountryCode)VALUES(@townName, 1)", dbCon);
                    addTownCmd.Parameters.AddWithValue("townName", minionTown);
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

               using SqlCommand getVillainId = new SqlCommand("SELECT Id FROM Villains WHERE Name = @villainName", dbCon);
                getVillainId.Parameters.AddWithValue("@villainName", villainName);

                string villainId = getVillainId.ExecuteScalar()?.ToString();

                if (String.IsNullOrEmpty(villainId))
                {
                    using SqlCommand addVillainCmd = new SqlCommand("INSERT INTO Villains(Name,EvilnessFactorId)" +
                        " VALUES (@villainName,'evil')", dbCon);
                    addVillainCmd.Parameters.AddWithValue("@villainName", villainName);

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                using SqlCommand getMinionId = new SqlCommand("SELECT Id FROM Minions WHERE Name = @minionName", dbCon);
                getMinionId.Parameters.AddWithValue("@minionName", minionName);

                string minionId = getMinionId.ExecuteScalar()?.ToString();

                using SqlCommand addMinionToVillainCmd = new SqlCommand("INSERT INTO MinionsVillains VALUES (@minionId,@villainId)", dbCon);
                addMinionToVillainCmd.Parameters.AddWithValue("@minionId", minionId);
                addMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

            }
        }
    }
