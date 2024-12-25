#region Copyright
// --------------------------------------------------------------------------------------------------------------------
#endregion

using System.Net.Sockets;

namespace UnitTestConsoleApp.SystemUnderTest
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Address AddressNavigation { get; set; }
    }
}