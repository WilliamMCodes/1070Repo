using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace StructuredProject1.Logic.TestsForStudents
{
    public class CustomerTests
    {        
        [Fact]
        public void GetSetId_ShouldSetAndReturnCorrectId()
        {
            try
            {
                //Assemble
                Customer customer = new Customer();
                int expected = 65432;
                //Act
                customer.Id = expected;
                int actual = customer.Id;
                //Assert
                Assert.Equal(expected, actual);
            }catch
            {
                throw new XunitException("The Correct Id Was not given.");
            }
        }

        [Fact]
        public void GetSetName_ShouldSetAndReturnCorrectName()
        {
            try
            {
                //Assemble
                Customer customer = new Customer();
                var expected = "David Everton";

                //Act
                customer.Name =expected;
                var actual = customer.Name;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Name was not given");
            }
        }

        [Fact]
        public void GetSetAddress_ShouldSetAndReturnCorrectAddress()
        {
            try
            {
                //Assemble
                Customer customer = new Customer();
                var expected = "1600 Pennsylvania Ave";

                //Act
                customer.Address = expected;
                var actual = customer.Address;

                //Assert
                Assert.Equal(expected, actual);
            } catch
            {
                throw new XunitException("The Correct Address was not given");
            }
        }
    }
}
