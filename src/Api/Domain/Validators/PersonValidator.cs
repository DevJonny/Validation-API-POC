using FluentValidation;

namespace Api.Domain.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleSet("FirstName", () =>
        {
            
        });
        
        RuleFor(p => p.FirstName)
            .NotNull()
            .MinimumLength(2) // State and message must be on the rule that will fail with an empty object
                .WithState(_ => new Rule(@"\w{2,25}"))
                .WithMessage("FirstName must be between 2 and 25 characters")
            .MaximumLength(25);

        RuleFor(p => p.LastName)
            .NotNull()
            .MinimumLength(2)
                .WithState(_ => new Rule(@"\w{2,25"))
                .WithMessage("LastName must be between 2 and 25 characters")
            .MaximumLength(25);

        RuleFor(p => p.Email)
            .EmailAddress()
            .WithState(_ => new Rule(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"));

        RuleFor(p => p.Age)
            .NotNull()
            .GreaterThanOrEqualTo(18)
                .WithState(_ => new Rule("[1]?[8-9][0-9]?|(200)", true))
                .WithMessage("Must be over 18, and no vampires please")
            .LessThanOrEqualTo(200);
    }
}