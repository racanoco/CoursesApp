using Common.Model;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    public class Address: ValueObject
    {
        #region PROPERTIES
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }  
        public string ZipCode { get; private set; }
        #endregion

        #region BUILDER
        public Address()
        {

        }
        public Address(string street, string city, string state, string country, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return new object[] { Street, City, State, Country, ZipCode };
        }

        #endregion
    }
}
