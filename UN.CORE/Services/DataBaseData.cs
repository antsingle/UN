﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UN.Core.Services
{
    public class DataBaseData
    {
        public static DataTable GetDataBaseData()
        {
            //连接数据库字符串
            string strConn = "Data Source=.;Initial Catalog=UN;User ID=sa;Password=840527";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    //连接数据库
                    conn.Open();
                    //查询数据库语句
                    string commandStr = "select * from Cells";
                    //要对数据源执行的 SQL 语句或存储过程
                    SqlCommand sqlCmd = new SqlCommand(commandStr, conn);
                    //表示一组数据命令和一个数据库连接，它们用于填充 System.Data.DataSet 和更新数据源。
                    SqlDataAdapter sqlDataAda = new SqlDataAdapter(sqlCmd);
                    //数据的内存中缓存

                    //将获取到的数据填充到数据缓存中
                    sqlDataAda.Fill(dt);

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                return dt;
            }
        }
    }
}
