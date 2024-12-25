using System.Collections.Generic;
using Moq;
using UnitTestConsoleApp.SystemUnderTest;

namespace UnitTestConsoleApp.Tests.MoqSystemUnderTest.Advanced
{
    public class A_RollingMocks
    {
        [Theory]
        [InlineData(0,12,"Bob")]
        [InlineData(1,17,"Sue")]
        [InlineData(2,100065,"Tony")]
        public void Should_Enable_Rolling_Mocks(int index, int id, string name)
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 12, Name = "Bob"},
                new Customer {Id = 17, Name = "Sue"},
                new Customer {Id = 100065, Name = "Tony"},
            };
            
            var mock = new Mock<IRepo>();
            var returnMo= mock.Setup(x => x.Find(It.IsInRange(0, 2, Moq.Range.Inclusive)))
                .Returns((int x) => customers[x]);
  
            var controller = new TestController(mock.Object);
            var customer= controller.GetCustomer(index);
            Assert.Equal(id,customer.Id);
            Assert.Equal(name,customer.Name);
        }
    }
}