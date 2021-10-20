using System;
using System.Collections.Generic;
using System.Text;

namespace WordCounter.Extensions.Exceptions
{
    public class ValidationProblemException : Exception
    {
        public ValidationProblemException(ValidationProblem validationProblem)
            : base(validationProblem.ErrorMessage)
        {
            this.ValidationProblem = validationProblem;
        }
        public ValidationProblemException(ValidationProblem validationProblem, Exception innerException)
            : base(validationProblem.ErrorMessage, innerException)
        {
            this.ValidationProblem = validationProblem;
        }

        public ValidationProblem ValidationProblem { get; set; }
    }

    public class ValidationProblem
    {
        public ValidationProblem(string Message)
        {
            this.ErrorMessage = Message;
        }

        public ValidationProblem(string Message, string Field)
        {
            this.ErrorMessage = Message;
            this.Field = Field;
        }

        public string ErrorMessage { get; set; }
        public string Field { get; set; }
    }
}
