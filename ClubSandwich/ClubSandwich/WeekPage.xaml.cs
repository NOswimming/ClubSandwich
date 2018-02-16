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
            //var currentWeek = new ClubSandwich.Model.Week()
            //{

            //};

			InitializeComponent ();
            vm = new WeekPageViewModel();
            BindingContext = vm;
        }

        public void LogOut_Clicked(Object sender, ClickedEventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}