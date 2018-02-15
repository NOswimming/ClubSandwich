using ClubSandwich.Service.Query;
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
	public partial class WeekPage : ContentPage
	{
		public WeekPage ()
		{
			InitializeComponent ();
            FetchData();
        }

        private async void FetchData()
        {
            var service = new WeeklyQuery();

            var response = await service.Get();
        }
    }
}