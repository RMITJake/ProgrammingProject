using Xunit;
using PatientConnect.Models;
namespace PatientConnect.Tests;

public class Test
{
    [Fact]
    public void InitialTrue()
    {
        bool test = true;
        Assert.True(test, "test is false");
    }
}