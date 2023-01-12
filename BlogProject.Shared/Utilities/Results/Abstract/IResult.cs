using BlogProject.Shared.Utilities.Results.ComplexType;
using System;


namespace BlogProject.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; set; }
        public string  Message { get; }
        public Exception Exception { get; }


     
    }
}
