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
            if (context.Contacts.Any() && context.Product.Any())
            {
                return;   // DB has been seeded
            }

            //initialization of the contacts table for the ClientContact entity
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

            //initialization of the inventory table for the Inventory entity
            var Product = new Product[]
            {
                new Product{productID = 1, productName="Billion Dollar Beauty Sponge", productDescription = "Blue sponge for cleaning makeup", productCategory = "Tools", productBrand = "Billion Dollar Brows", buyPrice = 10.00, sellPrice = 15.00, inStockAmount = 5, restockAmount =2 },
                new Product{productID = 2, productName="Bronzilla", productDescription = "Tan packaging with half naked woman", productCategory = "Face", productBrand = "The Balm", buyPrice = 13.50, sellPrice = 17.00, inStockAmount = 10, restockAmount =2 },
                new Product{productID = 3, productName="First Love", productDescription = "Medium pink with black cap", productCategory = "Lips", productBrand = "Major Shade", buyPrice = 16.00, sellPrice = 20.00, inStockAmount = 5, restockAmount =2 },
            };
            foreach (Product item in Product)
            {
                context.Product.Add(item);
            }
            context.SaveChanges();

        }
    }
    }
