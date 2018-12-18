namespace ContactList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using ContactList.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactList.DAL.ContactListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactList.DAL.ContactListContext context)
        {
            var emails = new List<Email>()
            {
                new Email() { Adress = "carlsonalex@gmail.com"},
                new Email() { Adress = "c4rls0n@gmail.com"},
                new Email() { Adress = "meredthalon@gmail.com"}
            };

            var phonenumbers = new List<PhoneNumber>()
            {
                new PhoneNumber() { Number = "0912223333"},
                new PhoneNumber() { Number = "0954443333"},
                new PhoneNumber() { Number = "0953334444"}
            };


            var contacts = new List<Contact>()
            {
                new Contact()
                {
                    FirstName = "Carson",   LastName = "Alexander",
                    Adress = "Vukovarska 1" , Tag = "Prijatelj",
                    Emails = new List<Email>() { emails[0], emails[1] },
                    PhoneNumbers = new List <PhoneNumber>() { phonenumbers[0] }
                },
                new Contact()
                {
                    FirstName = "Meredith", LastName = "Alonso",
                    Adress = "Velebitska 2",
                    Emails = new List<Email>() { emails[2] },
                    PhoneNumbers = new List <PhoneNumber>() { phonenumbers[1], phonenumbers[2] }
                }
            };

            context.Emails.AddRange(emails);
            context.PhoneNumbers.AddRange(phonenumbers);
            context.Contacts.AddRange(contacts);

            context.SaveChanges();
        }
    }
}
