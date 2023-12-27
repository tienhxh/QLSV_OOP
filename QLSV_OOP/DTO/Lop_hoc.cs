using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_OOP.DTO
{
    public class Lop_hoc
    {
        public Lop_hoc(string classID, string subjectID, int time, int numberSV)
        {
            this.ClassID = classID;
            this.SubjectID = subjectID;
            this.Time = time;
            this.NumberSV = numberSV;
        }
        public Lop_hoc(DataRow row)
        {
            this.ClassID = row["MaLH"].ToString();
            this.SubjectID = row["MaHP"].ToString();
            this.Time = (int)row["ThoiGian"];
            this.NumberSV = (int)row["SoLuong"];
        }

        private string classID;

        public string ClassID
        {
            get { return classID; }
            set { classID = value; }
        }

        private string subjectID;

        public string SubjectID
        {
            get { return subjectID; }
            set { subjectID = value; }
        }

        private int time;

        public int Time
        {
            get { return time; }
            set { time = value; }
        }

        private int numberSV;

        public int NumberSV
        {
            get { return numberSV; }
            set { numberSV = value; }
        }
    }
}
