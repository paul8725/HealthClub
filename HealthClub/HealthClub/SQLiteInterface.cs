using HealthClub.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClub
{
    public interface SQLiteInterface
    {
        SQLiteConnection GetConnectionForDatabase();
        bool SaveCustomer(Customer customer);
        List<Customer> GetCustomers();
        bool UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
