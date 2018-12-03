using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Formular_Osoby
{
    class ValidatorSkola : AbstractValidator<Skola>
    {
        public ValidatorSkola()
        {

            RuleFor(x => x.Jmeno).NotEmpty().WithMessage("Zadejte prosím jméno Školy");

        }
    }
}
