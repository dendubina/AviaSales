namespace AviaSales.Application.Common.Models;

public class PaymentResult
{
    public bool Succeeded { get; }

    public string[] Errors { get; }

    private PaymentResult(bool succeeded, string[] errors)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public static PaymentResult Success()
        => new PaymentResult(succeeded: true, errors: Array.Empty<string>());

    public static PaymentResult Failure(IEnumerable<string> errors)
        => new PaymentResult(succeeded: false, errors.ToArray());
}