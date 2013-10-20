using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using Iesi.Collections;
using OCFInventory.Models.NHibernate;

namespace OCFInventory.Models
{
    /// <summary> 
    /// class to perform the CRUD operations 
    /// </summary> 
    public class DomainDAL
    {
        
        public IList<Domain> GetDomains()
        {
            IList<Domain> Domains;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //NHibernate query 
                IQuery query = session.CreateQuery("from Domain");
                Domains = query.List<Domain>();
            }
            return Domains;
        }
        public Domain GetDomainById(int Id)
        {
            Domain domain = new Domain();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                domain = session.Get<Domain>(Id);
            }
            return domain;
        }
        public int CreateDomain(Domain domain)
        {
            int DomainId = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //Perform transaction 
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Save(domain);
                    tran.Commit();
                }
            }
            return DomainId;
        }
        public void UpdateDomain(Domain domain)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(domain);
                    tran.Commit();
                }
            }
        }
        public void DeleteDomain(Domain domain)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(domain);
                    tran.Commit();
                }
            }
        }
    } 

}