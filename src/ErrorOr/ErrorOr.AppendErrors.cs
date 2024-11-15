namespace ErrorOr;

public readonly partial record struct ErrorOr<TValue> : IErrorOr<TValue>
{
    /// <summary>
    /// If the state is error or any of the given <paramref name="errorOrs"/> has errors, an <see cref="ErrorOr"/> instance with all errors of the given instances will be returned.
    /// </summary>
    /// <param name="errorOrs">The <see cref="ErrorOr"/> instances which errors should be added to the result.</param>
    /// <returns>The original <see cref="Value"/> if all states are value, otherwise a list of all errors.</returns>
    public ErrorOr<TValue> AppendErrors(params IErrorOr[] errorOrs)
    {
        List<Error> combinedErrors = ErrorsOrEmptyList;
        foreach (IErrorOr errorOr in errorOrs)
        {
            combinedErrors.AddRange(errorOr.Errors ?? []);
        }

        return combinedErrors.Count == 0 ? this : combinedErrors;
    }
}
