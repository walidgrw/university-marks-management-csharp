using System.IO;

namespace find
{
    class StudentRecord
    {
        public int StudentNumber { get; set; }
        public string StudentName { get; set; }
        public double[] Marks { get; set; }

        public StudentRecord(int iStudentNumber, string sStudentName)
        {
            StudentNumber = iStudentNumber;
            StudentName = sStudentName;
            Marks = new double[6];
        }

        public double CalculateAverageMark()
        {
            double sum = 0;
            foreach (var mark in Marks)
            {
                sum += mark;
            }
            return sum / Marks.Length;
        }

        public string GetResult()
        {
            double averageMark = CalculateAverageMark();
            return averageMark >= 40 ? "Passed" : "Failed";
        }

        public void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter("StudentData.txt", true))
            {
                sw.WriteLine("Student Number: " + StudentNumber);
                sw.WriteLine("Student Name: " + StudentName);
                sw.WriteLine("Marks:");
                foreach (var mark in Marks)
                {
                    sw.WriteLine(mark);
                }
                sw.WriteLine("Average Mark: " + CalculateAverageMark());
                sw.WriteLine("Result: " + GetResult());
                sw.WriteLine();
            }
        }
    }
}
