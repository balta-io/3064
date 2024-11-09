using Balta.Domain.AccountContext.Enums;
using Balta.Domain.AccountContext.Errors;
using Balta.Domain.AccountContext.Errors.Exceptions;
using Balta.Domain.SharedContext.Common;

namespace Balta.Domain.AccountContext.ValueObjects;

public sealed record Cpf : Document
{
    #region Constants

    private const short MinLength = 11;

    #endregion

    #region Constructors

    private Cpf(string number) : base(number, EDocumentType.Cpf)
    {
    }

    #endregion

    #region Factories

    public static Cpf Create(string number)
    {
        number = number.ToNumbers();
        Validate(number);
        return new Cpf(number);
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
            throw new CpfNullOrEmptyException(ErrorMessages.Cpf.InvalidLength);
        
        if (number.Length != MinLength)
            throw new InvalidCpfLenghtException(ErrorMessages.Cpf.InvalidLength);

        if (number.All(c => c == number[0]))
            throw new InvalidCpfNumberException(ErrorMessages.Cpf.InvalidNumber);

        var firstMultiplier = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var secondMultiplier = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var temp = number[..9];
        var sum = 0;

        for (var i = 0; i < 9; i++)
            sum += int.Parse(temp[i].ToString()) * firstMultiplier[i];

        var rest = sum % 11;
        rest = rest < 2 ? 0 : 11 - rest;

        var digit = rest.ToString();
        temp += digit;
        sum = 0;

        for (var i = 0; i < 10; i++)
            sum += int.Parse(temp[i].ToString()) * secondMultiplier[i];

        rest = sum % 11;
        rest = rest < 2 ? 0 : 11 - rest;
        digit += rest;

        if (!number.EndsWith(digit))
            throw new InvalidCpfException(ErrorMessages.Cpf.Invalid);
    }

    #endregion

    #region Operators

    public static implicit operator Cpf(string number)
    {
        return Create(number);
    }

    public static implicit operator string(Cpf cpf)
    {
        return cpf.Number;
    }

    #endregion
}