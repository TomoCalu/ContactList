<template>
  <div id="details container">
    <h1 class="page-header">{{contact.FirstName}} {{contact.LastName}}</h1>    
    <ul class="list-group">
      <li v-for="email in contact.Emails" class="glyphicon glyphicon-envelope list-group-item" aria-hidden="true">
        <span v-text="email.Adress"></span>
        <br />
      </li>
      <br />
      <li v-for="phoneNumber in contact.PhoneNumbers" class="glyphicon glyphicon-phone list-group-item" aria-hidden="true">
        <span v-text="phoneNumber.Number"></span>
        <br />
      </li>
    </ul>
    <ul class="list-group">
      <li class="list-group-item" v-if="contact.Adress">{{contact.Adress}}</li>      
      <li class="list-group-item" v-if="contact.Tag">{{contact.Tag}}</li>
    </ul>
  </div>
</template>

<script>
  export default {
    name: 'contactdetails',
    data () {
      return {
          contact: ''
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
        }
    },
    created: function () {
        this.fetchContact(this.$route.params.ID);
    }
  }
</script>
