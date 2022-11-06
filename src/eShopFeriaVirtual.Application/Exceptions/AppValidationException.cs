using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Exceptions
{
    public class AppValidationException : Exception
    {
        public AppValidationException() : base("Se han producido uno o más errores de validación")
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; }

        public AppValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach(var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
