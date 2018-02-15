using System;
using Xamarin.Auth;
using Xamarin.Forms;

namespace ClubSandwich
{
    class AuthenticationService : ContentPage
    {
        public void Authenticate()
        {
            var authenticator = new OAuth2Authenticator
                (
                    clientId: "1542347896056535",
                    scope: "",
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"),
                    isUsingNativeUI: false
                );

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            Navigation.PushModalAsync(new Xamarin.Auth.XamarinForms.AuthenticatorPage(authenticator));
        }

        void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            // We presented the UI, so it's up to us to dimiss it on iOS.
            //DismissViewController(true, null);

            if (eventArgs.IsAuthenticated)
            {
                // Use eventArgs.Account to do wonderful things
                System.Console.WriteLine(eventArgs.Account.Username + eventArgs.Account.Properties);
            }
            else
            {
                // The user cancelled
            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs eventArgs)
        {
            // Do something with errors
        }

    }
}
