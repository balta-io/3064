using Balta.Domain.AccountContext.Errors;
using Balta.Domain.AccountContext.Errors.Exceptions;
using Balta.Domain.SharedContext.ValueObjects;

namespace Balta.Domain.AccountContext.ValueObjects;

public record Name : ValueObject
{
    #region Constants

    private const short MinLength = 2;
    private const short MaxLength = 40;

    #endregion

    #region Constructors

    private Name()
    {
    }

    protected Name(string name) => FirstName = name;

    #endregion

    #region Factories

    public static Name Create(string name)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            throw new NameNullOrEmptyException(ErrorMessages.Name.InvalidNullOrEmpty);

        name = name.Trim();
        Validate(name);
        return new Name(name);
    }

    #endregion

    #region Properties

    public string FirstName { get; } = string.Empty;

    #endregion

    #region Methods

    private static void Validate(string name)
    {
        if (name.Length < MinLength || name.Length > MaxLength)
            throw new InvalidNameLengthException(ErrorMessages.Name.InvalidLength);

        if (name.All(n => n == name[0]))
            throw new InvalidNameException(ErrorMessages.Name.InvalidLetters);
    }

    #endregion

    #region Operators

    public static implicit operator string(Name name) => name.ToString();

    #endregion

    #region Overrides

    public override string ToString() => $"{FirstName}";

    #endregion
}