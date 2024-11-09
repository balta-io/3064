using Balta.Domain.AccountContext.Errors;
using Balta.Domain.AccountContext.Errors.Exceptions;

namespace Balta.Domain.AccountContext.ValueObjects;

public sealed record CompositeName : Name
{
    #region Constants

    private const short MinLength = 2;
    private const short MaxLength = 40;

    #endregion

    #region Constructors

    private CompositeName(string firstName, string? lastName = null, string? middleName = null) : base(firstName)
    {
        MiddleName = middleName;
        LastName = lastName;
    }

    #endregion

    #region Factories

    public static CompositeName Create(string firstName, string? middleName = null, string? lastName = null)
    {
        Name.Create(firstName);
        if (lastName is not null) lastName = lastName.Trim();
        if (middleName is not null) middleName = middleName.Trim();

        Validate(middleName, lastName);
        return new CompositeName(firstName, lastName, middleName);
    }

    #endregion

    #region Properties

    public string? MiddleName { get; }
    public string? LastName { get; }

    #endregion

    #region Methods

    private static void Validate(string? middleName, string? lastName)
    {
        if(string.IsNullOrEmpty(middleName) == false)
        {
            if (middleName.Length is < MinLength or > MaxLength)
                throw new InvalidCompositeNameLengthException(ErrorMessages.CompositeName.InvalidLength);

            var firstChar = char.ToLower(middleName[0]);
            if (middleName.ToLower().All(mn => mn == firstChar))
                throw new InvalidMiddleNameException(ErrorMessages.CompositeName.InvalidLetters);
        }
        
        if (string.IsNullOrEmpty(lastName) == false)
        {
            if (lastName.Length is < MinLength or > MaxLength)
                throw new InvalidCompositeNameLengthException(ErrorMessages.CompositeName.InvalidLength);

            var firstLastNameChar = char.ToLower(lastName[0]);
            if (lastName.ToLower().All(ln => ln == firstLastNameChar))
                throw new InvalidLastNameException(ErrorMessages.CompositeName.InvalidLetters);
        }
    }

    #endregion

    #region Operators

    public static implicit operator string(CompositeName name) => name.ToString();

    #endregion

    #region Overrides

    public override string ToString()
    {
        var middle = MiddleName is not null ? $" {MiddleName} " : string.Empty;
        return $"{FirstName}{middle}{LastName}";
    }

    #endregion
}