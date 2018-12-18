using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using ContactList.DAL;
using ContactList.Models;
using System.Net.Http;
using System.Web.Http;

namespace ContactList.Controllers
{
  public class ContactsController : ApiController
  {
    private ContactListContext db = new ContactListContext();

    // GET: Contacts/Tag
    [HttpGet]
    [Route("api/getContacts/{selectedTag}")]
    public IEnumerable<Contact> GetContacts(string selectedTag)
    {
      if (selectedTag == "All")
      {
        var allContacts = db.Contacts.Include(c => c.Emails).Include(c => c.PhoneNumbers);

        return allContacts.ToList();
      }

      var filteredContacts = db.Contacts.Include(c => c.Emails).Include(c => c.PhoneNumbers)
                                        .Where(c => c.Tag == selectedTag);

      return filteredContacts.ToList();
    }

    // GET: Contacts/Tag/Keyword
    [HttpGet]
    [Route("api/getContacts/{selectedTag}/{keyword}")]
    public IEnumerable<Contact> GetContacts(string selectedTag, string keyword)
    {
      if (selectedTag == "All")
      {
        var filteredContactsAll = db.Contacts.Include(c => c.Emails).Include(c => c.PhoneNumbers)
                                             .Where(c => c.FirstName.ToLower().Contains(keyword.ToLower()) ||
                                                         c.LastName.ToLower().Contains(keyword.ToLower()) ||
                                                         c.Tag.ToLower().Contains(keyword.ToLower()));

        return filteredContactsAll.ToList();
      }
      var filteredContacts = db.Contacts.Include(c => c.Emails).Include(c => c.PhoneNumbers)
                                        .Where(c => c.Tag == selectedTag &&
                                                   (c.FirstName.ToLower().Contains(keyword.ToLower()) ||
                                                    c.LastName.ToLower().Contains(keyword.ToLower())));

      return filteredContacts.ToList();
    }

    // POST: Contacts/Add
    [HttpPost]
    [Route("api/addNewContact")]
    public HttpResponseMessage AddNewContact([FromBody]Contact contact)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateResponse(HttpStatusCode.OK, ModelState);
      }

      db.Contacts.Add(contact);
      db.SaveChanges();

      return Request.CreateResponse(HttpStatusCode.OK, "success");
    }

    // GET: Contact/ID
    [HttpGet]
    [Route("api/contact/{ID}")]
    public Contact GetContactById(int ID)
    {
      if (ID<0)
      {
        Request.CreateResponse("Wrong ID parameter was sent from the client.");
      }

      var contactById = db.Contacts.Include(c => c.Emails).Include(c => c.PhoneNumbers)
                                   .Where(c => c.ID == ID).FirstOrDefault();

      return contactById;
    }

    // POST: Contact/Delete/ID
    [HttpDelete]
    [Route("api/contact/delete/{ID}")]
    public HttpResponseMessage DeleteContact(int ID)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateResponse(HttpStatusCode.OK, ModelState);
      }

      var contact = db.Contacts.Find(ID);
      db.Contacts.Remove(contact);
      db.SaveChanges();

      return Request.CreateResponse(HttpStatusCode.OK, "success");
    }

    [HttpPut]
    [Route("api/contact/edit/{ID}")]
    public HttpResponseMessage UpdateContact([FromBody]Contact newContact)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateResponse(HttpStatusCode.OK, ModelState);
      }

      var oldContact = db.Contacts.ToList().Find(c => c.ID == newContact.ID);
      db.Contacts.Remove(oldContact);
      db.Contacts.Add(newContact);
      db.SaveChanges();

      return Request.CreateResponse(HttpStatusCode.OK, "success");
    }
  }
}
