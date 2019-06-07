using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using WebApplication1.Model;
using System.Data.SqlClient;
using System.Data;

namespace MeassurementUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAll()
        {
            MeassurementFunctions.GetConnection();

            

            List<Meassurement> mlist = MeassurementFunctions.GetAll();

            Assert.AreEqual(4, mlist.Count);
            //var GetAll = MeassurementFunctions.GetAll();
            // var expected = 4;
            // var actual = GetAll;
            // Assert.AreEqual(expected, actual);
        }

        public void TestGetOne()
        {
            MeassurementFunctions.GetConnection();


        }
    }
}
