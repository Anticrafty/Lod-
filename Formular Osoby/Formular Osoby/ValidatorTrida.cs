using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Formular_Osoby
{
    class ValidatorTrida : AbstractValidator<Trida>
    {
        public ValidatorTrida()
        {

            RuleFor(x => x.Jmeno).NotEmpty().WithMessage("Zadejte prosím jméno třídy");
            RuleFor(x => x.KmenovaTrida).NotEmpty().WithMessage("Zadejte prosím kmenovou třídu");
            RuleFor(x => x.TridniUcitel).NotEmpty().WithMessage("Zadejte prosím Třídního učitele");

        }
    }
}
