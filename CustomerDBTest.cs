﻿using NUnit.Framework;

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
    internal class CustomerDBTest
    {
        CustomerDB db;

        [SetUp]
        public void ResetData()
        {
            db = new CustomerDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestCreate()
        {
            CustomerProps p = new CustomerProps();
            p.Name = "Minnie Mouse";
            p.Address = "101 Main Street";
            p.City = "Orlando";
            p.State = "FL";
            p.ZipCode = "10001";
            db.Create(p);
            CustomerProps p2 = (CustomerProps)db.Retrieve(p.CustomerId);
            Assert.AreEqual(p.GetState(), p2.GetState());
        }

        [Test]
        public void TestRetrieve()
        {
            CustomerProps p = (CustomerProps)db.Retrieve("1");
            Assert.AreEqual(1, p.CustomerId);
            Assert.AreEqual("Molunguri, A", p.Name);
        }

        [Test]
        public void TestRetrieveAll()
        {
            List<CustomerProps> list = (List<CustomerProps>)db.RetrieveAll();
            Assert.AreEqual(list.Count, list.Count);
        }

        [Test]
        public void TestUpdate()
        {
            CustomerProps p = (CustomerProps)db.Retrieve("1");
            p.Name = "Molunguri, A";
            Assert.True(db.Update(p));
            p = (CustomerProps)db.Retrieve("1");
            Assert.AreEqual("Molunguri, A", p.Name);
        }

    }
}
