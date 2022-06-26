using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_AddressBook
{
    public class AddressBookRepo
    {
        public static string dbpath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=True"";        
        public void CreateNewContact()
        {
            SqlConnection connect = new SqlConnection(dbpath);
            using (connect)
            {
                connect.Open();
                ADO.NET_AddressBook.AddressBookModel model = new ADO.NET_AddressBook.AddressBookModel();
                Console.WriteLine("Enter First Name");
                model.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                model.LastName = Console.ReadLine();
                Console.WriteLine("Enter Address ");
                model.Address = Console.ReadLine();
                Console.WriteLine("Enter City ");
                model.City = Console.ReadLine();
                Console.WriteLine("Enter State ");
                model.State = Console.ReadLine();
                Console.WriteLine("Enter Zip Code ");
                model.ZipCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Phone ");
                model.PhoneNumber = (int)Convert.ToInt64(Console.ReadLine()); 
                Console.WriteLine("Enter Email ");
                model.Email = Console.ReadLine();
                SqlCommand sql = new SqlCommand("SPAddress_Book", connect);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@FirstName", model.FirstName);
                sql.Parameters.AddWithValue("@LastName", model.LastName);
                sql.Parameters.AddWithValue("@Address", model.Address);
                sql.Parameters.AddWithValue("@City", model.City);
                sql.Parameters.AddWithValue("@State", model.State);
                sql.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                sql.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                sql.Parameters.AddWithValue("@Email", model.Email);
                sql.ExecuteNonQuery();
                Console.WriteLine("Record created successfully.");
                connect.Close();
            }
        }
        public void RetrieveDataFromDatabase()
        {
            ADO.NET_AddressBook.AddressBookModel model = new ADO.NET_AddressBook.AddressBookModel();
            SqlConnection connect = new SqlConnection(dbpath);            
            using (connect)
            {
                connect.Open();
                string query = "Select * from Address_Book";

                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //Console.WriteLine("ID\tName\t\t\tSalary\t\t\tDate\t\t\t\tGender\n");
                    while (reader.Read())
                    {
                        model.ID = reader.GetInt32(0);
                        model.FirstName = reader.GetString(1);
                        model.LastName = reader.GetString(2);
                        model.Address = reader.GetString(3);
                        model.City = reader.GetString(4);
                        model.State = reader.GetString(5);
                        model.ZipCode = reader.GetInt32(6);
                        model.PhoneNumber = (int)reader.GetInt64(7);
                        model.Email = reader.GetString(8);
                        Console.WriteLine("ID: " + model.ID + "\nFirstName: " + model.FirstName + "\nLastName: " + model.LastName +
                                "\nAddress" + model.Address + "\nCity: " + model.City + "\nState:" + model.State + "\nZipCode: " + model.ZipCode
                                + "\nPhone: " + model.PhoneNumber + "\nEmail: " + model.Email + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database");
                }
                reader.Close();

            }
            connect.Close();
        }
        public void UpdateRecordDetails()
        {
            SqlConnection connect = new SqlConnection(dbpath);
            try
            {
                using (connect)
                {
                    Console.WriteLine("Enter Name of Person:");
                    string FirstName = Console.ReadLine();
                    Console.WriteLine("Enter ZipCode to update:");
                    int ZipCode = Convert.ToInt32(Console.ReadLine());                   
                    connect.Open();
                    string query = "update Address_Book set ZipCode =" + ZipCode + "Where FirstName='" + FirstName + "'";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records updated successfully");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error:Records are not updated");
            }
        }
        public void DeleteAddressBookContact()
        {
            SqlConnection connect = new SqlConnection(dbpath);
            using (connect)
            {
                connect.Open();
                Console.WriteLine("Enter name of person to  delete from records:");
                string Name = Console.ReadLine();
                string query = "DELETE FROM Address_Book WHERE FirstName='" + Name + "'";
                SqlCommand command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }
        }
    }
}
