﻿using ClubSandwich.ViewModel;
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
	public partial class MembersPage : ContentPage
	{
        public MemberPageViewModel vm;
        public MembersPage ()
		{
			InitializeComponent ();
            vm = new MemberPageViewModel();
            BindingContext = vm;
        }

        public void LogOut_Clicked(Object sender, ClickedEventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}