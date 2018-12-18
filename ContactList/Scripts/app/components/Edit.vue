<template>
  <div id="edit container">
    <h1 class="page-header">Edit Contact</h1>
    <Alert v-if="alert" v-bind:message="alert" />
     <form v-on:submit="updateContact">
        <div class="well">
            <h4>Info</h4>
            <div class="form-group">
                <label>First Name</label>
                <input type="text" class="form-control" placeholder="First Name" v-model="contact.FirstName">
            </div>
            <div class="form-group">
                <label>Last Name</label>
                <input type="text" class="form-control" placeholder="Last Name" v-model="contact.LastName">
            </div>          
            <div class="form-group">
                <label>Address</label>
                <input type="text" class="form-control" placeholder="Address" v-model="contact.Adress">
            </div>
        </div>
        <div class="well">
            <h4>Contact</h4>            
            <label>Emails</label>
            <div class="form-group" v-for="(Email, index) in contact.Emails">
                <input type="email" placeholder="Email" v-model="Email.Adress" />              
                <button type="button" class="btn btn-danger" v-on:click="removeEmail(index);" style="cursor: pointer">Delete</button>
            </div>
            <button type="button" class="btn btn-success" @click="addEmail" style="cursor: pointer">Add new</button>  
            <br />
            <br />
            <label>Phone number</label>
             <div class="form-group" v-for="(PhoneNumber, index) in contact.PhoneNumbers">
                <input type="number" placeholder="PhoneNumber" v-model="PhoneNumber.Number" />              
                <button type="button" class="btn btn-danger" v-on:click="removePhoneNumber(index);" style="cursor: pointer">Delete</button>
            </div>
            <button type="button" class="btn btn-success" @click="addPhoneNumber" style="cursor: pointer">Add new</button>
        </div>
       <div class="well">
            <h4>Group(Tag)</h4>
            <div class="form-group">
                <input type="text" class="form-control" placeholder="Tag" v-model="contact.Tag">
            </div>
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script>
  import Alert from './Alert'
  export default {
    name: 'update',
    data () {
      return {
          contact: {
              Emails: [],
              PhoneNumbers: []
          },
          alert: ''
      }
    },
    methods: {
        fetchContact(ID) {
            var baseUrl = window.location.origin;
            this.$http.get(baseUrl + "/api/contact/" + ID)
                .then(function (response) {
                    this.contact = response.data;
                    console.log(ID);
                    console.log(response.body);
                });
        },
        updateContact(e) {
            if (!this.contact.FirstName || !this.contact.LastName) {
                console.log('Please fill in First and Last name.');
                this.alert = ('Please fill in First and Last name.');
            }
            else if (this.contact.Emails.some(Email => !Email.Adress.length) ||
                this.contact.PhoneNumbers.some(PhoneNumbers => !PhoneNumbers.Number.length)) {
                console.log('Please remove empty Email or Phone number fields.');
                this.alert = 'Please remove empty Email or Phone number fields.';
            }
            else {
                let updatedContact = {
                    FirstName: this.contact.FirstName,
                    LastName: this.contact.LastName,
                    Adress: this.contact.Adress,
                    Emails: this.contact.Emails,
                    PhoneNumbers: this.contact.PhoneNumbers,
                    Tag: this.contact.Tag,
                    ID: this.$route.params.ID
                }

                var baseUrl = window.location.origin;
                this.$http.put(baseUrl + "/api/contact/edit/" + this.$route.params.ID, updatedContact)
                    .then(function (response) {
                        this.$router.push({ path: '/', query: {alert: 'Successfully edited a cotnact!'}});
                        console.log(updatedContact);
                    });

                e.preventDefault();
            }
            e.preventDefault();
        },
        addEmail: function () {
            var elem = document.createElement('div');
            this.contact.Emails.push({
                Adress: ""
            });
        },
        addPhoneNumber: function () {
            var elem = document.createElement('div');
            this.contact.PhoneNumbers.push({
                Number: ""
            });
        },
        removeEmail: function (index) {
            this.contact.Emails.splice(index, 1);
        },
        removePhoneNumber: function (index) {
            this.contact.PhoneNumbers.splice(index, 1);
        }
     
    },
    created: function () {
        this.fetchContact(this.$route.params.ID);
    },
    components: {
        Alert
    }
  }
</script>
