namespace BashSoft.Exceptions
{
    using System;

    public class CourseNotFoundException : Exception
    {
        private const string CourseNotFound = "The course you are trying to get does not exist in the data base!";

        public CourseNotFoundException()
            : base(CourseNotFound)
        {
        }

        public CourseNotFoundException(string message) : base(message)
        {
        }
    }
}
