using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DBConnect
{
    private static string connStr = @"Data Source=HAIDANG;Initial Catalog=QLTC_DaoHaiDang_12524_W1;User ID=sa;Password=daohaidang916;Encrypt=False";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connStr);
    }

    public static DataTable ExecuteQuery(string spName, SqlParameter[] parameters)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = GetConnection())
        {
            SqlCommand cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    public static int ExecuteNonQuery(string spName, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return cmd.ExecuteNonQuery();
        }
    }
}
