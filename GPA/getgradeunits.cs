namespace GPA
{
    class GetGradepoints
    {

        public static double GetGradePoints(string grade)
        {
            switch (grade.ToUpper())
            {
                case "A": return 5.0;
                case "B": return 4.0;
                case "C": return 3.0;
                case "D": return 2.0;
                case "E": return 1.0;
                case "F": return 0.0;
                default: return 0.0; // Handle unrecognized grades
            }
        }
    }
}
