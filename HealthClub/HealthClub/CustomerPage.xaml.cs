using HealthClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthClub
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerPage : ContentPage
    {
        Customer customerDetails;
        public CustomerPage()
        {
            InitializeComponent();
        }
        public CustomerPage(Customer customer)
        {
            InitializeComponent();
            customerDetails = customer;
            PopulateDetails(customerDetails);
        }

        private void PopulateDetails(Customer details)
        {
            Name.Text = details.Name;
            Address.Text = details.Address;
            PhoneNumber.Text = details.PhoneNumber;
            Email.Text = details.Email;
            Price.Text = details.Fee;
            SaveButton.Text = "Update";
            this.Title = "Update Customer";
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (SaveButton.Text == "Save")
            {
                Customer customer = new Customer();
                customer.Name = Name.Text;
                customer.Address = Address.Text;
                customer.PhoneNumber = PhoneNumber.Text;
                customer.Email = Email.Text;
                customer.Fee = Price.Text;
                bool response = DependencyService.Get<SQLiteInterface>().SaveCustomer(customer);
                if (response)
                {
                    //DisplayAlert("Message", "customer has successfully saved", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "customer has failed to save", "OK");
                }
            }
            else
            {
                customerDetails.Name = Name.Text;
                customerDetails.Address = Address.Text;
                customerDetails.PhoneNumber = PhoneNumber.Text;
                customerDetails.Email = Email.Text;
                customerDetails.Fee = Price.Text;
                bool response = DependencyService.Get<SQLiteInterface>().UpdateCustomer(customerDetails);
                if (response)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "customer has failed to update", "OK");
                }
            }


        }

    }
}