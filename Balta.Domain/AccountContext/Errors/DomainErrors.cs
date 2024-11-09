using Balta.Domain.SharedContext.Results;

namespace Balta.Domain.AccountContext.Errors;

public static class DomainErrors
{
    #region Properties

    public static AccountError Account { get; set; } = new();

    #endregion

    #region Errors

    public class AccountError
    {
        public readonly Error EmailInUse = new("DEACCEIU", ErrorMessages.Account.EmailInUse);
        public readonly Error NotFound = new("DEACCANF", ErrorMessages.Account.NotFound);
        public readonly Error PasswordIsInvalid = new("DEACCUSI", ErrorMessages.Account.PasswordIsInvalid);
        public readonly Error EmailIsDifferent = new("DEACCEMD", ErrorMessages.Account.EmailIsDifferent);
        public readonly Error DocumentIsDifferent = new("DEACCEMD", ErrorMessages.Account.DocumentIsDifferent);
        public readonly Error IsInactive = new("DEACCAII", ErrorMessages.Account.IsInactive);
        public readonly Error IsAlreadyActive = new("DEACCAIA", ErrorMessages.Account.IsAlreadyActive);
        public readonly Error LockedOut = new("DEACCALA", ErrorMessages.Account.IsLockedOut);
    }

    #endregion
}