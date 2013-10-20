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
    public class GroupInfoDAL
    {
 
        public IList<GroupInfo> GetGroups()
        {
            IList<GroupInfo> Groups;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //NHibernate query 
                IQuery query = session.CreateQuery("from GroupInfo");
                Groups = query.List<GroupInfo>();
            }
            return Groups;
        }
        public GroupInfo GetGroupById(int Id)
        {
            GroupInfo Grp = new GroupInfo();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                Grp = session.Get<GroupInfo>(Id);
            }
            return Grp;
        }
        public int CreateGroup(GroupInfo Grp)
        {
            int GrpNo = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //Perform transaction 
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Save(Grp);
                    tran.Commit();
                }
            }
            return GrpNo;
        }
        public void UpdateGroup(GroupInfo Grp)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(Grp);
                    tran.Commit();
                }
            }
        }
        public void DeleteGroup(GroupInfo Grp)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(Grp);
                    tran.Commit();
                }
            }
        }
    } 

}