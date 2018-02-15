using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubSandwich.Service.RequestProvider
{
    public interface IRequestProvider
    {
        Task<GraphResult<T>> Query<T>(string query);
    }
}
