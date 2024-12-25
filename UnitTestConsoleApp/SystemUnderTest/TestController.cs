#region Copyright
// Copyright Information
// ==================================

// ==================================
#endregion

using System;
using Castle.Core.Logging;

namespace UnitTestConsoleApp.SystemUnderTest
{
    public class TestController
    {
        private readonly IRepo _repo;
        private readonly ILogger _logger;

        public TestController(IRepo repo, ILogger logger = null)
        {
            _repo = repo;
            _logger = logger;
            _repo.FailedDatabaseRequest += _repo_FailedDatabaseRequest;
        }

        private void _repo_FailedDatabaseRequest(object sender, EventArgs e)
        {
            _logger.Error("An error occurred");
        }

        public int TenantId() => _repo.TenantId;
        public void SetTenantId(int id) => _repo.TenantId = id;

        public Customer GetCustomer(int id)
        {
            try
            {
                //_repo.AddRecord(new Customer());
                //var c = _repo.Find(id);
                //return new Customer { Id = 12, Name = "Fred FlintStone" };
                // return _repo.Find(12); (this is the original code that was replaced by the next line for testing)  
                return _repo.Find(id);
            }
            catch (Exception ex)
            {
                //_logger.Debug("There was an exception");
                throw;
            }
        }

        public void SaveCustomer(Customer customer)
        {
            _repo.AddRecord(customer);
        }
    }
}