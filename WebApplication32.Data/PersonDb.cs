using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WebApplication32.Data
{
    public class PersonDb
    {
        private string _connectionString;

        public PersonDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM People";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Person> ppl = new List<Person>();
                while (reader.Read())
                {
                    ppl.Add(new Person
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Age = (int)reader["Age"]
                    });
                }
                return ppl;
            }
        }

        public void AddPerson(Person person)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO People(FirstName, LastName, Age)
                                    VALUES(@firstName, @lastName, @age)";
                cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
