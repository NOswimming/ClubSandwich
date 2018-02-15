using ClubSandwich.Service.RequestProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubSandwich.Service.Query
{
    public class ShoppingQuery
    {
        private readonly IRequestProvider _requestProvider;
        public ShoppingQuery()
        {
            _requestProvider = new RequestProvider.RequestProvider();
        }

        public async Task<GraphResult<ShoppingQueryModel>> Get()
        {
            var query = @"query{
                              me {
                                userId
                                firstName
                                lastName
                                __typename
                              }
                              primaryShopper {
                                userId
                                firstName
                                lastName
                                __typename
                              }
                              weeks {
                                weekId
                                cost
                                users {
                                  weekId
                                  userId
                                  slices
                                  paid
                                  user {
                                    userId
                                    firstName
                                    lastName
                                    avatarUrl
                                    __typename
                                  }
                                  __typename
                                }
                                shopper {
                                  userId
                                  firstName
                                  lastName
                                  __typename
                                }
                                __typename
                              }
                              users {
                                userId
                                firstName
                                lastName
                                avatarUrl
                                totalCost
                                totalPaid
                                __typename
                              }
                            }";

            return await _requestProvider.Query<ShoppingQueryModel>(query);
        }
    }


}
