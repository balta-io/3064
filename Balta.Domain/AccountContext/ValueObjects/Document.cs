using Balta.Domain.AccountContext.Enums;
using Balta.Domain.AccountContext.Errors;
using Balta.Domain.AccountContext.Errors.Exceptions;

namespace Balta.Domain.AccountContext.ValueObjects;

public record Document
{
    #region Constructors

    private Document()
    {
    }

    protected Document(string number, EDocumentType type)
    {
        if (string.IsNullOrEmpty(number))
            throw new DocumentNullException(ErrorMessages.Document.Null);

        if (string.IsNullOrWhiteSpace(number))
            throw new InvalidDocumentException(ErrorMessages.Document.Invalid);

        Number = number.Trim();
        Type = type;
    }

    #endregion

    #region Properties

    public string Number { get; } = string.Empty;
    public EDocumentType Type { get; }

    #endregion

    #region Operators

    public static implicit operator string(Document document) => document.Number;

    #endregion
}