using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace UN.Core.DB
{
   
    public class SugarDb
    {
        public static string ConnectionString = "Data Source=.;Initial Catalog = UN; User ID = sa; Password=840527";
        public static SqlSugarClient GetDbInstance()
        {
            try
            {
                SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = ConnectionString, //必填
                    DbType = DbType.SqlServer, //必填
                    IsAutoCloseConnection = true, //默认false
                    InitKeyType = InitKeyType.SystemTable

                });
                /*db.Ado.IsEnableLogEvent = true;
                db.QueryFilter.Add(new SqlFilterItem()//单表全局过滤器
                {

                    FilterValue = filterDb =>
                    {
                        return new SqlFilterResult() { Sql = " IsDel<1" };
                    },
                    IsJoinQuery = false
                });

                db.Ado.LogEventStarting = (sql, pars) =>
                {
                    Tool.xExcelSqlTxtLog(sql);
                };*/
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库出错，请检查您的连接字符串，和网络。 ex:"+(ex.Message));
            }
        }
    }
}
