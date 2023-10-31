using Api;
using Api.Domain;
using Api.Domain.Responses;
using Api.Domain.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IValidator<Person>, PersonValidator>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/rules", 
    ([FromServices] IValidator<Person> personValidator) =>
    {
        Person invalidPerson = new(string.Empty, string.Empty, string.Empty, 0);
        
        var errors = personValidator.Validate(invalidPerson).Errors;
        
        var allRules =
            errors
                .Select(e => new RuleResponse(e.PropertyName, e.ErrorMessage, (e.CustomState as Rule)!))
                .ToList();

        return new RulesResponse(
            allRules.Where(r => !r.Rule.IsAdditional),
            allRules
                .Where(r => r.Rule.IsAdditional)
        );
    });

app.Run();