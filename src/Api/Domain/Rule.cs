using System.Text.Json.Serialization;

namespace Api.Domain;

public record Rule(string Regex, [property: JsonIgnore] bool IsAdditional = false);