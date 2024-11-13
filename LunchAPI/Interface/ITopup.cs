using LunchAPI.Models;
using System.Collections.Generic;

namespace LunchAPI.Interface
{
    public interface ITopup
    {
        List<TopupModel> GetTopups();
        List<TopupModel> GetTopupByEmployee(string employee_id);
        string Insert(TopupModel model);
        string UpdateStatus(TopupModel model);
    }
}
