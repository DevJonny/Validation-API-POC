namespace Api.Domain;

public record Person(
    string FirstName, 
    string LastName, 
    string Email,
    int Age);