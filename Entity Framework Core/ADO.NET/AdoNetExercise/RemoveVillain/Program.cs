using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that receives the ID of a villain, deletes him from the database and releases his 
            //minions from serving to him.Print on two lines the name of the deleted villain in format "<Name> was deleted." 
            //and the number of minions released in format "<MinionCount> minions were released.".Make sure all operations go
            //as planned, otherwise do not make any changes in the database.
            //If there is no villain in the database with the given ID, print "No such villain was found.".

            int villainId = int.Parse(Console.ReadLine());

            string connection = @"Server=.;Database=MinionsDB;Integrated Security=true";


            using SqlConnection dbCon = new SqlConnection(connection);

            dbCon.Open();

            Console.Write(RemoveVillainWithId(villainId, dbCon));

        }

        private static string RemoveVillainWithId(int villainId, SqlConnection dbCon)
        {
            StringBuilder output = new StringBuilder();

            using SqlTransaction transaction = dbCon.BeginTransaction();

            using SqlCommand checkVillainCmd = new SqlCommand("Select Name FROM Villains WHERE Id = @Id", dbCon);
            checkVillainCmd.Parameters.AddWithValue("@Id", villainId);
            checkVillainCmd.Transaction = transaction;

            string villainName = checkVillainCmd.ExecuteScalar()?.ToString();

            if (villainName == null)
            {
                output.AppendLine("No such villain was found");
            }
            else
            {
                try
                {
                    using SqlCommand deleteFromMinionsVillainsCmd = new SqlCommand("DELETE FROM MinionsVillains WHERE " +
                        "VillainId = @Id", dbCon);

                    deleteFromMinionsVillainsCmd.Parameters.AddWithValue("@Id", villainId);
                    deleteFromMinionsVillainsCmd.Transaction = transaction;

                    int deletedMinionsCount = deleteFromMinionsVillainsCmd.ExecuteNonQuery();

                    using SqlCommand deleteVillainCmd = new SqlCommand("DELETE FROM Villains WHERE Id = @villainId",dbCon);
                    deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);
                    deleteVillainCmd.Transaction = transaction;

                    deleteVillainCmd.ExecuteNonQuery();

                    transaction.Commit();

                    output.AppendLine($"{villainName} was deleted.");
                    output.AppendLine($"{deletedMinionsCount} minions were released.");
                }
                catch (Exception ex)
                {
                    output.AppendLine(ex.Message);
                    try
                    {
                        output.AppendLine(ex.Message);
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {

                        output.AppendLine(rollbackEx.Message);
                    }

                }
                
            }
            return output.ToString().TrimEnd();
        }
    }
}
