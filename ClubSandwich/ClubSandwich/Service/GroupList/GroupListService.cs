using ClubSandwich.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClubSandwich.Service.GroupList
{
    public static class GroupListService
    {
        public static ObservableCollection<WeeklyGroupListViewModel<Week>> AddList(this ObservableCollection<WeeklyGroupListViewModel<Week>> listReturnTo, List<Week> currentList)
        {
            if (listReturnTo != null)
            {
                listReturnTo.Clear();
                var index = 0;

                var perGroup1 = new WeeklyGroupListViewModel<Week>("Active Weeks");
                perGroup1.Add(currentList[0]);
                listReturnTo.Add(perGroup1);

                var perGroup2 = new WeeklyGroupListViewModel<Week>("Due Weeks");

                for (var i = 1; i < currentList.Count; i++)
                {
                    perGroup2.Add(currentList[i]);
                }  
                listReturnTo.Add(perGroup2);
            }
            return listReturnTo;
        }
    }
}
