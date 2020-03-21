using LibraryApp.Entities.Messages;
using System.Collections.Generic;

namespace LibraryApp.BusinessLayer
{
    public class BusinessLayerResult<T> where T : class
    {
        public T BlResult;

        public List<T> BlResultList;

        public List<ErrorMessageObj> ErrorMessageObj;

        public BusinessLayerResult()
        {
            ErrorMessageObj = new List<ErrorMessageObj>();
        }

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