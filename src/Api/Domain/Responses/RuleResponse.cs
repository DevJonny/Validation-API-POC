namespace Api.Domain.Responses;

public record RulesResponse(IEnumerable<RuleResponse> Fields, IEnumerable<RuleResponse> AdditionalInformation);

public record RuleResponse(string Field, string Message, Rule Rule);