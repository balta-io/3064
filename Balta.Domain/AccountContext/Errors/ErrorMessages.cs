namespace Balta.Domain.AccountContext.Errors;

public static class ErrorMessages
{
    #region Properties

    public static AccountErrorMessages Account { get; set; } = new();
    public static EmailErrorMessages Email { get; set; } = new();
    public static PasswordErrorMessages Password { get; set; } = new();
    public static VerificationCodeErrorMessages VerificationCode { get; set; } = new();
    public static DocumentErrorMessages Document { get; set; } = new();
    public static CpfErrorMessages Cpf { get; set; } = new();
    public static CnpjErrorMessages Cnpj { get; set; } = new();
    public static NameErrorMessages Name { get; set; } = new();
    public static CompositeNameErrorMessages CompositeName { get; set; } = new();
    public static LockOutErrorMessages LockOut { get; set; } = new();

    #endregion

    #region Error Messages

    public class AccountErrorMessages
    {
        public string EmailInUse { get; set; } = "Este E-mail já está sendo utilizado.";
        public string EmailDenied { get; set; } = "Este E-mail está bloqueado no sistema.";
        public string DomainDenied { get; set; } = "Este domínio está bloqueado no sistema.";
        public string NotFound { get; set; } = "Conta não encontrada.";
        public string PasswordIsInvalid { get; set; } = "Usuário ou senha inválidos.";
        public string IsInactive { get; set; } = "Esta conta ainda não foi ativada.";
        public string IsAlreadyActive { get; set; } = "Esta conta já foi ativada.";
        public string IsLockedOut { get; set; } = "Esta conta está bloqueada.";
        public string EmailIsDifferent { get; set; } = "O E-mail informado é diferente do E-mail da conta.";
        public string DocumentIsDifferent { get; set; } = "O document informado é diferente do documento da conta.";
    }

    public class EmailErrorMessages
    {
        public string Invalid { get; set; } = "E-mail inválido";
        public string NullOrEmpty { get; set; } = "E-mail não pode ser nulo ou vazio.";
    }

    public class PasswordErrorMessages
    {
        public string Invalid { get; set; } = "A senha informada é inválida.";
        public string InvalidLength { get; set; } = "A senha deve conter pelo menos 12 caracteres.";
        public string PasswordNull { get; set; } = "A senha não pode ser nula.";
    }

    public class VerificationCodeErrorMessages
    {
        public string InvalidCode { get; set; } = "Código de verificação inválido.";
        public string NullOrEmpty { get; set; } = "Nenhum código de verificação foi informado.";
        public string NullOrWhiteSpace { get; set; } = "O código de verificação informado está vazio.";
        public string InvalidLenght { get; set; } = "O código de verificação deve conter 6 caracteres.";
        public string Expired { get; set; } = "Este código de verificação expirou.";
        public string AlreadyActive { get; set; } = "Este código de verificação já está ativo.";
    }

    public class DocumentErrorMessages
    {
        public string Invalid { get; set; } = "O documento informado é inválido.";
        public string Null { get; set; } = "Nenhum documento foi informado.";
    }

    public class CpfErrorMessages
    {
        public string Invalid { get; set; } = "O CPF informado é inválido.";
        public string InvalidLength { get; set; } = "O CPF deve conter 11 dígitos.";
        public string InvalidNumber { get; set; } = "O número do CPF informado é inválido.";
    }

    public class CnpjErrorMessages
    {
        public string Invalid { get; set; } = "O CNPJ informado é inválido.";
        public string InvalidLength { get; set; } = "O CNPJ deve conter 14 dígitos.";
        public string InvalidNumber { get; set; } = "O número do CNPJ informado é inválido.";
    }

    public class NameErrorMessages
    {
        public string Invalid { get; set; } = "O Nome informado é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "O Nome informado não pode ser vazio ou nulo.";
        public string InvalidLength { get; set; } = "O Nome deve conter pelo menos 2 dígitos.";
        public string InvalidLetters { get; set; } = "O Nome informado é inválido devido ao padrão de caracteres.";
    }

    public class CompositeNameErrorMessages
    {
        public string Invalid { get; set; } = "Os valores informados não são válidos.";

        public string InvalidNullOrWhiteSpace { get; set; } = "Os valores informados não podem ser vazios.";
        public string InvalidLength { get; set; } = "O campo deve conter pelo menos 3 e no máximo 40 dígitos.";
        public string InvalidLetters { get; set; } = "O padrão de caracteres não é válido.";
    }

    public class LockOutErrorMessages
    {
        public string Invalid { get; set; } = "O LockOut informado não é válido.";
        public string InvalidLockOutExpired { get; set; } = "O LockOut informado esta expirado.";
        public string InvalidLockOutReasonLength { get; set; } = "O tamanho do motivo do LockOut informado é inválido.";
    }

    #endregion
}