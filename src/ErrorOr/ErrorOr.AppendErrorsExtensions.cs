namespace ErrorOr;

public static partial class ErrorOrExtensions
{
    /// <summary>
    /// If the state of <paramref name="original"/> is error or any of the given <paramref name="errorOrs"/> has errors, an <see cref="ErrorOr"/> instance with all errors of the given instances will be returned.
    /// </summary>
    /// <param name="original">The <see cref="ErrorOr"/> instance which value should be returned on success.</param>
    /// <param name="errorOrs">The <see cref="ErrorOr"/> instances which errors should be added to the result.</param>
    /// <returns>The value of <paramref name="original"/> if all states are value, otherwise a list of all errors.</returns>
    public static ErrorOr<TValue> AppendErrors<TValue>(this ErrorOr<TValue> original, params IErrorOr[] errorOrs)
    {
        List<Error> combinedErrors = original.ErrorsOrEmptyList;
        foreach (IErrorOr errorOr in errorOrs)
        {
            combinedErrors.AddRange(errorOr.Errors ?? []);
        }

        return combinedErrors.Count == 0 ? original : combinedErrors;
    }
}
