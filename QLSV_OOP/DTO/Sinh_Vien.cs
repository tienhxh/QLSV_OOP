using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV_OOP.DTO
{
    public class Sinh_Vien
    {
        public Sinh_Vien(string fullName, string studentID, string userID, int khoa, string queQuan, string sdt, DateTime? ngaySinh)
        {
            this.FullName = fullName;
            this.StudentID = studentID;
            this.UserID = userID;
            this.Khoa = khoa;   
            this.QueQuan = queQuan;
            this.SDT = sdt;
            this.NgaySinh = ngaySinh;
            
        }
        public Sinh_Vien(DataRow row)
        {
            this.FullName = row["TenSV"].ToString();
            this.StudentID = row["MaSV"].ToString();
            this.UserID = row["MaDD"].ToString();
            this.Khoa = (int)row["Khoa"];
            this.QueQuan = row["Que"].ToString();
            this.SDT = row["SDT"].ToString();
            this.NgaySinh = (DateTime?)row["NgaySinh"];
        }
        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string studentID;

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        private string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private int khoa;

        public int Khoa
        {
            get { return khoa; }
            set { khoa = value; }
        }

        private string queQuan;

        public string QueQuan
        {
            get { return queQuan; }
            set { queQuan = value; }
        }

        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private DateTime? ngaySinh;

        public DateTime? NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
    }
}
