using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class StartupTests
    {             

        [Fact]
        public void ConvertHerokuStringToASPNETString()
        {
            //Assume
            string herokuConnectionString = "postgres://guzicjpciyunjb:b1814010c666cf7e1fb65e65e55d7cad28aacf3cabf50f793e0af41cd6ff12a6@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/d541rnk2ltdsv7";

            //Act
            string aspnetConnectionString = Startup.ConvertHerokuStringToAspnetString(herokuConnectionString);

            //Assert
            Assert.Equal("Host=ec2-34-251-245-108.eu-west-1.compute.amazonaws.com;Port=5432;Username=guzicjpciyunjb;Password=b1814010c666cf7e1fb65e65e55d7cad28aacf3cabf50f793e0af41cd6ff12a6;Database=/d541rnk2ltdsv7;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;", aspnetConnectionString);

        }

    }
}
