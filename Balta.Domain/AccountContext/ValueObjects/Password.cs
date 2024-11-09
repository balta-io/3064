using System.Security.Cryptography;
using Balta.Domain.AccountContext.Errors;
using Balta.Domain.AccountContext.Errors.Exceptions;
using Balta.Domain.SharedContext;
using Balta.Domain.SharedContext.ValueObjects;

namespace Balta.Domain.AccountContext.ValueObjects;

public sealed record Password : ValueObject
{
    #region Constructors

    private Password()
    {
    }

    private Password(string plainTextPassword) => HashText = Hash(plainTextPassword);

    #endregion

    #region Factories

    public static Password Create(string plainTextPassword)
        => new(plainTextPassword);

    #endregion

    #region Properties

    public string HashText { get; } = string.Empty;

    #endregion
    
    #region Constants
    
    private const int MinimumLength = 12;
    private const int MaximumLength = 48;
    
    #endregion

    #region Private Methods

    private static string Hash(string password)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            throw new PasswordNullException(ErrorMessages.Password.Invalid);

        if (password.Length < MinimumLength || password.Length > MaximumLength)
            throw new PasswordLengthException(ErrorMessages.Password.InvalidLength);
        
        password += Configuration.Security.PasswordSaltKey;

        using var algorithm = new Rfc2898DeriveBytes(
            password,
            Configuration.Security.SaltSize,
            Configuration.Security.Iterations,
            HashAlgorithmName.SHA256);
        var key = Convert.ToBase64String(algorithm.GetBytes(Configuration.Security.KeySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return
            $"{Configuration.Security.Iterations}{Configuration.Security.SplitChar}{salt}{Configuration.Security.SplitChar}{key}";
    }

    public bool Verify(string hashedString, string plainTextPassword)
    {
        plainTextPassword += Configuration.Security.PasswordSaltKey;

        var parts = hashedString.Split(Configuration.Security.SplitChar, 3);
        if (parts.Length != 3)
            return false;

        var hashIterations = Convert.ToInt32(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        if (hashIterations != Configuration.Security.Iterations)
            return false;

        using var algorithm = new Rfc2898DeriveBytes(
            plainTextPassword,
            salt,
            Configuration.Security.Iterations,
            HashAlgorithmName.SHA256);
        var keyToCheck = algorithm.GetBytes(Configuration.Security.KeySize);

        return keyToCheck.SequenceEqual(key);
    }

    #endregion
}