using LatinCMS.Models;
using NHibernate;
using NHibernate.Criterion;

namespace LatinCMS.DAOs 
{
    public class UsuarioDAO : BaseDAO<UsuarioModel>
    {
        public UsuarioModel GetByMail(string mail)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(UsuarioModel));
                
                UsuarioModel user = criteria.Add(Restrictions.Eq("Mail", mail))
                                   .UniqueResult<UsuarioModel>();

                return user;         
            }
                
        }
    }
}