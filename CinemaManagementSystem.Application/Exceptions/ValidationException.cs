using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Error { get; set; } = new List<string>();
        public ValidationException(ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                Error.Add(error.ErrorMessage);
            }
        }
    }
}
