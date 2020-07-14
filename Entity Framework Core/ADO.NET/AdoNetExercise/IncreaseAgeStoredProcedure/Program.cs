using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=.;Database=MinionsDB;Integrated Security=true";
            using SqlConnection dbCon = new SqlConnection(connection);

            dbCon.Open();

            int minionId = int.Parse(Console.ReadLine());

            IncreaseAgeStoredProcedure(dbCon, minionId);

        }

        private static void IncreaseAgeStoredProcedure(SqlConnection dbCon, int minionId)
        {
            using SqlCommand getOlderProc = new SqlCommand("usp_GetOlder",dbCon);
            getOlderProc.CommandType = CommandType.StoredProcedure;

            getOlderProc.Parameters.AddWithValue("@id", minionId);

            getOlderProc.ExecuteNonQuery();

            using SqlCommand getMinionInfo = new SqlCommand("SELECT Name,Age From Minions " +
                "WHERE Id = @Id",dbCon);
            getMinionInfo.Parameters.AddWithValue("@Id", minionId);

            SqlDataReader reader = getMinionInfo.ExecuteReader();

            using (reader)
            {
                reader.Read();
                Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
            }
        }
    }
}
