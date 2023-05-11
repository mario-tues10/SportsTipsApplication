﻿using DataManagement.Interfaces;
using DataManagement.Entities;
using System.Data.SqlClient;
namespace DataManagement
{
    public class TipsterRepository : UserRepository, IUserRepository
    {
        public TipsterRepository(SqlService sqlService) : base(sqlService)
        {
        }
        public new void InsertIntoAccount(User tipster)
        {
            base.InsertIntoAccount(tipster);
            Tipster realTipster = (Tipster)tipster;
            string query = $"insert into [Tipster](tipster_id, specialty, successRate, suspended) " +
                $"values(@TipsterId, @Specialty, @SuccessRate, @Suspended)";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@TipsterId", realTipster.GetId());
            sqlCommand.Parameters.AddWithValue("@Specialty", realTipster.Specialty.ToString());
            sqlCommand.Parameters.AddWithValue("@SuccessRate", realTipster.SuccessRate);
            sqlCommand.Parameters.AddWithValue("@Suspended", 0);
            sqlService.OperateTable(sqlCommand);
        }
        public void DeleteIntoTipster(User tipster)
        {
            string query = $"delete from [Tipster] where id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("@Id", tipster.GetId());
            sqlService.OperateTable(sqlCommand);
            base.DeleteIntoAccount(tipster);
        }
        public new Tipster? GetAccountById(int id)
        {
            Tipster? tipster = null;
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                try
                {
                    string query = $"select * from [User] inner join [Tipster] on [User].id = [Tipster].tipster_id" +
                        $" where id = @Id";
                    SqlCommand sqlCommand = new SqlCommand(query);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    SqlDataReader? reader = base.sqlService.ReadFromTable(sqlCommand, sqlConnection);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetString(1);
                            string email = reader.GetString(2);
                            string password = reader.GetString(3);
                            UserRole userRole = Enum.Parse<UserRole>(reader.GetString(4));
                            Sport specialty = Enum.Parse<Sport>(reader.GetString(6));
                            decimal successRate = reader.GetDecimal(7);
                            bool suspended = Convert.ToBoolean(reader.GetByte(8));
                            tipster = new Tipster(username, email, password, userRole, specialty, successRate, suspended);
                            tipster.SetId(id);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return tipster;
        }
        public new List<Tipster>? GetAllAccounts()
        {
            List<Tipster>? result = new List<Tipster>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                string query = $"select * from [User] inner join [Tipster] on [Tipster].tipster_id = [User].id";
                SqlCommand sqlCommand = new SqlCommand(query);
                SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string username = reader.GetString(1);
                            string email = reader.GetString(2);
                            string password = reader.GetString(3);
                            UserRole userRole = Enum.Parse<UserRole>(reader.GetString(4));
                            Sport specialty = Enum.Parse<Sport>(reader.GetString(6));
                            decimal successRate = reader.GetDecimal(7);
                            bool suspended = Convert.ToBoolean(reader.GetByte(8));
                            Tipster tipster = new Tipster(username, email, password, userRole, specialty, successRate, suspended);
                            tipster.SetId(id);
                            result.Add(tipster);
                        }
                    }
                    return result;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
        }
        public List<Prediction>? GetTipsterPredictions(Tipster tipster)
        {
            List<Prediction>? result = new List<Prediction>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlService.connectionString))
            {
                string query = $"select * from [Prediction] where tipster_id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Id", tipster.GetId());
                SqlDataReader? reader = sqlService.ReadFromTable(sqlCommand, sqlConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string analyze = reader.GetString(1);
                            string finalPrediction = reader.GetString(2);
                            int matchId = reader.GetInt32(3);
                            int tipsterId = reader.GetInt32(4);
                            Prediction prediction = new Prediction(analyze, finalPrediction, tipsterId, matchId);
                            prediction.SetId(id);
                            result.Add(prediction);
                        }

                    }

                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return result;
        }
    
    }
}