namespace SharpPyxis.Guards;

/// <summary>
/// Exception whose <see cref="Exception.Message"/> is safe to display to the end user,
/// regardless of the environment (Development or Production).
/// </summary>
/// <remarks>
/// Use this exception when a <c>Result&lt;T&gt;</c> return is not practical
/// and you need to communicate a business error to the caller.
/// </remarks>
/// <example>
/// <code>throw new UserFacingException("Invoice amount must be greater than zero.");</code>
/// </example>
public class UserFacingException : Exception
{
    /// <summary>HTTP status code to return. Defaults to 400 (Bad Request).</summary>
    public int StatusCode { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="UserFacingException"/> with a user-safe message.
    /// </summary>
    /// <param name="message">A message safe to display to the end user.</param>
    /// <param name="statusCode">HTTP status code. Defaults to 400.</param>
    public UserFacingException(string message, int statusCode = 400)
        : base(message)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="UserFacingException"/> with a user-safe message and inner exception.
    /// </summary>
    /// <param name="message">A message safe to display to the end user.</param>
    /// <param name="innerException">The exception that caused this error.</param>
    /// <param name="statusCode">HTTP status code. Defaults to 400.</param>
    public UserFacingException(string message, Exception innerException, int statusCode = 400)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}
