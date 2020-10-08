using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orgnzr.Models;
using Orgnzr.Data;
using Microsoft.EntityFrameworkCore;

namespace Orgnzr.Project.Data
{
    public static class clientDbInitializer
    {

        public static void Initialize(contactContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Contacts.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new clientContact[]
            {
            new clientContact{firstName="Carson",lastName="Alexander",emailAddress="test@gmail.com",phoneNumber="222-333-4444",preferredContact=preferredContact.Text},
            new clientContact{firstName="Carson",lastName="Backster",emailAddress="test1@gmail.com",phoneNumber="222-333-4445",preferredContact=preferredContact.Email},
            new clientContact{firstName="Carson",lastName="Ladasma",emailAddress="test2@gmail.com",phoneNumber="222-333-4446",preferredContact=preferredContact.Phone},
            new clientContact{firstName="Carson",lastName="O'Patches",emailAddress="test3@gmail.com",phoneNumber="222-333-4447",preferredContact=preferredContact.Text},
            new clientContact{firstName="Carson",lastName="Smith",emailAddress="test4@gmail.com",phoneNumber="222-333-4448",preferredContact=preferredContact.Text},
            
            };
            foreach (clientContact c in clients)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();

        }
    }
    }
