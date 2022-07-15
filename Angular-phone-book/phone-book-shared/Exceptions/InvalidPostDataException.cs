using Microsoft.AspNetCore.Mvc.ModelBinding;
using phone_book_shared.Extensions;
using phone_book_shared.Models;
using System.Net;

namespace phone_book_shared.Exceptions
{
    public class InvalidPostDataException : Exception
    {
        public readonly List<ErrorPayload> _errorList;
        public InvalidPostDataException(ModelStateDictionary ModelState) 
            : base("One or more validation failures has occured. Contact Administrator")
        {
            _errorList = ModelState.Where(error => error.Value.Errors.Count > 0)
                                   .Select(error => new ErrorPayload
                                   {
                                       Path = $"{error.Key.Split(".")[0].ToLowerCamelCase()}.{error.Key.Split(".")[1].ToLowerCamelCase()}",
                                       Message = error.Value.Errors.FirstOrDefault().ErrorMessage,
                                       ErrorCode = $"{(int)HttpStatusCode.BadRequest}"
                                   }).ToList();
        }
    }
}
