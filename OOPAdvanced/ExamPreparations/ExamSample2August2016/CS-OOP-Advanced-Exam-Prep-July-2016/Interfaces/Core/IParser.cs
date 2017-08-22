namespace CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.Core
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Core;
    using System;
    using System.Collections.Generic;

    public interface IParser
    {
        void Parse();

        IDictionary<RequestMethod, IDictionary<string, ControllerActionPair>> Controllers { get; }

        IDictionary<Type, Type> Components { get; }
    }
}
