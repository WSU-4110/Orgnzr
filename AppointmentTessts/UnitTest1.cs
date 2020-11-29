//using NUnit.Framework;
//using System;
//using Orgnzr.Data;
//using Orgnzr.Controllers;
//using Orgnzr.Models;

//namespace AppointmentTessts
//{
//    public class Tests
//    {
//        [Test]
//        public void Setup()
//        {
//            var model = new Orgnzr.Models.Appointment { appointmentID = 1, appointmentStartTime = new DateTime(2020, 12, 1, 8, 30, 0), appointmentFinishTime = new DateTime(2020, 12, 1, 9, 0, 0), clientId = 1, serviceId = 1, waitlistAppt = Orgnzr.Models.waitlistAppt.No };
//            var controller = new Orgnzr.Controllers.AppointmentsController();

//            var result = controller.AddToWaitlistAsync(1);
//            Assert.AreEqual(1, model.appointmentID);
//        }

//        //[Test]
//        //public void Test1()
//        //{
//        //    Assert.AreEqual(1)
//        //}
//    }
//}