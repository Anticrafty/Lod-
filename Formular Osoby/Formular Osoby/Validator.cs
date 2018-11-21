using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Formular_Osoby
{
    class Validator : AbstractValidator<Osoba>
    {
        public Validator()
        {
            RuleFor(x => x.jmeno).NotEmpty().WithMessage("Zadejte prosím celé své jméno");
            RuleFor(x => x.primeni).NotEmpty().WithMessage("Zadejte proím celé své jméno");
            RuleFor(x => x.primeni).NotEqual(x => x.jmeno).WithMessage("Příjmení a jemno nemůžou být stejný");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Zadejte prosím Email");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Zadejte praví E-mail");
            RuleFor(x => x.DatumNarozeni).NotEmpty().WithMessage("Zadejte prosím datum");
        }
    }
}
