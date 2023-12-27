using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLSV_OOP.DTO;
using QLSV_OOP;
using System.Drawing;
using System.Security.Principal;

namespace QLSV_OOP.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }
            private set => instance = value;
        }
        private AccountDAO() { }

        SqlConnection con = new SqlConnection(ConnectionString.connectionString);
        
        public bool Login(string username, string password, string roleid)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tai_khoan WHERE Username ='" + username + "' AND Password='" + password + "' AND MaQuyen= '"+ roleid +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                return true;
                
            }
            else { return false; }
            
        }

        public Account GetAccountByUserName(string userName)
        {
            SqlDataAdapter sa = new SqlDataAdapter("SELECT * FROM tai_khoan WHERE Username = '" + userName + "'", con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public bool UpdatePassword(string username, string oldPassword, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                string query = "UPDATE Account SET Password = @NewPassword WHERE UserName = @UserName AND Password = @OldPassword";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@OldPassword", oldPassword); // Mật khẩu cũ
                command.Parameters.AddWithValue("@NewPassword", newPassword); // Mật khẩu mới

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

    }
}
