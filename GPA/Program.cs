using ConsoleTables;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome, enter your score");

        // Initialize a list to store info about each course objects.
        List<Course> courses = new List<Course>();

        // Get the number of courses, prompt the user to input the number of courses they want to calculate the GPA for, converted to an integer and stored in the var "numCourses"
        Console.Write("Enter the number of courses: ");
        int numCourses;

        while (!int.TryParse(Console.ReadLine(), out numCourses) || numCourses <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the number of courses.");
            Console.Write("Enter the number of courses: ");
        }

        // Get course details for each course
        for (int i = 1; i <= numCourses; i++)
        {
            Console.WriteLine($"\nEnter details for Course {i}:");

            // Create a new Course object
            Course course = new Course();

            // Get course name
            Console.Write("Enter course name: ");
            course.Name = Console.ReadLine();

            // Get course code
            Console.Write("Enter course code: ");
            course.Code = Console.ReadLine();

            // Get course unit
            Console.Write("Enter course unit: ");
            int courseUnit;
            while (!int.TryParse(Console.ReadLine(), out courseUnit) || courseUnit <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for course unit.");
                Console.Write("Enter course unit: ");
            }
            course.Unit = courseUnit;

            // Get course score
            Console.Write("Enter course score: ");
            double courseScore;
            while (!double.TryParse(Console.ReadLine(), out courseScore) || courseScore < 0 || courseScore > 100)
            {
                Console.WriteLine("Invalid input. Please enter a valid score between 0 and 100.");
                Console.Write("Enter course score: ");
            }
            course.Score = courseScore;
            // Add the Course object to the list
            courses.Add(course);
        }

        // Calculate GPA
        double gpa = CalculateGPA(courses);

        // Get remarks based on GPA
        string remarks = GetRemarks(gpa);

        // Display the result in a tabular form
        //Console.WriteLine("\nCourse Details and GPA:");
        //Console.WriteLine("--------------------------------------------------------");
        //Console.WriteLine("| Course Name | Course Code | Units | Score |");
        //Console.WriteLine("--------------------------------------------------------");
        var newTable = new ConsoleTable("Course Name", "Course code", "Course Unit", "Course score");
        foreach (Course course in courses)
        {
            //Console.WriteLine($"| {course.Name,-12} | {course.Code,-12} | {course.Unit,-5} | {course.Score,-5:F1} |");
            newTable.AddRow(course.Name,course.Code,course.Unit,course.Score);
        }
        newTable.Write();
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine($"\nYour GPA is: {gpa:F2}");
        Console.WriteLine($"Remarks: {remarks}");
    }

    // Function to calculate GPA based on a list of Course objects 
    static double CalculateGPA(List<Course> courses)
    {
        double totalGradePoints = 0;
        int totalUnits = 0;

        foreach (Course course in courses)
        {
            double gradePoints = CalculateGradePoints(course.Score);
            totalGradePoints += gradePoints * course.Unit;
            totalUnits += course.Unit;
        }

        return totalUnits == 0 ? 0 : totalGradePoints / totalUnits;
    }

    // Function to calculate grade points based on course score
    static double CalculateGradePoints(double score)
    {
        if (score >= 70)
            return 5.0;
        else if (score >= 60)
            return 4.0;
        else if (score >= 50)
            return 3.0;
        else if (score >= 45)
            return 2.0;
        else if (score >= 40)
            return 1.0;
        else
            return 0.0;
    }

    // Function to get remarks based on GPA
    static string GetRemarks(double gpa)
    {
        if (gpa >= 4.5)
            return "Excellent!";
        else if (gpa >= 4.0)
            return "Very Good!";
        else if (gpa >= 3.5)
            return "Good!";
        else if (gpa >= 3.0)
            return "Satisfactory";
        else if (gpa >= 2.0)
            return "Needs Improvement";
        else
            return "Fail";
    }
}

// Custom class to represent a Course
class Course
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int Unit { get; set; }
    public double Score { get; set; }
}
