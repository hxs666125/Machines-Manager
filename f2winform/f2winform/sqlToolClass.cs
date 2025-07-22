using AntdUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace f2winform
{
    internal static class sqlToolClass
    {
        public enum BorrowedStates{//借用状态枚举变量
            Yes = 1,
            No = 0
        };
        public static DataTable SearchAll(SqlConnection connection) // 所有仪器仪表展示
        {
            // 不使用 using 包裹传入的 connection，会导致关闭连接
            var adapter = new SqlDataAdapter(
                "SELECT * FROM Table_Total", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt); // 使用已经打开的 connection
            return dt;
        }


        public static DataTable SearchByName(string name, SqlConnection connection)//仪表仪器名搜索
        {
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total WHERE name LIKE @name", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@name", $"%{name}%");//查询参数定义
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable SearchById(string id, SqlConnection connection)//仪表仪器id搜索
        {
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total WHERE id = @id", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@id", $"{id}");//查询参数定义
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable SearchByBorrowed(string Borrowed, SqlConnection connection)//借出状态搜索
        {
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total WHERE borrowed = @Borrowed", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Borrowed", $"{Borrowed}");//查询参数定义
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable SearchByRp(string Rp, SqlConnection connection)//借出状态搜索
        {
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total WHERE repairing = @Rp", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Rp", $"{Rp}");//查询参数定义
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable SearchByPn(string Pname_br, SqlConnection connection)//借用者名搜索
        {
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total WHERE pname_br LIKE @Pname_br", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Pname_br", $"%{Pname_br}%");//查询参数定义
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable ChangeBr(string Id,string ColName, string @NewValue ,SqlConnection connection)
        {//id搜索更新某一列数据
            var updater = new SqlCommand($"UPDATE Table_Total SET {ColName} = @newValue WHERE id = @Id", connection);
            updater.Parameters.AddWithValue("@Id", $"{Id}");//查询参数定义
            updater.Parameters.AddWithValue("@NewValue", $"{@NewValue}");//查询参数定义
            updater.ExecuteNonQuery();
            
            //再查询
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        //id搜索删除某一列数据
        public static DataTable DeleteRow(string id,SqlConnection connection)
        {
            
            // 删除行并重排后续ID（同一事务内完成）
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    // 1. 删除目标行
                    var deleteCmd = new SqlCommand("DELETE FROM Table_Total WHERE id = @id", connection, transaction);
                    deleteCmd.Parameters.AddWithValue("@id", id);
                    deleteCmd.ExecuteNonQuery();

                    // 2. 批量更新后续行（单条SQL完成）
                    var updateCmd = new SqlCommand(
                        "UPDATE Table_Total SET id = id - 1 WHERE id > @id",
                        connection, transaction
                    );
                    updateCmd.Parameters.AddWithValue("@id", id);
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit(); // 提交事务
                }
                catch
                {
                    MessageBox.Show("删除失败");
                    transaction.Rollback(); // 失败回滚
                    throw;
                }
            }

            //再查询
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        
        public static DataTable ChangeNb(string id, string name, string borrowed, string repairing,string pname_br, SqlConnection connection)
        {
            var updater = new SqlCommand($"INSERT INTO Table_Total (id, name, borrowed, repairing, pname_br) VALUES (@id, @name, @borrowed, @repairing, @pname_br)",  connection);
            updater.Parameters.AddWithValue("@id", $"{id}");//查询参数定义
            updater.Parameters.AddWithValue("@name", $"{name}");//查询参数定义
            updater.Parameters.AddWithValue("@borrowed", $"{borrowed}");//查询参数定义
            updater.Parameters.AddWithValue("@repairing", $"{repairing}");//查询参数定义
            updater.Parameters.AddWithValue("@pname_br", $"{pname_br}");//查询参数定义
            updater.ExecuteNonQuery();

            //再查询
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        //表格修改同步测试1
        public static void UpDataTable(DataTable dt, SqlConnection connection)
        {
            try
            {
                using (var transaction = connection.BeginTransaction())
                {
                    new SqlCommand($"DELETE FROM {dt.TableName}", connection, transaction)
                       .ExecuteNonQuery();

                    var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction)
                    { DestinationTableName = dt.TableName };

                    bulkCopy.WriteToServer(dt);
                    transaction.Commit(); // 成功则提交
                    
                }
                // 失败时自动回滚
            }
            catch (SqlException error)
            {
                MessageBox.Show($"{error}");
            }
        }

        //表格修改同步测试2

        public static bool UpdateDT(DataTable newDT, string queryString, SqlConnection connection)
        {

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(queryString, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                adapter.Update(newDT);

                return true;
            }
            catch (Exception e)
            {
                connection.Close();
                MessageBox.Show(e.Message );
                return false;
            }
        }

        //表格修改同步测试3(可行！！！)
        public static DataTable UpCell(TableEndEditEventArgs e,string id,string ColName,string NewValue, SqlConnection connection)
        {
            //禁止修改id号，id由系统生成
            if (e.Column.Title == "id") {
                MessageBox.Show("禁止修改id号，id由系统生成!!!");
                return null;
            }

            //id搜索更新某一列数据
            var updater = new SqlCommand($"UPDATE Table_Total SET {ColName} = @newValue WHERE id = @Id", connection);
            updater.Parameters.AddWithValue("@Id", $"{id}");//查询参数定义
            updater.Parameters.AddWithValue("@NewValue", $"{@NewValue}");//查询参数定义
            updater.ExecuteNonQuery();

            //再查询
            var adapter = new SqlDataAdapter("SELECT * FROM Table_Total", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        //统计表内数据条数
        public static int GetNum(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Table_Total", connection);
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
