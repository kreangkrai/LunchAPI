﻿using LunchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Interface
{
    public interface ITransaction
    {
        List<TransactionModel> GetTransactions();
        List<TransactionModel> GetTransactionByEmployee(string employee_id);
        List<TransactionModel> GetTransactionByDate(DateTime date);
        List<TransactionModel> GetTransactionByMonth(string month);
        string Insert(TransactionModel transaction);

    }
}
