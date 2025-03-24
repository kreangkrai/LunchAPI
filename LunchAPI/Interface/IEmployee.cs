using LunchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Interface
{
    public interface IEmployee
    {
        List<EmployeeModel> GetEmployees();
        List<UserModel> GetUserAD();
        string GetLastEmployee();
        string Insert(EmployeeModel employee);
        string UpdateRole(EmployeeModel employee);
        string UpdateBalance(EmployeeModel employee);
        string UpdateStatus(EmployeeModel employee);
        string UpdateNotify(EmployeeModel employee);
        EmployeeModel GetEmployeeCTL();
    }
}
