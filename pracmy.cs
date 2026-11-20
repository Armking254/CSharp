using System;

namespace StudentAndTeaFarmerSystem
{
    // TASK 1: Student Marks Analysis
    class Student
    {
        public string Name { get; set; } = "";
        public double[] Marks { get; set; } = new double[5];
        public double Total { get; private set; }
        public double Average { get; private set; }
        public string Grade { get; private set; } = "";

        public void InputDetails(int studentNumber)
        {
            Console.WriteLine($"\nSTUDENT {studentNumber}");
            Console.Write("Enter student name: ");
            Name = Console.ReadLine() ?? "";

            string[] subjects =
            {
                "Mathematics",
                "English",
                "Computer Studies",
                "Communication Skills",
                "Entrepreneurship"
            };

            Total = 0;

            for (int i = 0; i < Marks.Length; i++)
            {
                Marks[i] = ReadMark(subjects[i]);
                Total += Marks[i];
            }

            CalculateAverage();
            AssignGrade();
        }

        private double ReadMark(string subject)
        {
            while (true)
            {
                Console.Write($"Enter marks for {subject} (0-100): ");

                if (double.TryParse(Console.ReadLine(), out double mark)
                    && mark >= 0 && mark <= 100)
                {
                    return mark;
                }

                Console.WriteLine("Invalid input. Enter a number between 0 and 100.");
            }
        }

        private void CalculateAverage()
        {
            Average = Total / Marks.Length;
        }

        private void AssignGrade()
        {
            // Example grading scale. Use your lecturer's scale if different.
            if (Average >= 80)
                Grade = "A";
            else if (Average >= 70)
                Grade = "B";
            else if (Average >= 60)
                Grade = "C";
            else if (Average >= 50)
                Grade = "D";
            else
                Grade = "E";
        }

        public void DisplayResults()
        {
            Console.WriteLine(
                "{0,-22} {1,10:F2} {2,12:F2} {3,8}",
                Name, Total, Average, Grade);
        }
    }

    class Program
    {
        static void Main()
        {
            Student student = new Student();
            student.InputDetails(1);

            Console.WriteLine("\nRESULTS");
            Console.WriteLine(
                "{0,-22} {1,10} {2,12} {3,8}",
                "Name", "Total", "Average", "Grade");
            student.DisplayResults();
        }
    }
}
