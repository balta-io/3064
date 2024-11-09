using System.Text;

namespace Balta.Domain.SharedContext.Common;

public static class StringExtension
{
    #region Public Methods

    public static string ToBase64(this string text)
    {
        return Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
    }

    public static string ToNumbers(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        return string.IsNullOrWhiteSpace(value)
            ? string.Empty
            : new string(value.Where(char.IsDigit).ToArray());
    }

    public static string ToAlphaNumeric(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        return string.IsNullOrWhiteSpace(value)
            ? string.Empty
            : new string(value.Where(char.IsLetterOrDigit).ToArray());
    }

    #endregion
}