using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform;
using Orgnzr.Data;
using Orgnzr.Models;
using System.Web;
using System.Net.Mail;
using Orgnzr.Controllers;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;



namespace Orgnzr.Controllers.Tests
{
    [TestFixture()]
    public class InventoryControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Orgnzr.Models.Inventory inventory = new Inventory();


            inventory.inventoryID = 1;
            Assert.AreEqual(1, inventory.inventoryID);
        }
        [Test]
        public void Test2()
        {
            Orgnzr.Models.Inventory inventory = new Inventory();


            inventory.restockAmount = 1;
            Assert.AreEqual(1, inventory.restockAmount);
        }
        [Test]
        public void Test3()
        {
            Orgnzr.Models.Inventory inventory = new Inventory();


            inventory.inStockAmount = 1;
            Assert.AreEqual(1, inventory.inStockAmount);
        }
        [Test]
        public void Test4()
        {
            Orgnzr.Models.Inventory inventory = new Inventory();


            inventory.productID = 1;
            Assert.AreEqual(1, inventory.productID);
        }
        [Test]
        public void Test5()
        {
            Orgnzr.Models.Inventory inventory = new Inventory();


            inventory.productName = "liner";
            Assert.AreEqual("liner", inventory.productName);
        }

    }
}