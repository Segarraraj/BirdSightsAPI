using Domain.Entities;
using FluentValidation;

namespace ValidationComponent.Validators
{
    public class BirdUpdateValidator : AbstractValidator<Tuple<int, Bird>>
    {
        public BirdUpdateValidator() 
        {
            RuleFor(b => b.Item2.Id).NotEmpty().OverridePropertyName("Id");
            RuleFor(b => b.Item1).NotEmpty().OverridePropertyName("Url id");
            RuleFor(b => b).Must(b => b.Item1 == b.Item2.Id).WithMessage("Url id must be equal to bird id").OverridePropertyName("Id");
        }
    }
}
