using Domain.Entities;
using FluentValidation;

namespace ValidationComponent.Validators
{
    public class BirdSightUpdateValidator : AbstractValidator<Tuple<int, BirdSight>>
    {
        public BirdSightUpdateValidator()
        {
            RuleFor(b => b.Item2.Id).NotEmpty().OverridePropertyName("Id");
            RuleFor(b => b.Item1).NotEmpty().OverridePropertyName("Url id");
            RuleFor(b => b).Must(b => b.Item1 == b.Item2.Id).WithMessage("Url id must be equal to birdsight id").OverridePropertyName("id");

            RuleFor(b => b.Item2.BirdId).NotEmpty();
            RuleFor(b => b.Item2.Count).NotEmpty();
        }
    }
}
