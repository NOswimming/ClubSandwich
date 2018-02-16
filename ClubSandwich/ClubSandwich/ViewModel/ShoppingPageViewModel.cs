using ClubSandwich.Model;
using ClubSandwich.Service.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ClubSandwich.ViewModel
{
    public class ShoppingPageViewModel : INotifyPropertyChanged
    {
        public bool IsRefreshing { get { return isRefreshing; } set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); } }
        public ObservableCollection<Shopping> Shopping { get { return shopping; } set { shopping = value; OnPropertyChanged(nameof(Shopping)); } }

        public ShoppingPageViewModel()
        {
            FetchData();
        }

        public async void FetchData()
        {
            var service = new ShoppingQuery();
            var result = await service.Get().ConfigureAwait(false);
            if (result.Data != null)
            {
                var items = result.Data.Weeks.OrderByDescending(m => m.WeekId).Select(x => new Shopping() { ShopperName = $"{x.Shopper.FirstName} {x.Shopper.LastName}", Cost = x.Cost, Owed = (x.Cost - x.Users.Sum(s => s.Paid)), Paid = x.Users.Sum(s => s.Paid) }).ToList();
                Shopping = new ObservableCollection<Model.Shopping>(items); 
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ObservableCollection<Shopping> shopping;
        bool isRefreshing;
    }
}
