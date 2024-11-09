using Balta.Domain.AccountContext.Enums;
using Balta.Domain.AccountContext.Events;
using Balta.Domain.AccountContext.ValueObjects;
using Balta.Domain.SharedContext.Abstractions;
using Balta.Domain.SharedContext.Aggregates.Abstractions;
using Balta.Domain.SharedContext.Entities;
using Balta.Domain.SharedContext.ValueObjects;

namespace Balta.Domain.AccountContext.Entities;

public sealed class Account : Entity, IAggregateRoot
{
    #region Constructors

    private Account() : base(Guid.NewGuid(), Tracker.Create())
    {
    }

    private Account(
        Guid id,
        EAccountType type,
        CompositeName name,
        Email email,
        VerificationCode verificationCode,
        Password password,
        Document document,
        Tracker tracker,
        LockOut? lockout = null) : base(id, tracker)
    {
        Type = type;
        Name = name;
        Email = email;
        VerificationCode = verificationCode;
        Password = password;
        Document = document;
        Lockout = lockout;
    }

    #endregion

    #region Factories

    public static Account CreateProfessor(CompositeName name, Email email, Password password, Cpf cpf,
        IDateTimeProvider dateTimeProvider)
    {
        var id = Guid.NewGuid();
        var verificationCode = VerificationCode.Create(dateTimeProvider);
        var tracker = Tracker.Create(dateTimeProvider);
        var professor = new Account(id, EAccountType.Professor, name, email, verificationCode, password, cpf, tracker);
        professor.RaiseDomainEvent(new OnProfessorCreatedEvent(id, name, email));

        return professor;
    }

    public static Account CreateStudent(CompositeName name, Email email, Password password, Cpf cpf,
        IDateTimeProvider dateTimeProvider)
    {
        var id = Guid.NewGuid();
        var verificationCode = VerificationCode.Create(dateTimeProvider);
        var tracker = Tracker.Create(dateTimeProvider);
        var student = new Account(id, EAccountType.Student, name, email, verificationCode, password, cpf, tracker);
        student.RaiseDomainEvent(new OnStudentCreatedEvent(id, name, email));

        return student;
    }

    public static Account CreateCorporation(Name name, Email email, Password password, Cnpj cnpj,
        IDateTimeProvider dateTimeProvider)
    {
        var id = Guid.NewGuid();
        var compositeName = CompositeName.Create(name, string.Empty);
        var verificationCode = VerificationCode.Create(dateTimeProvider);
        var tracker = Tracker.Create(dateTimeProvider);
        var corporation = new Account(id, EAccountType.Corporation, compositeName, email, verificationCode, password,
            cnpj,
            tracker);
        corporation.RaiseDomainEvent(new OnCorporationCreatedEvent(id, name, email));

        return corporation;
    }

    #endregion

    #region Properties

    public EAccountType Type { get; }
    public CompositeName Name { get; } = null!;
    public Email Email { get; } = null!;
    public VerificationCode VerificationCode { get; private set; } = null!;
    public Password Password { get; } = null!;
    public Document Document { get; } = null!;
    public LockOut? Lockout { get; }

    #endregion

    #region Public Methods

    public void ResetVerificationCode(IDateTimeProvider dateTimeProvider)
    {
        VerificationCode = VerificationCode.Create(dateTimeProvider);
        RaiseDomainEvent(new OnResendEmailVerificationEvent(Id, Name, Email, VerificationCode));
    }

    public bool Authenticate(string plainTextPassword,IDateTimeProvider dateTimeProvider)
    {
        Tracker.Update(dateTimeProvider);
        return Password.Verify(Password.HashText, plainTextPassword);
    } 

    #endregion
}