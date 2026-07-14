using DemosGithub;

namespace DemosGithub.Tests;

public class BankAccountTests
{
    // Constructor
    [Fact]
    public void Constructor_ValidArguments_SetsProperties()
    {
        var account = new BankAccount("Alice", 100);
        Assert.Equal("Alice", account.Owner);
        Assert.Equal(100, account.Balance);
    }

    [Fact]
    public void Constructor_DefaultBalance_IsZero()
    {
        var account = new BankAccount("Bob");
        Assert.Equal(0, account.Balance);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidOwner_ThrowsArgumentException(string? owner)
    {
        Assert.Throws<ArgumentException>(() => new BankAccount(owner!));
    }

    [Fact]
    public void Constructor_NegativeInitialBalance_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BankAccount("Alice", -50));
    }

    // Deposit
    [Fact]
    public void Deposit_ValidAmount_IncreasesBalance()
    {
        var account = new BankAccount("Alice", 100);
        account.Deposit(50);
        Assert.Equal(150, account.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Deposit_NonPositiveAmount_ThrowsArgumentOutOfRangeException(decimal amount)
    {
        var account = new BankAccount("Alice", 100);
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(amount));
    }

    // Withdraw
    [Fact]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        var account = new BankAccount("Alice", 100);
        account.Withdraw(30);
        Assert.Equal(70, account.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Withdraw_NonPositiveAmount_ThrowsArgumentOutOfRangeException(decimal amount)
    {
        var account = new BankAccount("Alice", 100);
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(amount));
    }

    [Fact]
    public void Withdraw_InsufficientFunds_ThrowsInvalidOperationException()
    {
        var account = new BankAccount("Alice", 50);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(100));
    }

    // Transfer
    [Fact]
    public void Transfer_ValidAmount_MovesBalanceBetweenAccounts()
    {
        var alice = new BankAccount("Alice", 200);
        var bob = new BankAccount("Bob", 50);
        alice.Transfer(bob, 75);
        Assert.Equal(125, alice.Balance);
        Assert.Equal(125, bob.Balance);
    }

    [Fact]
    public void Transfer_NullTarget_ThrowsArgumentNullException()
    {
        var alice = new BankAccount("Alice", 200);
        Assert.Throws<ArgumentNullException>(() => alice.Transfer(null!, 50));
    }

    [Fact]
    public void Transfer_InsufficientFunds_ThrowsInvalidOperationException()
    {
        var alice = new BankAccount("Alice", 10);
        var bob = new BankAccount("Bob");
        Assert.Throws<InvalidOperationException>(() => alice.Transfer(bob, 100));
    }
}
