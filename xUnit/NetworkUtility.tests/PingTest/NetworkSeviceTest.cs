using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.tests.PingTest
{
    public class NetworkSeviceTest
    {
        [Fact]
        public void Networkservice_SendPing_retunString()
        {
            // arrange
            var PingService = new Networksevice();
            

            // act
            var result = PingService.SendPing();

            // assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Sucess : Ping Sent!");

        }
        [Theory]
        [InlineData(1,1,2)]
        public void Networkservice_PingTimeOut_retunsInt(int a, int b, int expected)
        {
            // Arrange
            var pingService = new Networksevice();


            // Act
            int result = pingService.PingTimeout(a, b);


            // Assert
            result.Should().Be(expected);
        
        }
    }
}
