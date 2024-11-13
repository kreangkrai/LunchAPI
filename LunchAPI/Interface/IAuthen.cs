using LunchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Interface
{
    public interface IAuthen
    {
        AuthenModel ActiveDirectoryAuthenticate(string username, string password);
    }
}
