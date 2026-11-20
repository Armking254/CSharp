using System;
using System.Collections.Generic;

/// <summary>
/// Stores one student's subjects and marks and calculates academic results.
/// </summary>
public class StudentRecord
{
    public string Name { get; set; } = string.Empty;
    public List<string> Subjects { get; } = new List<string>();
    public List<int> Marks { get; } = new List<int>();
    public int Total { get; private set; }
    public double Average { get; private set; }

    /// <summary>
    /// Adds the total of all entered marks.
    /// </summary>
    public int CalculateTotalMarks()
    {
        Total = 0;

        foreach (int mark in Marks)
        {
            Total += mark;
        }

        return Total;
    }

    /// <summary>
    /// Calculates the average, or returns zero when no marks exist.
    /// </summary>
    public double CalculateAverage()
    {
        if (Marks.Count == 0)
        {
            Average = 0;
            return Average;
        }

        Average = (double)CalculateTotalMarks() / Marks.Count;
        return Average;
    }

    /// <summary>
    /// Converts the student's average into a letter grade.
    /// </summary>
    public string GetGrade()
    {
        if (Average >= 90)
        {
            return "A";
        }

        if (Average >= 80)
        {
            return "B";
        }

        if (Average >= 70)
        {
            return "C";
        }

        if (Average >= 60)
        {
            return "D";
        }

        return "F";
    }
}

public class Program
{
    private const int NumberOfSubjects = 3;

    public static void Main(string[] args)
    {
        try
        {
            StudentRecord student = ReadStudentRecord();
            int totalMarks = student.CalculateTotalMarks();
            double averageMarks = student.CalculateAverage();
            string grade = student.GetGrade();

            Console.WriteLine();
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Total Marks: {totalMarks}");
            Console.WriteLine($"Average Marks: {averageMarks:F2}");
            Console.WriteLine($"Grade: {grade}");
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine($"Input error: {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"An unexpected error occurred: {exception.Message}");
        }
    }

    /// <summary>
    /// Reads and validates student details from the console.
    /// </summary>
    private static StudentRecord ReadStudentRecord()
    {
        StudentRecord student = new StudentRecord();

        Console.Write("Enter student name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidOperationException("Student name cannot be empty.");
        }

        student.Name = name.Trim();

        for (int index = 1; index <= NumberOfSubjects; index++)
        {
            Console.Write($"Enter subject {index} name: ");
            string? subject = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new InvalidOperationException(
                    $"Subject {index} name cannot be empty.");
            }

            Console.Write($"Enter marks for {subject.Trim()} (0-100): ");
            string? markInput = Console.ReadLine();

            if (!int.TryParse(markInput, out int mark) || mark < 0 || mark > 100)
            {
                throw new InvalidOperationException(
                    $"Marks for subject {index} must be a whole number from 0 to 100.");
            }

            student.Subjects.Add(subject.Trim());
            student.Marks.Add(mark);
        }

        return student;
    }
}
