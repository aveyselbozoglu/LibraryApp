using LibraryApp.Entities.Messages;
using System.Collections.Generic;

namespace LibraryApp.BusinessLayer
{
    public class BusinessLayerResult<T> where T : class
    {
        //public List<string> Errors;
        public T BlResult;

        public List<ErrorMessageObj> ErrorMessageObj;

        public BusinessLayerResult()
        {
            ErrorMessageObj = new List<ErrorMessageObj>();
            //Errors = new List<string>();
        }

        //public void AddError(ErrorMessageCode code , string message)
        //{
        //}

        public void AddError(ErrorMessageCode code, string message)
        {
            ErrorMessageObj.Add(new ErrorMessageObj()
            {
                Code = code,
                Message = message
            });
        }
    }
}