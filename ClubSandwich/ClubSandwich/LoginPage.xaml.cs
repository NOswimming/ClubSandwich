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
            //this.Navigation.PushAsync(new MainTabbedPage());
            App.Current.MainPage = new MainTabbedPage();
	    }

        void Authenticate(Object sender, ClickedEventArgs e)
        {
            var authenticator = new AuthenticationService().GetAuthenticator();

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;
            Navigation.PushModalAsync(authenticator.AuthenticationPage);
        }

        void OnAuthCompleted(object sender, EventArgs eventArgs)
        {
            // We presented the UI, so it's up to us to dimiss it on iOS.
            //DismissViewController(true, null);
            GoToTabbedPage(sender, null);
        }

        void OnAuthError(object sender, EventArgs eventArgs)
        {
            // Do something with errors
        }
    }
}