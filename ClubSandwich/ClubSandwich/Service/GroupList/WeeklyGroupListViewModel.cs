using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClubSandwich.Service.GroupList
{
    public class WeeklyGroupListViewModel<T> : ObservableCollection<T>
    {
        public string Title { get; set; }
        public string TitleAbbr { get; set; }
        public WeeklyGroupListViewModel(string title)
        {
            this.Title = title;
        }


    }
}
