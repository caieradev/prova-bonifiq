using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Tests;

[TestFixture]
public class CustomerServiceTests
{
    private CustomerService _customerService;
    private TestDbContext _context;

    [SetUp]
    public void Setup()
    {
        var builder = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("test");
        _context = new TestDbContext(builder.Options);
        _customerService = new CustomerService(_context);
    }

    [Test]
    public void NonRegisteredCustomer()
    {
        //Arrange
        var customerId = 21;
        var purchaseValue = 100;

        //Act & Assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await _customerService.CanPurchase(customerId, purchaseValue));
    }

    [Test]
    public async Task CustomerPurchasedThisMonth()
    {
        //Arrange
        var purchaseValue = 100;
        var customer = new Customer { Name = "Test Costumer"};
        _context.Customers.Add(customer);

        var order = new Order { CustomerId = customer.Id, OrderDate = DateTime.UtcNow };
        _context.Orders.Add(order);

        await _context.SaveChangesAsync();

        //Act
        var result = await _customerService.CanPurchase(customer.Id, purchaseValue);

        //Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task CustomerNeverBoughtBefore()
    {
        //Arrange
        var customer = new Customer { Name = "Test Costumer"};
        _context.Customers.Add(customer);

        var purchaseValue = 50;

        //Act
        var result = await _customerService.CanPurchase(customer.Id, purchaseValue);

        //Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task CustomerBoughtBefore()
    {
        //Arrange
        var customer = new Customer { Name = "Test Costumer"};
        _context.Customers.Add(customer);

        var purchaseValue = 150;

        var order = new Order { CustomerId = customer.Id, OrderDate = DateTime.UtcNow.AddMonths(-2) };
        _context.Orders.Add(order);

        await _context.SaveChangesAsync();

        //Act
        var result = await _customerService.CanPurchase(customer.Id, purchaseValue);

        //Assert
        Assert.IsTrue(result);
    }
}
