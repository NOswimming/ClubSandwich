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
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage ()
        {
            InitializeComponent();
            Children.Add(new NavigationPage(new WeekPage() { Title = "Week View Page" }) { Title = "Week View" });
            Children.Add(new NavigationPage(new ShoppingPage() { Title = "Shopping Page" }) { Title = "Shopping" });
        }
    }
}