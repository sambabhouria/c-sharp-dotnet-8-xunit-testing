#region Copyright
// Copyright Information
// ==================================
// UnitTestConsoleApp
// ==================================
#endregion

using System.Linq.Expressions;

namespace  UnitTestConsoleApp.SystemUnderTest
{
    public interface IRepo
    {
        event EventHandler FailedDatabaseRequest;
        int TenantId { get; set; }
        Customer Find(int id);
        IList<Customer> GetSome(Expression<Func<Customer, bool>> where);
        void AddRecord(Customer customer);
    }
}