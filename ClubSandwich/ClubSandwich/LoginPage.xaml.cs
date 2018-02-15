using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClubSandwich
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            
			InitializeComponent ();
		    sandwichImage.Source = ImageSource.FromResource("ClubSandwich.Resources.sandwich.jpg");

        }

	    void GoToTabbedPage(Object sender, ClickedEventArgs e)
	    {
	        this.Navigation.PushAsync(new MainTabbedPage());
	    }

    }
}