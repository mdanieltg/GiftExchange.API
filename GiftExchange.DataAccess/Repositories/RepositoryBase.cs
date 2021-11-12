using System;

namespace GiftExchange.DataAccess
{
    public abstract class RepositoryBase
    {
        protected RepositoryBase(GiftExchangeContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected GiftExchangeContext Context { get; }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
