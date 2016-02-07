using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;

namespace DAL.Realization
{
    public class UnitOfWork: IUnitOfWork
    {
        private bool isDisposed = false;
        public DbContext Context { get; private set; }
        public UnitOfWork(DbContext context)
        {
            Context = context;            
        }

        public void Commit()
        {
            if (Context != null)
            {
                try
                {
                    Context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                {
                   if (Context != null)
                   {
                       Context.Dispose();
                   }
                }
                isDisposed = true;
            }
        }
    }
}
