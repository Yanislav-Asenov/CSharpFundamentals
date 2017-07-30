namespace BashSoft.Contracts
{
    using System.Collections.Generic;

    public interface IRequester
    {
        void GetStudentMarkInCourse(string courseName, string username);

        void GetStudentsByCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> comparison);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> comparison);
    }
}