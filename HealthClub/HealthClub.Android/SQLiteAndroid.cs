using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HealthClub.Droid;
using HealthClub.Model;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace HealthClub.Droid
{
    public class SQLiteAndroid : SQLiteInterface
    {
        SQLiteConnection con;

        public void DeleteCustomer(int id)
        {
            string sql = $"Delete From Customer where ID={id}";
            con.Execute(sql);
        }

        public SQLiteConnection GetConnectionForDatabase()
        {
            var dbName = "HealthClubDB.db3";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(dbPath, dbName);
            con = new SQLiteConnection(path);
            con.CreateTable<Customer>();
            return con;
        }

        public List<Customer> GetCustomers()
        {
            string sql = "Select * from Customer";
            List<Customer> customer = con.Query<Customer>(sql);
            return customer;
        }

        public bool SaveCustomer(Customer customer)
        {
            bool flag = false;
            try
            {
                con.Insert(customer);
                flag = true;

            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool res = false;
            try
            {
                string sql = $"UPDATE Customer set Name='{customer.Name}',Address='{customer.Address}',PhoneNumber='{customer.PhoneNumber}', Email='{customer.Email}',Fee='{customer.Fee}' where ID='{customer.ID}'";

                con.Execute(sql);
                res = true;
            }
            catch (Exception ex)
            {

                res = false;

            }
            return res;
        }
    }
}