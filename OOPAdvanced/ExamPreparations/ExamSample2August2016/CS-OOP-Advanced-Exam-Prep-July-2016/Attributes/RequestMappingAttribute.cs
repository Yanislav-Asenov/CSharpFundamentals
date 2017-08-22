namespace CS_OOP_Advanced_Exam_Prep_July_2016.Attributes
{
    using System;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Core;

    public class RequestMappingAttribute : Attribute
    {
        private readonly string value;

        private readonly RequestMethod method;

        public RequestMappingAttribute(string value, RequestMethod method = RequestMethod.ADD)
        {
            this.value = value;
            this.method = method;
        }

        public string Value
        {
            get { return this.value; }
        }

        public RequestMethod Method
        {
            get { return this.method; }
        }
    }
}
