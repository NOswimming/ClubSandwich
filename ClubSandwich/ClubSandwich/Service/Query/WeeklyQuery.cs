using ClubSandwich.Service.RequestProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubSandwich.Service.Query
{
    public class WeeklyQuery
    {
        private readonly IRequestProvider _requestProvider;
        public WeeklyQuery()
        {
            _requestProvider = new RequestProvider.RequestProvider();
        }

        public async Task<GraphResult<QueryModel>> ExpenseAccounts()
        {
            var query = @"query {
                                me{
                                    userId
                                  totalCost
                                  totalPaid
                                  __typename
                                }primaryShopper{
                                    userId
                                firstName
                                bankDetails
                                bankName
                                __typename
                                }weeks{
                                    weekId
                                cost
                                costPerUser
                                users{
                                        weekId
                                  userId
                                  slices
                                  paid
                                  user{
                                            userId
                                    firstName
                                    lastName
                                    avatarUrl
                                    __typename
                                        }__typename
                                    }shopper{
                                        userId
                                  firstName
                                  lastName
                                  avatarUrl
                                  __typename
                                    }__typename
                                }
                            }";

            return await _requestProvider.Query<QueryModel>(query);
        }
    }


}
