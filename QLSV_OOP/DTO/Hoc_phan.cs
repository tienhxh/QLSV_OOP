using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_OOP.DTO
{
    public class Hoc_phan
    {
        public Hoc_phan(string subjectID, string subjectName, int numberPeriod)
        {
            this.SubjectID = SubjectID;
            this.SubjectName = subjectName;
            this.NumberPeriod = numberPeriod;
        }
        public Hoc_phan(DataRow row)
        {
            this.SubjectID = row["MaHP"].ToString();
            this.SubjectName = row["TenHP"].ToString();
            this.NumberPeriod = (int)row["KhoiLuong"];
        }

        private string subjectID;

        public string SubjectID
        {
            get { return subjectID; }
            set { subjectID = value; }
        }

        private string subjectName;

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        private int numberPeriod;

        public int NumberPeriod
        {
            get { return numberPeriod; }
            set { numberPeriod = value; }
        }

    }
}
