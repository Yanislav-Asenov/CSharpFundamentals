namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        }
    }
}
