using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using LuckyDraw.Models;
using LuckyDraw.Exceptions;
using System.Data.SqlClient;

namespace LuckyDraw
{
    public class ADO
    {
        public static ADO ado;
        public static ADO GetEntity()
        {
            if (ado == null)
            {
                ado = new ADO();
            }
            return ado;
        }
        OleDbConnection oleConnection;

        public ADO()
        {
            InitIDbConnection();
        }

        private void InitIDbConnection()
        {
            string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=D:\android\workspace\LuckyDraw\adraw.mdb;" + "User Id=admin;Password=;";
            oleConnection = new OleDbConnection(strConnection);
        }

        private void ConnectionOpen()
        {
            try
            {
                oleConnection.Open();
            }
            catch (Exception ex)
            {
                throw new ADOException() { msg = "打开数据库连接失败" };
            }
        }

        private void ConnectionClosed()
        {
            try
            {
                oleConnection.Close();
            }
            catch (Exception ex)
            {
                throw new ADOException() { msg = "关闭数据库连接失败" };
            }
        }

        #region ADO for User

        public int DataInsert(User user)
        {
            ConnectionOpen();
            string sql = "insert into User(UserID,UserName,UserRole,Assigned,LuckyDog,IsLuckyDog) Values(" + user.UserID + "," + user.UserName + "," + user.UserRole + "," + user.Assigned + "," + user.LuckyDog + "," + user.IsLuckyDog + ")";
            OleDbCommand cmd = new OleDbCommand(sql, oleConnection);
            int result;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ADOException() { msg = "数据插入失败失败" };
            }
            finally
            {
                ConnectionClosed();
            }
            return result;
        }

        public int DataUpdate(User user)
        {
            ConnectionOpen();

            string sql = "update [User] set ";
            sql = (user.UserID == "") ? sql : sql + " UserID = '" + user.UserID+"'";
            sql = (user.UserName == "") ? sql : sql + ",UserName = '" + user.UserName + "'";
            sql = (user.UserRole == "") ? sql : sql + ",UserRole = '" + user.UserRole + "'";
            sql = (user.Assigned == "") ? sql : sql + ",Assigned = '" + user.Assigned + "'";
            sql = (user.LuckyDog == "") ? sql : sql + ",LuckyDog = '" + user.LuckyDog + "'";
            sql = (user.IsLuckyDog == 0) ? sql : sql + ",IsLuckyDog = " + user.IsLuckyDog;
            sql = sql + " where ID = " + user.ID;
            OleDbCommand cmd = new OleDbCommand(sql, oleConnection);
            int result;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ADOException() { msg = "数据更新失败" };
            }
            finally
            {
                ConnectionClosed();
            }
            return result;
        }

        public List<User> DataMultipleSelect(string sql)
        {
            List<User> users = new List<User>();
            ConnectionOpen();
            OleDbDataAdapter oleDA = new OleDbDataAdapter(sql, oleConnection);
            DataSet ds = new DataSet();
            try
            {
                oleDA.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    User user = new User();
                    user.ID = Convert.ToInt32(row["ID"]);
                    user.UserID = row["UserID"].ToString();
                    user.UserName = row["UserName"].ToString();
                    user.UserRole = row["UserRole"].ToString();
                    user.Assigned = row["Assigned"].ToString();
                    user.LuckyDog = row["LuckyDog"].ToString();
                    user.IsLuckyDog = Convert.ToInt32(row["IsLuckyDog"]);
                    users.Add(user);
                }

            }
            catch (Exception ex)
            {
                new ADOException() { msg = "数据检索失败" };
            }
            finally
            {
                ConnectionClosed();
            }
            return users;
        }

        public User DataSingleSelect(string sql)
        {
            ConnectionOpen();
            OleDbCommand cmd = new OleDbCommand(sql, oleConnection);
            User user = new User();
            try
            {
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.ID = Convert.ToInt32(reader["ID"]);
                    user.UserID = reader["UserID"].ToString();
                    user.UserName = reader["UserName"].ToString();
                    user.UserRole = reader["UserRole"].ToString();
                    user.Assigned = reader["Assigned"].ToString();
                    user.LuckyDog = reader["LuckyDog"].ToString();
                    user.IsLuckyDog = Convert.ToInt32(reader["IsLuckyDog"]);
                }
            }
            catch (Exception ex)
            {
                new ADOException() { msg = "数据检索失败" };
            }
            finally
            {
                ConnectionClosed();
            }
            return user;
        }

        #endregion

        #region ADO for Award

        public List<Award> DataGetAwards(string sql)
        {
            List<Award> awards = new List<Award>();
            ConnectionOpen();
            OleDbDataAdapter oleDA = new OleDbDataAdapter(sql, oleConnection);
            DataSet ds = new DataSet();
            try
            {
                oleDA.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Award award = new Award();
                    award.ID = Convert.ToInt32(row["ID"]);
                    award.AwardName = row["AwardName"].ToString();
                    award.AwardType= row["AwardType"].ToString();
                    award.AwardNumber = Convert.ToInt32(row["AwardNumber"]);
                    awards.Add(award);
                }

            }
            catch (Exception ex)
            {
                new ADOException() { msg = "奖项数据检索失败" };
            }
            finally
            {
                ConnectionClosed();
            }
            return awards;
        }

        public int DataUpdateAward(Award award)
        {
            ConnectionOpen();

            string sql = "update [Award] set ";
            sql = (award.AwardName == "") ? sql : sql + " AwardName = '" + award.AwardName + "'";
            sql = (award.AwardType == "") ? sql : sql + ",AwardType = '" + award.AwardType + "'";
            sql = sql + ",AwardNumber = " + award.AwardNumber;
            sql = sql + " where ID = " + award.ID;
            OleDbCommand cmd = new OleDbCommand(sql, oleConnection);
            int result;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ADOException() { msg = "奖项数据更新失败，不可关闭软件" };
            }
            finally
            {
                ConnectionClosed();
            }
            return result;
        }

        #endregion
    }
}
