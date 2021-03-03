using Escola.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Repository
{
    public class TesteSingletonRepository : ITesteSingletonRepository
    {
        private readonly Guid _guid;
        public TesteSingletonRepository()
        {
            _guid = Guid.NewGuid();
        }
    }
}
