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
    public class ClientControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Orgnzr.Models.ClientContact client = new ClientContact();


            client.clientId = 1;
            Assert.AreEqual(1, client.clientId);
        }
        [Test]
        public void Test2()
        {
            Orgnzr.Models.ClientContact client = new ClientContact();


            client.firstName = "Sam";
            Assert.AreEqual("Sam", client.firstName);
        }
        [Test]
        public void Test3()
        {
            Orgnzr.Models.ClientContact client = new ClientContact();


            client.lastName = "Church";
            Assert.AreEqual("Church", client.lastName);
        }
        [Test]
        public void Test4()
        {
            Orgnzr.Models.ClientContact client = new ClientContact();


            client.phoneNumber = "2317158121";
            Assert.AreEqual("2317158121", client.phoneNumber);
        }
        [Test]
        public void Test5()
        {
            Orgnzr.Models.ClientContact client = new ClientContact();


            client.emailAddress = "church.richard.s@gmail.com";
            Assert.AreEqual("church.richard.s@gmail.com", client.emailAddress);
        }
        [Test]
        public void Test6()
        {
            Orgnzr.Models.ClientContact client = new ClientContact();


            client.preferredContact = preferredContact.Text;
            Assert.AreEqual(preferredContact.Text, client.preferredContact);
        }

    }
}