using System;
using DDDBook.Domain;
using NUnit.Framework;

namespace DDDBook.Tests;

[TestFixture]
public class Tests
{
    /// ヘルパーメソッド
    public void _FakeAnOrder
        (int orderNumber, Customer customer, IOrderRepository repository)
    {
        Order o = new Order(customer);
        RepositoryHelper.SetFieldWhenReconstitutingFromPersistence
            (o, "_orderNumber", orderNumber);
        repository.AddOrder(o);
    }
    private Customer _FakeACustomer(int customerNumber)
    {
        Customer c = new Customer();
        RepositoryHelper.SetFieldWhenReconstitutingFromPersistence
            (c, "_customerNumber", customerNumber);
        return c;
    }

    public IOrderRepository _repository;

    [SetUp]
    public void Setup()
    {
        //_repository = new OrderRepository();
        _repository = new OrderRepositoryFake();
    }

    [Test]
    public void CanCreateOrder()
    {
        //Order o = OrderFactory.CreateOrder(new Customer());
        Order o = new Order(new Customer());
        Assert.IsNotNull(o);
    }
    [Test]
    public void CanCreateOrderWithCustomer()
    {
        Order o = new Order(new Customer());

        Assert.IsNotNull(o.Customer);
    }
    [Test]
    public void OrderDateIsCurrentAfterCreation()
    {
        DateTime theTimeBefore = DateTime.Now;
        Order o = new Order(new Customer());

        Assert.IsTrue(o.OrderDate > theTimeBefore);
        Assert.IsTrue(o.OrderDate
            < DateTime.Now.AddMilliseconds(1));
    }
    [Test]
    public void OrderNumberIsZeroAfterCreation()
    {
        Order o = new Order(new Customer());

        Assert.AreEqual(0, o.OrderNumber);
    }
    [Test]
    //[Ignore("Ignore a test")]
    public void OrdeFrNumberCanBeZeroAfterReconstitution()
    {
        int theOrderNumber = 42;
        _FakeAnOrder(theOrderNumber, new Customer(), _repository);
        Order o = _repository.GetOrder(theOrderNumber);

        Assert.AreEqual(theOrderNumber, o.OrderNumber);
    }
    [Test]
    [Ignore("Ignore a test")]
    public void CanAddOrder()
    {
        //_repository.AddOrder(new Order(new Customer()));
        //Assert.IsTrue(true);
    }
    [Test]
    public void CanFindOrdersViaCustomer()
    {
        //Customer c = new Customer();
        Customer c = _FakeACustomer(7);
        _FakeAnOrder(42, c, _repository);
        _FakeAnOrder(12, new Customer(), _repository);
        _FakeAnOrder(3, c, _repository);
        _FakeAnOrder(21, c, _repository);
        _FakeAnOrder(1, new Customer(), _repository);
        Assert.AreEqual(3, _repository.GetOrders(c).Count);
    }
    [Test]
    public void EmptyAmountHasZeroForTotalAmount()
    {
        Order o = new Order(new Customer());
        Assert.AreEqual(0, o.TotalAmount);
    }
    [Test]
    //[Ignore("skip")]
    public void OrderWithLinesHasTotalAmount()
    {
        Order o = new Order(new Customer());

        OrderLine ol = new OrderLine(new Product("Chair", 52.00));
        ol.NumberOfUnits = 2;
        o.AddOrderLine(ol);
        OrderLine ol2 = new OrderLine(new Product("Desc", 115.00));
        ol2.NumberOfUnits = 3;
        o.AddOrderLine(ol2);

        Assert.AreEqual(104.00 + 345.00, o.TotalAmount);
    }
    [Test]
    public void CanAddOrderLine()
    {
        Order o = new Order(new Customer());
        OrderLine ol = new OrderLine(new Product("Chair", 52.00));
        o.AddOrderLine(ol);
        Assert.AreEqual(1, o.OrderLines.Count);
    }
    [Test]
    public void OrderLineGetsDefaultPrice()
    {
        Product p = new Product("Chair", 52.00);

        OrderLine ol = new OrderLine(p);
        Assert.AreEqual(52.00, ol.Price);
    }
    [Test]
    public void OrderLineHasTotalAmount()
    {
        OrderLine ol = new OrderLine(new Product("Chair", 52.00));
        ol.NumberOfUnits = 2;

        Assert.AreEqual(104.00, ol.TotalAmount);
    }
    [Test]
    public void OrderHasSnapShotOfRealCustomer()
    {
        Customer c = new Customer();
        c.Name = "Volvo";

        //CustomerSnapshot aHistoricCustomer = c.TakeSnapshot();
        //Order o = new Order(aHistoricCustomer);
        Order o = new Order(c);

        c.Name = "Saab";

        Assert.AreEqual("Saab", c.Name);
        Assert.AreEqual("Volvo", o.Customer.Name);
    }
}
