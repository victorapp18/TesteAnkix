using FluentValidation;
using TesteAnkix.Webapi.Application.ViewModels.Rates;

namespace TesteAnkix.Webapi.Application.CommandValidators.Rates
{
    public class CalculedCommandValidator : AbstractValidator<CalculedRequestViewMode>
    {
        public CalculedCommandValidator() 
        {
           
            RuleFor(p => p.Value).NotEmpty()
                                     .WithMessage("Value field cannot be empty.")
                                     .NotNull()
                                     .WithMessage("Value field cannot be null.");

            RuleFor(p => p.VatId).NotEmpty()
                                     .WithMessage("Vat field cannot be empty.")
                                     .NotNull()
                                     .WithMessage("Vat field cannot be null."); ;
            
            RuleFor(p => p.RateId).NotEmpty()
                               .WithMessage("Rate field cannot be empty.")
                               .NotNull()
                               .WithMessage("Rate field cannot be null.");
        }
    }
}

