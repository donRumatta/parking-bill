using FluentAssertions;
using NUnit.Framework;

namespace ParkingBill.Tests;

[TestFixture]
public class ParkingTests
{
    [Test]
    public void CalculateCost_Test1()
    {
        var cost = Parking.CalculateCost("10:00", "13:21");

        cost.Should().Be(17);
    }

    [Test]
    public void CalculateCost_Test2()
    {
        var cost = Parking.CalculateCost("09:42", "11:42");

        cost.Should().Be(9);
    }

    [Test]
    public void CalculateCost_Test3()
    {
        var cost = Parking.CalculateCost("09:15", "09:42");

        cost.Should().Be(5);
    }

    [Test]
    public void CalculateCost_Test4()
    {
        var cost = Parking.CalculateCost("09:00", "10:00");

        cost.Should().Be(5);
    }

    [Test]
    public void CalculateCost_Test5()
    {
        var cost = Parking.CalculateCost("09:00", "09:59");

        cost.Should().Be(5);
    }

    [Test]
    public void CalculateCost_Test6()
    {
        var cost = Parking.CalculateCost("09:59", "10:00");

        cost.Should().Be(5);
    }

    [Test]
    public void CalculateCost_Test7()
    {
        var cost = Parking.CalculateCost("09:59", "11:00");

        cost.Should().Be(9);
    }

    [Test]
    public void CalculateCost_Test8()
    {
        var cost = Parking.CalculateCost("09:59", "11:59");

        cost.Should().Be(9);
    }

    [Test]
    public void CalculateCost_Test9()
    {
        var cost = Parking.CalculateCost("10:00", "11:01");

        cost.Should().Be(9);
    }
}