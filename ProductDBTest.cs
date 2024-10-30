using NUnit.Framework;

using MMABooksProps;
using MMABooksDB;

using DBCommand = MySql.Data.MySqlClient.MySqlCommand;
using System.Data;

using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace MMABooksTests
{
    [TestFixture]
    internal class ProductDBTest
    {
        ProductDB db;

        [SetUp]
        public void ResetData()
        {
            db = new ProductDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData"; 
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

     /*   [Test]
        public void TestCreate()
        {
            ProductProps p = new ProductProps();
            p.ProductCode = "r5d7";
            p.Description = "dfagfdagdafg";
            p.UnitPrice = 12m;
            p.OnHandQuantity = 12;

            db.Create(p);
            ProductProps p2 = (ProductProps)db.Retrieve(p.ProductCode);
            Assert.AreEqual(p.GetState(), p2.GetState());
        }
     */
        [Test]
        public void TestRetrieve()
        {
            ProductProps p = (ProductProps)db.Retrieve("A4CS"); 
            Assert.AreEqual("A4CS", p.ProductCode);
           // Assert.AreEqual("Sample Product", p.Description); 
        }

        
    }
}
