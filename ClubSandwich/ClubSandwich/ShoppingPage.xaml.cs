using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubSandwich.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClubSandwich
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShoppingPage : ContentPage
	{
		public ShoppingPage ()
		{
		    ShoppingRecords.Records = new List<Shopping>();
		    ShoppingRecords.Records.Add(new Shopping
		    {
		        Date = DateTime.Now,
		        ShopperName = "Lars",
		        Cost = Convert.ToDouble(150),
		        Paid = Convert.ToDouble(50),
		        Owed = Convert.ToDouble(100)
		    });

            InitializeComponent ();
            this.Title = "Shopping Page";
		    ListView.ItemsSource = ShoppingRecords.Records;


		}


        public void LogOut_Clicked(Object sender, ClickedEventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}