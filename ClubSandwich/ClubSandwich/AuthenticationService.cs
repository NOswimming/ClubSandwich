using System;
using Xamarin.Auth;
using Xamarin.Auth.XamarinForms;
using Xamarin.Forms;

namespace ClubSandwich
{
    class AuthenticationService
    {
        public IAuthenticator GetAuthenticator()
        {
            var oAuth2Authenticator = new OAuth2Authenticator
                (
                    clientId: "1542347896056535",
                    scope: "",
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"),
                    isUsingNativeUI: false
                );

            return new Authenticator(oAuth2Authenticator);
        }

    }

    interface IAuthenticator
    {
        Page AuthenticationPage { get; }
        EventHandler<EventArgs> Success { get; set; }
        EventHandler<EventArgs> Failed { get; set; }
    }

    class Authenticator : IAuthenticator
    {
        public Page AuthenticationPage { get; }
        public EventHandler<EventArgs> Success { get; set; }
        public EventHandler<EventArgs> Failed { get; set; }

        public Authenticator(Xamarin.Auth.Authenticator authenticator)
        {
            AuthenticationPage = new AuthenticatorPage(authenticator);
            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;
        }

        void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            // We presented the UI, so it's up to us to dimiss it on iOS.
            //DismissViewController(true, null);

            if (eventArgs.IsAuthenticated)
            {
                // Use eventArgs.Account to do wonderful things
                System.Console.WriteLine(eventArgs.Account.Username + eventArgs.Account.Properties);

                Success.Invoke(sender, eventArgs);
            }
            else
            {
                // The user cancelled
                Failed.Invoke(sender, eventArgs);
            }

            
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs eventArgs)
        {
            // Do something with errors
            System.Console.WriteLine(eventArgs.Message);

            Failed.Invoke(sender, eventArgs);
        }
    }
}
