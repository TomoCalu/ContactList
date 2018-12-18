# ContactList v1.0

A simple CRUD web page written in Vue.js and .NET Web API.

This page enables users to create, read, update and delete contacts in a list. Each contact can have multiple emails and phone numbers, 
as well as names, addresses and such. Each contact can be assigned to a certain group, chosen by the user.

Contacts can be filtered by their names, or tags.

The webpage is made as a single page application, which gets contacts from a server with Ajax calls. Page also has a vue router working in 
history mode, enabling a user to bookmark a contact and open it later trough his browser, or to send a link to someone else. 
Visual Studio project automatically creates a database with 2 contacts on first start.

