using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using Iesi.Collections;

namespace OCFInventory.Models.NHibernate
{
    public class NHibernateHelper
    {
        //Define the session factory, this is per database 
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {

            get
            {
                if (_sessionFactory == null)
                {
                    var NHibernateConfig = new Configuration();
                    NHibernateConfig.Configure(HttpContext.Current.Server.MapPath(@"Models\NHibernate\Configuration\hibernate.cfg.xml"));
                    NHibernateConfig.AddDirectory(new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(@"Models\NHibernate\Mappings")));
                    _sessionFactory = NHibernateConfig.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}