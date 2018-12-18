using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ContactList.Models;

namespace ContactList.DAL
{
  public class ContactListContextSeeder : CreateDatabaseIfNotExists<ContactListContext>
  {
    protected override void Seed(ContactListContext context)
    {
      IList<Contact> defaultContacts = new List<Contact>();
      defaultContacts.Add(new Contact()
      {
        FirstName = "Carson",
        LastName = "Alexander",
        Adress = "Vukovarska 1",
        Tag = "Prijatelj",
        Emails = new List<Email>() {new Email() { Adress = "carlsonalex@gmail.com"},
                                    new Email() { Adress = "c4rls0n@gmail.com"}},
        PhoneNumbers = new List<PhoneNumber>() {new PhoneNumber() { Number = "0912223333" }}
      });
      defaultContacts.Add(new Contact()
      {
        FirstName = "Meredith",
        LastName = "Alonso",
        Adress = "Velebitska 2",
        Emails = new List<Email>() {new Email(){ Adress = "meredthalon@gmail.com" }},
        PhoneNumbers = new List<PhoneNumber>() { new PhoneNumber() { Number = "0954443333"},
                                                 new PhoneNumber() { Number = "0953334444"}}
      });

      context.Contacts.AddRange(defaultContacts);

      base.Seed(context);
    }
  }
}
