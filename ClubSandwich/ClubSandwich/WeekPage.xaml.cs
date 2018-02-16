using ClubSandwich.Model;
using ClubSandwich.Service.GroupList;
using ClubSandwich.Service.Query;
using ClubSandwich.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}