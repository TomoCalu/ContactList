<template>
  <div id="contacts container">
    <Alert v-if="alert" v-bind:message="alert" />
    <h1 class="page-header">Manage Contacts</h1>
    <div class="input-group">
      <input class="form-control" placeholder="Search by name or tag" @input="filterContacts" v-model="keyword" />
      <select class="btn btn-primary" @click="filterContacts" v-model="selectedTag" >
        <option class="btn btn-default" v-for="tag in allTags">{{tag}}</option>
      </select>
    </div>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>FirstName</th>
          <th>LastName</th>
          <th>Adress</th>
          <th>Emails</th>
          <th>PhoneNumbers</th>
          <th>Tag</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="contact in contacts">
          <td>{{contact.FirstName}}</td>
          <td>{{contact.LastName}}</td>
          <td>{{contact.Adress}}</td>
          <td>
            <span v-for="email in contact.Emails">
                <span v-text="email.Adress"></span>
                <br>
            </span>
          </td>
          <td>
            <span v-for="phonenumber in contact.PhoneNumbers">
                <span v-text="phonenumber.Number"></span>
                <br>
            </span>
          </td>
          <td>{{contact.Tag}}</td>
          <td><router-link class="btn btn-primary" v-bind:to="'/edit/'+contact.ID">Edit</router-link></td>
          <td><button class="btn btn-danger" v-on:click="deleteContact(contact.ID)">Delete</button></td>
          <td><router-link class="btn btn-default" v-bind:to="'/contact/' + contact.ID">View</router-link></td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  import Alert from './Alert';
  export default {
    name: 'contacts',
    data () {
      return {
          contacts: [],
          alert: '',
          keyword: '',
          allTags: ['All'],
          selectedTag: 'All'
      }
    },
    methods: {
        async checkIfSameTags() {
            await this.filterContacts();
            for (var i = 0; i < this.contacts.length; i++) {
                if (this.allTags.includes(this.contacts[i].Tag) || this.contacts[i].Tag == null) {
                    continue;
                }
                this.allTags.push(this.contacts[i].Tag);
            }
            console.log(this.allTags);
        },
        filterContacts() {
            var baseUrl = window.location.origin;
            console.log(this.selectedTag);
            console.log(this.keyword);
            return this.$http.get(baseUrl + "/api/getContacts/" + this.selectedTag + "/" + this.keyword )
                       .then(function (response) {
                           this.contacts = response.data;
                           console.log(response.body);
                       });
        },
        async deleteContact(ID) {
            console.log(ID);
            var baseUrl = window.location.origin;
            var finished = this.$http.delete(baseUrl + "/api/contact/delete/" + ID)
                               .then(function (response) {
                                   this.alert = 'Contact deleted!';
                               });         
            await finished;
            this.filterContacts();
        }
    },
    created: function () {
        if (this.$route.query.alert) {
            this.alert = this.$route.query.alert;
        }
        this.checkIfSameTags();
        
    },
    components: {
        Alert
    }
  }
</script>
