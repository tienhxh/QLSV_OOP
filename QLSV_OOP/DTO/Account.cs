using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLSV_OOP.DTO
{
    public class Account
    {
        public Account(string userName, string userid, string roleid, string password = null)
        {
            this.UserName = userName;
            this.UserID = userid;
            this.RoleID = roleid;
            this.Password = password;
        }
        public Account(DataRow row)
        {
            this.UserName = row["TDN"].ToString();
            this.UserID = row["MaDD"].ToString();
            this.RoleID = row["MaQuyen"].ToString();
            this.Password = row["MK"].ToString();
        }
        private string roleID;

        public string RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
