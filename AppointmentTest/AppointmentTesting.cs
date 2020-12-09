using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orgnzr.Data;
using Orgnzr.Models;
using System.Web;
using System.Net.Mail;
using Orgnzr.Controllers;

namespace AppointmentTests
{
    public class AppointmentTesting 
    {

        [Test]
        public void Test1()
        {
            Orgnzr.Models.Appointment appointment = new Appointment();


            appointment.appointmentID = 1;

            
            Assert.AreEqual(1, appointment.appointmentID);
        }

        [Test]
        public void Test2()
        {
            Orgnzr.Models.Appointment appointment = new Appointment();


            appointment.appointmentStartTime = new DateTime(2020, 12, 21);
            DateTime expected = new DateTime(2020, 12, 21);
            Assert.AreEqual(expected, appointment.appointmentStartTime);
        }
        [Test]
        public void Test3()
        {
            Orgnzr.Models.Appointment appointment = new Appointment();


            appointment.appointmentFinishTime = new DateTime(2020, 12, 21);
            DateTime expected = new DateTime(2020, 12, 21);
            Assert.AreEqual(expected, appointment.appointmentFinishTime);
        }
        [Test]
        public void Test4()
        {
            Orgnzr.Models.Appointment appointment = new Appointment();


            appointment.clientId = 1;
            Assert.AreEqual(1, appointment.clientId);
        }
        [Test]
        public void Test5()
        {
            Orgnzr.Models.Appointment appointment = new Appointment();


            appointment.serviceId = 1;
            Assert.AreEqual(1, appointment.serviceId);
        }
        [Test]
        public void Test6()
        {
            Orgnzr.Models.Appointment appointment = new Appointment();


            appointment.waitlistAppt = waitlistAppt.No;
            Assert.AreEqual(waitlistAppt.No, appointment.waitlistAppt);
        }
    }
}