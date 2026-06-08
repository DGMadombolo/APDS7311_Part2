using APDS7311_Part2.Models;
using Xunit;
//unit testing
namespace APDS7311_Part2.Tests;

public class ModelTests
{
    [Fact]
    public void Payment_DefaultDate_IsSet()
    {
        var payment = new Payment();
        Assert.True(payment.Date <= DateTime.Now);
    }

    [Fact]
    public void User_DefaultCreatedAt_IsSet()
    {
        var user = new User();
        Assert.True(user.CreatedAt <= DateTime.Now);
    }
}
