using ClubSandwich.Model;
using ClubSandwich.Service.Query;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ClubSandwich.ViewModel
{
    public class MemberPageViewModel : INotifyPropertyChanged
    {
        public bool IsRefreshing { get { return isRefreshing; } set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); } }
        public ObservableCollection<User> Users { get { return users; } set { users = value; OnPropertyChanged(nameof(Users)); } }
        public MemberPageViewModel()
        {
            FetchData();
        }
        public async void FetchData()
        {
            var service = new UserQuery();
            var result = await service.GetAllUsers();
            if (result.Data != null)
            {
                var items = result.Data.Users.OrderBy(m => m.LastName).ToList();
                Users = new ObservableCollection<User>(items);
            }

        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ObservableCollection<User> users;
        bool isRefreshing;
    }
}
