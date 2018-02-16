using ClubSandwich.Model;
using ClubSandwich.Service.GroupList;
using ClubSandwich.Service.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSandwich.ViewModel
{
    public class WeekPageViewModel : INotifyPropertyChanged
    {
        public bool IsRefreshing { get { return isRefreshing; } set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); } }
        public ObservableCollection<WeeklyGroupListViewModel<Week>> Weekly { get { return weekly; } set { weekly = value; OnPropertyChanged(nameof(Weekly)); } }

        public WeekPageViewModel()
        {
            //FetchData();
        }


        public async Task FetchData()
        {
            var service = new WeeklyQuery();
            var result = await service.Get();
            if (result.Data != null)
            {
                var weeklist = result.Data.Weeks.OrderByDescending(m => m.WeekId).ToList();
                Weekly = new ObservableCollection<WeeklyGroupListViewModel<Week>>().AddList(weeklist);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ObservableCollection<WeeklyGroupListViewModel<Week>> weekly;
        bool isRefreshing;


    }
}
