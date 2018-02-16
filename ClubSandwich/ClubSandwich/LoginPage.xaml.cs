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

            AnimateLoginScreenAsync();
        }

	    void GoToTabbedPage(Object sender, ClickedEventArgs e)
	    {
            //this.Navigation.PushAsync(new MainTabbedPage());
            App.Current.MainPage = new MainTabbedPage();
	    }

        void Authenticate(Object sender, ClickedEventArgs e)
        {
            var authenticator = new AuthenticationService().GetAuthenticator();

            authenticator.Success += OnAuthSuccess;
            authenticator.Failed += OnAuthFailed;
            Navigation.PushModalAsync(authenticator.AuthenticationPage);
        }

        void OnAuthSuccess(object sender, EventArgs eventArgs)
        {
            // We presented the UI, so it's up to us to dimiss it on iOS.
            //DismissViewController(true, null);
            Navigation.PopModalAsync();
            GoToTabbedPage(sender, null);
        }

        void OnAuthFailed(object sender, EventArgs eventArgs)
        {
            // Do something with errors
            Navigation.PopModalAsync();
            DisplayAlert("Login Failed", "Facebook authentication failed ", "Okay");
            
        }

        async Task AnimateLoginScreenAsync()
        {
            int images = 9;
            uint millisecondsToAnimate = 2000;


            double a = 300;
            double h = -Math.PI;
            double b = images / Math.PI;
            double k = 0;

            var tasks = new Task[images];

            for (int i = 1; i <= images; i++)
            {
                var image = new Image();
                image.Source = ImageSource.FromResource($"ClubSandwich.Resources.SC_logo_{i}.png");
                stackedImageGrid.Children.Add(image);
                
                // Offset based on sine-wave function.
                image.TranslationY = -a * Math.Sin((i - h) / b) + k;
                // Create animation and add to list
                tasks[i] = image.TranslateTo(0, 0, millisecondsToAnimate);                
            }

            loginButton.Opacity = 0;
            Task.WhenAny(tasks);
            await loginButton.FadeTo(1.0, millisecondsToAnimate);
        }
    }
}