using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.EntityFramework
{
    public class RepositoryBase : IDisposable
    {
        protected ImperialDatabaseContext _context;

        protected RepositoryBase(ImperialDatabaseContext context)
        {
            _context = context;
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Context'in dispose edilmesi
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        // IDisposable.Dispose metodunun implementasyonu
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
