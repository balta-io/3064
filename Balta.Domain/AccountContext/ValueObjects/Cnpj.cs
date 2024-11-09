using Balta.Domain.AccountContext.Enums;
using Balta.Domain.AccountContext.Errors;
using Balta.Domain.AccountContext.Errors.Exceptions;
using Balta.Domain.SharedContext.Common;

namespace Balta.Domain.AccountContext.ValueObjects;

public sealed record Cnpj : Document
{
    #region Constants

    private const short MinLength = 14;

    #endregion

    #region Constructors

    private Cnpj(string number) : base(number, EDocumentType.Cnpj)
    {
    }

    #endregion

    #region Factories

    public static Cnpj Create(string number)
    {
        number = number.ToNumbers();
        Validate(number);
        return new Cnpj(number);
    }

    #endregion

    #region Overrides

    public override string ToString()
    {
        return Number;
    }

    #endregion

    #region Methods

    private static void Validate(string number)
    {
        if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
            throw new CnpjNullOrEmptyException((ErrorMessages.Cnpj.InvalidLength));
        
        if (number.Length != MinLength)
            throw new InvalidCnpjLenghtException(ErrorMessages.Cnpj.InvalidLength);

        if (number.All(c => c == number[0]))
            throw new InvalidCnpjNumberException(ErrorMessages.Cnpj.InvalidNumber);

        var multiplier1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplier2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var temp = number[..12];
        var sum = 0;

        for (var i = 0; i < 12; i++)
            sum += int.Parse(temp[i].ToString()) * multiplier1[i];

        var rest = sum % 11;
        rest = rest < 2 ? 0 : 11 - rest;
        var digit = rest.ToString();

        temp += digit;
        sum = 0;

        for (var i = 0; i < 13; i++)
            sum += int.Parse(temp[i].ToString()) * multiplier2[i];

        rest = sum % 11;
        rest = rest < 2 ? 0 : 11 - rest;
        digit += rest.ToString();

        if (!number.EndsWith(digit))
            throw new InvalidCnpjException(ErrorMessages.Cnpj.Invalid);
    }

    #endregion

    #region Operators

    public static implicit operator Cnpj(string number)
    {
        return Create(number);
    }

    public static implicit operator string(Cnpj cnpj)
    {
        return cnpj.Number;
    }

    #endregion
}