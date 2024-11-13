﻿using LunchAPI.Interface;
using LunchAPI.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI.Service
{
    public class EmployeeService : IEmployee
    {
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            SqlConnection connection = ConnectSQL.OpenConnect();
            try
            {
                string strCmd = string.Format($@"SELECT employee_id,
	                                                employee_name,
	                                                employee_nickname,
	                                                department,
	                                                balance,
	                                                role,
                                                    status
                                                 FROM Employee");
                SqlCommand command = new SqlCommand(strCmd, connection);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EmployeeModel employee = new EmployeeModel()
                        {
                            employee_id = dr["employee_id"].ToString(),
                            employee_name = dr["employee_name"].ToString(),
                            employee_nickname = dr["employee_nickname"].ToString(),
                            department = dr["department"].ToString(),
                            role = dr["role"].ToString(),
                            balance = dr["balance"] != DBNull.Value ? Convert.ToInt32(dr["balance"].ToString()) : 0,
                            status = dr["status"] != DBNull.Value ? Convert.ToBoolean(dr["status"].ToString()) : false
                        };
                        employees.Add(employee);
                    }
                    dr.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return employees;
        }
        public List<UserModel> GetUserAD()
        {
            List<UserModel> users = new List<UserModel>();
            SqlConnection connection = ConnectSQL.OpenADConnect();
            try
            {
                string strCmd = string.Format($@"SELECT DISTINCT Name as name ,Department2 as department ,Active as active FROM Sale_User WHERE Active=1 ORDER BY Name");
                SqlCommand command = new SqlCommand(strCmd, connection);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserModel user = new UserModel()
                        {
                            name = dr["name"].ToString(),
                            department = dr["department"].ToString(),
                            active = Convert.ToBoolean(dr["active"].ToString()),
                        };
                        users.Add(user);
                    }
                    dr.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return users;
        }

        public string GetLastEmployee()
        {
            string employee = "EM000";
            SqlConnection connection = ConnectSQL.OpenConnect();
            try
            {
                string strCmd = string.Format($@"SELECT t.employee_id FROM (
                       SELECT RANK() OVER(ORDER BY employee_id DESC) as rank, employee_id FROM Employee
                         ) t
                         WHERE t.rank = 2");
                SqlCommand command = new SqlCommand(strCmd, connection);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employee = dr["employee_id"].ToString();
                    }
                    dr.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return employee;
        }

        public string Insert(EmployeeModel employee)
        {
            try
            {
                string string_command = string.Format($@"
                    INSERT INTO Employee(employee_id,employee_name,employee_nickname,department,balance,role,status)
                    VALUES (@employee_id,@employee_name,@employee_nickname,@department,@balance,@role,@status)");
                using (SqlCommand cmd = new SqlCommand(string_command, ConnectSQL.OpenConnect()))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@employee_id", employee.employee_id);
                    cmd.Parameters.AddWithValue("@employee_name", employee.employee_name);
                    cmd.Parameters.AddWithValue("@employee_nickname", employee.employee_nickname);
                    cmd.Parameters.AddWithValue("@department", employee.department);
                    cmd.Parameters.AddWithValue("@balance", employee.balance);
                    cmd.Parameters.AddWithValue("@role", employee.role);
                    cmd.Parameters.AddWithValue("@status", employee.status);
                    if (ConnectSQL.con.State != System.Data.ConnectionState.Open)
                    {
                        ConnectSQL.CloseConnect();
                        ConnectSQL.OpenConnect();
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (ConnectSQL.con.State == System.Data.ConnectionState.Open)
                {
                    ConnectSQL.CloseConnect();
                }
            }
            return "Success";
        }

        public string UpdateBalance(EmployeeModel employee)
        {
            try
            {
                string string_command = string.Format($@"
                    UPDATE Employee SET balance = @balance
                                        WHERE employee_id = @employee_id");
                using (SqlCommand cmd = new SqlCommand(string_command, ConnectSQL.OpenConnect()))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@employee_id", employee.employee_id);
                    cmd.Parameters.AddWithValue("@balance", employee.balance);
                    if (ConnectSQL.con.State != System.Data.ConnectionState.Open)
                    {
                        ConnectSQL.CloseConnect();
                        ConnectSQL.OpenConnect();
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (ConnectSQL.con.State == System.Data.ConnectionState.Open)
                {
                    ConnectSQL.CloseConnect();
                }
            }
            return "Success";
        }

        public string UpdateRole(EmployeeModel employee)
        {
            try
            {
                string string_command = string.Format($@"
                    UPDATE Employee SET employee_nickname = @employee_nickname,
                                        role = @role
                                        WHERE employee_id = @employee_id");
                using (SqlCommand cmd = new SqlCommand(string_command, ConnectSQL.OpenConnect()))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@employee_id", employee.employee_id);
                    cmd.Parameters.AddWithValue("@employee_nickname", employee.employee_nickname);  
                    cmd.Parameters.AddWithValue("@role", employee.role);
                    if (ConnectSQL.con.State != System.Data.ConnectionState.Open)
                    {
                        ConnectSQL.CloseConnect();
                        ConnectSQL.OpenConnect();
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (ConnectSQL.con.State == System.Data.ConnectionState.Open)
                {
                    ConnectSQL.CloseConnect();
                }
            }
            return "Success";
        }

        public EmployeeModel GetEmployeeCTL()
        {
            EmployeeModel employee = new EmployeeModel();
            SqlConnection connection = ConnectSQL.OpenConnect();
            try
            {
                string strCmd = string.Format($@"SELECT employee_id,
	                                                employee_name,
	                                                employee_nickname,
	                                                department,
	                                                balance,
	                                                role,
                                                    status
                                                 FROM Employee
                                                 WHERE employee_id = 'EM999'");
                SqlCommand command = new SqlCommand(strCmd, connection);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employee = new EmployeeModel()
                        {
                            employee_id = dr["employee_id"].ToString(),
                            employee_name = dr["employee_name"].ToString(),
                            employee_nickname = dr["employee_nickname"].ToString(),
                            department = dr["department"].ToString(),
                            role = dr["role"].ToString(),
                            balance = dr["balance"] != DBNull.Value ? Convert.ToInt32(dr["balance"].ToString()) : 0,
                            status = dr["status"] != DBNull.Value ? Convert.ToBoolean(dr["status"].ToString()) : false
                        };
                    }
                    dr.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return employee;
        }

        public string UpdateStatus(EmployeeModel employee)
        {
            try
            {
                string string_command = string.Format($@"
                    UPDATE Employee SET status = @status
                                        WHERE employee_id = @employee_id");
                using (SqlCommand cmd = new SqlCommand(string_command, ConnectSQL.OpenConnect()))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@employee_id", employee.employee_id);
                    cmd.Parameters.AddWithValue("@status", employee.status);
                    if (ConnectSQL.con.State != System.Data.ConnectionState.Open)
                    {
                        ConnectSQL.CloseConnect();
                        ConnectSQL.OpenConnect();
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (ConnectSQL.con.State == System.Data.ConnectionState.Open)
                {
                    ConnectSQL.CloseConnect();
                }
            }
            return "Success";
        }
    }
}
