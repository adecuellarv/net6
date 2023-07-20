using NUnit.Framework;
using MyApp;
using Moq;
namespace Program.Test;

public class Tests
{
    private MyApp.Program _program;
    MyApp.Program p = new MyApp.Program();

    [SetUp]
    public void Setup()
    {
        
         _program = new MyApp.Program();
    }

    [Test]
    public void showAllList()
    {
       Moq.Mock.Equals(1, 1);
  
        /*
        Mock.Setup(e => _program.showAllList()).Returns(6);
        var result = _program.showAllList();
        Assert.Pass(result , Is.GreaterThan(5));*/
    }
}