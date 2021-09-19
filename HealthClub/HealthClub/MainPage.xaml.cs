using HealthClub.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthClub
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            PopulateCustomerList();
        }

        public void PopulateCustomerList()
        {
            CustomerList.ItemsSource = null;
            CustomerList.ItemsSource = DependencyService.Get<SQLiteInterface>().GetCustomers();
        }

        private void AddCustomer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CustomerPage());
        }

        private void EditCustomer(object sender, ItemTappedEventArgs e)
        {
            Customer details = e.Item as Customer;
            if (details != null)
            {
                Navigation.PushAsync(new CustomerPage(details));
            }
        }
        private async void DeleteCustomer(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete Customer?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Customer Customer = menu.CommandParameter as Customer;
                DependencyService.Get<SQLiteInterface>().DeleteCustomer(Customer.ID);
                PopulateCustomerList();
            }
        }
    }
}
