namespace DemosGithub;

/// <summary>
/// Represents a bank account with basic operations.
/// </summary>
public class BankAccount
{
    private decimal _balance;

    /// <summary>Gets the account holder's name.</summary>
    public string Owner { get; }

    /// <summary>Gets the current balance.</summary>
    public decimal Balance => _balance;

    /// <summary>Initializes a new <see cref="BankAccount"/> with the given owner and optional initial balance.</summary>
    /// <exception cref="ArgumentException">Thrown when <paramref name="owner"/> is null or whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="initialBalance"/> is negative.</exception>
    public BankAccount(string owner, decimal initialBalance = 0)
    {
        if (string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Owner name cannot be empty.", nameof(owner));
        if (initialBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be negative.");

        Owner = owner;
        _balance = initialBalance;
    }

    /// <summary>Deposits the given amount into the account.</summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="amount"/> is not positive.</exception>
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");
        _balance += amount;
    }

    /// <summary>Withdraws the given amount from the account.</summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="amount"/> is not positive.</exception>
    /// <exception cref="InvalidOperationException">Thrown when there are insufficient funds.</exception>
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        _balance -= amount;
    }

    /// <summary>Transfers funds from this account to <paramref name="target"/>.</summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="target"/> is null.</exception>
    public void Transfer(BankAccount target, decimal amount)
    {
        ArgumentNullException.ThrowIfNull(target);
        Withdraw(amount);
        target.Deposit(amount);
    }
}
