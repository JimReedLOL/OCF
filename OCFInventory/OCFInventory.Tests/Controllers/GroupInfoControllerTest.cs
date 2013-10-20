using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OCFInventory;
using OCFInventory.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Cfg;
using Iesi.Collections;
using OCFInventory.Models;
using OCFInventory.Models.NHibernate;


namespace OCFInventory.Tests.Controllers
{
    [TestClass]
    public class GroupInfoControllerTest
    {
        [TestMethod]
        public void Index()
        {

            // Arrange
            GroupInfoController controller = new GroupInfoController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var GroupInfo = (List<GroupInfo>)result.ViewData.Model;
            // Assert
            var matches = GroupInfo.Where(p => p.Name == "weevil");
            Assert.IsTrue(matches.Count() > 0);

            
           

        }


    }
}
