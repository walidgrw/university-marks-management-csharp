using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StudentRecord
{
     public int iStudentNumber { get; set; }
     public string sStudentName { get; set; }
     public double[] Marks { get; set; }

      public StudentRecord(int studentNumber, string studentName)
      {
         iStudentNumber = studentNumber;
         sStudentName = studentName;
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

      
      public void SaveToFile2()
      {
        
        using (StreamWriter sw = new StreamWriter(iStudentNumber+".txt",true))
        {
            sw.WriteLine("Student Number: " + iStudentNumber);
            sw.WriteLine("Student Name: " + sStudentName);
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

