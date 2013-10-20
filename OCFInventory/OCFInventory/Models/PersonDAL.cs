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
    public class PersonDAL
    {
        
        public IList<Person> GetPeople()
        {
            IList<Person> People;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //NHibernate query 
                IQuery query = session.CreateQuery("from Person");
                People = query.List<Person>();
            }
            return People;
        }
        public Person GetPersonById(int Id)
        {
            Person person = new Person();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                person = session.Get<Person>(Id);
            }
            return person;
        }
        public int CreatePerson(Person person)
        {
            int PersonId = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //Perform transaction 
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Save(person);
                    tran.Commit();
                }
            }
            return PersonId;
        }
        public void UpdatePerson(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(person);
                    tran.Commit();
                }
            }
        }
        public void DeletePerson(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(person);
                    tran.Commit();
                }
            }
        }
    } 

}