using Maxanger.Domain.Models.Interpreters.Abstract;

namespace Maxanger.Domain.Models.Interpreters;

public class ExecutionResult : IExecutionResult
{
    public object? Data { get; init; } = null;
}