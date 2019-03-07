using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProblems
{
    public class Student
    {
        public int StudentID;
        public double MathGrade;
        public double EnglishGrade;
        public double ScienceGrade;
        public double HistoryGrade;

        public Student(int ID, double math, double english, double science, double history)
        {
            StudentID = ID;
            MathGrade = math;
            EnglishGrade = english;
            ScienceGrade = science;
            HistoryGrade = history;
        }
    }
}
