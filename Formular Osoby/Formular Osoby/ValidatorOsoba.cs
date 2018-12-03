using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Formular_Osoby
{
    class ValidatorOsoba : AbstractValidator<Osoba>
    {
        public ValidatorOsoba()
        {
            
            RuleFor(x => x.Primeni).NotEqual(x => x.Jmeno).WithMessage("Příjmení a jmeno nemůžou být stejný");
            RuleFor(x => x.Jmeno).NotEmpty().WithMessage("Zadejte prosím jméno");
            RuleFor(x => x.Primeni).NotEmpty().WithMessage("Zadejte prosím celé jméno");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Zadejte praví E-mail");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Zadejte prosím Email");
            RuleFor(x => x.DatumNarozeni).NotEmpty().WithMessage("Zadejte prosím datum");
        }
    }
}
