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

            var clients = new ClientContact[]
            {
            new ClientContact{clientId = 1, firstName="Carson",lastName="Alexander",emailAddress="test@gmail.com",phoneNumber="222-333-4444",preferredContact=preferredContact.Text},
            new ClientContact{clientId = 2, firstName="Carson",lastName="Backster",emailAddress="test1@gmail.com",phoneNumber="222-333-4445",preferredContact=preferredContact.Email},
            new ClientContact{clientId = 3, firstName="Carson",lastName="Ladasma",emailAddress="test2@gmail.com",phoneNumber="222-333-4446",preferredContact=preferredContact.Phone},
            new ClientContact{clientId = 4, firstName="Carson",lastName="O'Patches",emailAddress="test3@gmail.com",phoneNumber="222-333-4447",preferredContact=preferredContact.Text},
            new ClientContact{clientId = 5, firstName="Carson",lastName="Smith",emailAddress="test4@gmail.com",phoneNumber="222-333-4448",preferredContact=preferredContact.Text},
            
            };
            foreach (ClientContact c in clients)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();

        }
    }
    }
