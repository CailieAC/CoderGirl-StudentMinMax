using System;
using System.Collections.Generic;
using System.IO;

namespace StudentMinMax
{
    public class Program
    {
        //values for the student class are populated from the included studentdata.txt file. 
        //The student’s name is the first thing on each line, followed by some exam scores. 
        //The number of scores might be different for each student.  
        //The program should calculate the minimum and maximum score for each student and print out their name as well.
        public static void Main()
        {
            List<Student> studentList = CreateStudentList();

            foreach (var student in studentList)
            {
                Console.WriteLine($"{student.Name} Min: {student.GetMinimumScore()} Max: {student.GetMaximumScore()}");
            }

            Console.ReadLine();
        }

        private static List<Student> CreateStudentList()
        {
            List<Student> studentList = new List<Student>();
            
            foreach (string line in File.ReadLines(@"C:\Users\Cailie\Documents\Visual Studio 2017\Projects\CailieAC\CoderGirl-StudentMinMax\studentdata.txt"))
            {
                Student student = CreateStudent(line);
                studentList.Add(student);
            }
            return studentList;
        }

        private static Student CreateStudent(string line)
        {
            Student student = new Student();
            string[] properties = line.Split(" ");
            int[] scores = new int[properties.Length - 1];
            student.Name = properties[0];

            for (int i = 1; i < properties.Length; i++)
            {
                scores[i-1] = int.Parse(properties[i]);
            }
            student.Scores = scores;
            return student;
        }
    }
}