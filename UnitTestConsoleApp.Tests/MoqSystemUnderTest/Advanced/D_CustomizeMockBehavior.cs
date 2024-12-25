using Moq;
using UnitTestConsoleApp.SystemUnderTest;

namespace  UnitTestConsoleApp.Tests.MoqSystemUnderTest.Advanced
{
    public class D_CustomizeMockBehavior
    {

        [Fact]
        public void Should_Not_Error_When_Using_Loose_Mocks_And_Not_Setting_Up_Method()
        {
            var mockRepo = new Mock<IRepo>(MockBehavior.Loose);
            var controller = new TestController(mockRepo.Object);
            var customer = controller.GetCustomer(12);
            Assert.Null(customer);

        }
        [Fact]
        public void Should_Error_When_Using_Strict_Mocks_And_Not_Setting_Up_Method()
        {
            var mockRepo = new Mock<IRepo>(MockBehavior.Strict);
            var controller = new TestController(mockRepo.Object);
            var id = 12;
            mockRepo.Setup(x => x.Find(14)).Returns(new Customer());
            var ex = Assert.Throws<MockException>(()=>controller.GetCustomer(id));
            // Assert.Equal($"IRepo.Find(12) invocation failed with mock behavior Strict.\nAll invocations on the mock must have a corresponding setup.",ex.Message);
            Assert.Equal($"IRepo.Find(12) invocation failed with mock behavior Strict.\r\nAll invocations on the mock must have a corresponding setup.",ex.Message);


        }
    }
}