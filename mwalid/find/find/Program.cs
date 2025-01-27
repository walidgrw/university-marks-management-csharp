using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create a new student record");
            Console.WriteLine("2. Enter marks for a student record");
            Console.WriteLine("3. Update a student's marks");
            Console.WriteLine("4. Show a student record");
            Console.WriteLine("5. Quit the program");
            Console.Write("Enter your choice (1-5): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateStudentRecord();
                        break;
                    case 2:
                        EnterStudentMarks();
                        break;
                    case 3:
                        UpdateStudentMarks();
                        break;
                    case 4:
                        ShowStudentRecord();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Incorrect. Please enter 1-5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void CreateStudentRecord()
    {

        Console.WriteLine("Creating a new student record...");
        int iStudentNumber = new Random().Next(10000000, 99999999);
        Console.WriteLine("Your new student number: " + iStudentNumber);
        Console.Write("Enter the student's name: ");
        string sStudentName = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(iStudentNumber + ".txt", true))
        {
            sw.WriteLine("Student Number: " + iStudentNumber);
            sw.WriteLine("Student Name: " + sStudentName);
            
        }

        Console.WriteLine("Student record created and saved.");
    }

    static void EnterStudentMarks()
    {
        Console.WriteLine("Entering marks for a student...");
        Console.Write("Enter the student number: ");

        if (int.TryParse(Console.ReadLine(), out int iStudentNumber))
        {
            string filePath = iStudentNumber + ".txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                int iStudentIndex = -1;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("Student Number: " + iStudentNumber))
                    {
                        iStudentIndex = i;
                        break;
                    }
                }

                if (iStudentIndex != -1)
                {
                    StudentRecord studentRecord = new StudentRecord(iStudentNumber, "");
                    for (int i = 0; i < 6; i++)
                    {
                        while (true)  // Keep prompting until a valid mark is entered
                        {
                            Console.Write("Enter the mark for assignment " + (i + 1) + " (0-100): ");
                            string markInput = Console.ReadLine();
                            if (double.TryParse(markInput, out double mark))
                            {
                                if (mark >= 0 && mark <= 100)
                                {
                                    studentRecord.Marks[i] = mark;
                                    break;  // Exit the loop if a valid mark is entered
                                }
                                else
                                {
                                    Console.WriteLine("Invalid mark. Marks must be between 0 and 100. Try again.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a number. Try again.");
                            }
                        }
                    }

                    studentRecord.SaveToFile2();

                    Console.WriteLine("Marks successfully saved. Student " + studentRecord.GetResult() +
                                      " with an average of " + studentRecord.CalculateAverageMark());
                }
                else
                {
                    Console.WriteLine("Student record not found.");
                }
            }
            else
            {
                Console.WriteLine("File for student number " + iStudentNumber + " does not exist.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }


    static void UpdateStudentMarks()
    {
        Console.WriteLine("Updating a student's marks...");
        Console.Write("Enter the student number: ");
        int iStudentNumber;
        if (int.TryParse(Console.ReadLine(), out iStudentNumber))
        {
            string[] lines = File.ReadAllLines(iStudentNumber + ".txt");
            int studentIndex = -1;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Student Number: " + iStudentNumber))
                {
                    studentIndex = i;
                    break;
                }
            }

            if (studentIndex != -1)
            {
                StudentRecord studentRecord = new StudentRecord(iStudentNumber, "");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("Enter the new mark for assignment " + (i + 1) + " (0-100): ");
                    string markInput = Console.ReadLine();
                    if (double.TryParse(markInput, out double mark))
                    {
                        if (mark >= 0 && mark <= 100)
                        {
                            studentRecord.Marks[i] = mark;
                        }
                        else
                        {
                            Console.WriteLine("Invalid mark. Marks must be between 0 and 100. Aborting.");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        return;
                    }
                }

                studentRecord.SaveToFile2();

                Console.WriteLine("Marks successfully updated. Student " + studentRecord.GetResult() +
                                  " with an average of " + studentRecord.CalculateAverageMark());
            }
            else
            {
                Console.WriteLine("Student record not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    static void ShowStudentRecord()
    {
        Console.WriteLine("Showing a student record...");
        Console.Write("Enter the student number: ");
        if (int.TryParse(Console.ReadLine(), out int iStudentNumber))
        {
            string[] lines = File.ReadAllLines(iStudentNumber + ".txt");

            // Find all occurrences of the student number
            var studentIndices = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Student Number: " + iStudentNumber))
                {
                    studentIndices.Add(i);
                }
            }

            if (studentIndices.Count > 0)
            {
                foreach (var studentIndex in studentIndices)
                {
                    // Create a new StudentRecord object for each iteration
                    StudentRecord studentRecord = new StudentRecord(iStudentNumber, "");

                    // Skip lines until "Marks:"
                    int marksStartIndex = Array.IndexOf(lines, "Marks:", studentIndex);

                    if (marksStartIndex != -1)
                    {
                        // Skip "Marks:" line
                        marksStartIndex++;

                        // Read the marks (6 marks)
                        for (int i = 0; i < 6; i++)
                        {
                            if (double.TryParse(lines[marksStartIndex + i], out double mark))
                            {
                                studentRecord.Marks[i] = mark;
                            }
                            else
                            {
                                Console.WriteLine("Invalid mark format in the file.");
                                return;
                            }
                        }

                        // Output student information after reading marks
                        Console.WriteLine("Student Number: " + studentRecord.iStudentNumber);
                        Console.WriteLine("Student Name: " + studentRecord.sStudentName);
                        Console.WriteLine("Marks:");
                        foreach (var mark in studentRecord.Marks)
                        {
                            Console.WriteLine(mark);
                        }
                        Console.WriteLine("Average Mark: " + studentRecord.CalculateAverageMark());
                        Console.WriteLine("Result: " + studentRecord.GetResult());
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Marks not found for the student.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Student record not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}