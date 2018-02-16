using ClubSandwich.Model;
using ClubSandwich.Service.RequestProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubSandwich.Service.Query
{
    public class UserQuery
    {
        private readonly IRequestProvider _requestProvider;
        public UserQuery()
        {
            _requestProvider = new RequestProvider.RequestProvider();
        }

        public async Task<GraphResult<UserQueryModel>> GetAllUsers()
        {
            var query = @"query {
                            users {
                            userId
                            firstName
                            lastName
                            facebookId
                            email
                            avatarUrl
                            shopper
                            bankDetails
                            phoneNumber
                            bankName
                            firstLogin
                            totalCost
                            totalPaid
                            totalOwed
                          }
                        }
                        ";

            return await _requestProvider.Query<UserQueryModel>(query);
        }
    }
}
