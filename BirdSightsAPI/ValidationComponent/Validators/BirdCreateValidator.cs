using Domain.Entities;
using FluentValidation;

namespace ValidationComponent.Validators
{
    public class BirdCreateValidator : AbstractValidator<Bird>
    {
        public BirdCreateValidator() 
        {
            RuleFor(b => b.Id).Empty();
        }
    }
}
