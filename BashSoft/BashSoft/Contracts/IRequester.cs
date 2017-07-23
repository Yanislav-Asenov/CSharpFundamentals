namespace BashSoft.Contracts
{
    public interface IRequester
    {
        void GetStudentMarkInCourse(string courseName, string username);

        void GetStudentsByCourse(string courseName);
    }
}
