using Domain.Entities;
using FluentValidation;

namespace ValidationComponent.Validators
{
    public class BirdSightCreateValidator : AbstractValidator<BirdSight>
    {
        public BirdSightCreateValidator() 
        {
            RuleFor(b => b.Id).Empty();
            RuleFor(b => b.BirdId).NotEmpty();
            RuleFor(b => b.Count).NotEmpty();
        }
    }
}
