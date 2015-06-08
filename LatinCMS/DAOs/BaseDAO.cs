using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LatinCMS.DAOs
{
    public class BaseDAO<T>
    {
        
            public void Save(T objeto)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(objeto);
                    transaction.Commit();
                }
            }


            public T Get(Guid id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.Get<T>(id);
            }


            public void Update(T objeto)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(objeto);
                    transaction.Commit();
                }
            }


            public void Delete(T objeto)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(objeto);
                    transaction.Commit();
                }
            }


            
        }
    
}