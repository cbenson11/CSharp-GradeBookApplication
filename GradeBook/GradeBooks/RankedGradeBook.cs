using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            List<double> gradeList = new List<double>();
            foreach (var student in Students)
            {
                gradeList.Add(student.AverageGrade);
            }
            var descendingOrder = gradeList.OrderByDescending(i => i);
            int indx = 0;
            foreach (var grade in descendingOrder)
            {
                indx++;
                if (grade >= averageGrade)
                {
                    float rank = indx / Students.Count;
                    if (rank <= 0.20)
                        return 'A';
                    else
                    if (rank <= 0.40)
                        return 'B';
                    else
                    if (rank <= 0.60)
                        return 'C';
                    else
                    if (rank <= 0.80)
                        return 'D';
                }
            }
            //return base.GetLetterGrade(averageGrade);
            return 'F';
        }
    }
}
