using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace tp4.Models
{
    public class Personal_info
    {
        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\souma\Downloads\database.db;");
            con.Open();
            String query = "SELECT * FROM personal_info ";
            using (con)
            {
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        String first_name = (string)reader["first_name"];
                        String last_name = (string)reader["last_name"];
                        String email = (string)reader["email"];
                        //DateOnly dateofbirth = (DateOnly)reader["date_birth"];
                        String image = (string)reader["image"];
                        String country = (string)reader["country"];
                        Debug.WriteLine("Id : " + id + " First name : " + first_name + " Last name : " + last_name + " Email : " + email + " Country : " + country + " image : " + image + "  Date of birth : ");
                        list.Add(new Person(id, first_name, last_name, email, image, country));
                    }
                }
            }
            return list;
        }
        public Person GetPerson(int id)
        {
            List<Person> persons = GetAllPerson();
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].id == id)
                {
                    return persons[i];
                }
            }
            return null;

        }
    }
}