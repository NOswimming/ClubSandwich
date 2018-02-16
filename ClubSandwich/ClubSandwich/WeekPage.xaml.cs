using ClubSandwich.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClubSandwich
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeekPage : ContentPage
	{
        public WeekPageViewModel vm;
		public WeekPage ()
		{
			InitializeComponent ();
            vm = new WeekPageViewModel();
            BindingContext = vm;
        }

        public void LogOut_Clicked(Object sender, ClickedEventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await vm.FetchData();
        }
    }
}