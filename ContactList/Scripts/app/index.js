import Vue from 'vue'
import Polyfill from 'babel-polyfill'
import App from './App'
import Vuetify from 'vuetify'
import vueResource from 'vue-resource'
import vueRouter from 'vue-router'
import About from './components/About'
import Contacts from './components/Contacts'
import Add from './components/Add'
import ContactDetails from './components/ContactDetails'
import Edit from './components/Edit'

Vue.use(Vuetify)
Vue.use(vueRouter)
Vue.use(vueResource)

const router = new vueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/', component: Contacts },
    { path: '/about', component: About },
    { path: '/add', component: Add },
    { path: '/contact/:ID', component: ContactDetails },
    { path: '/edit/:ID', component: Edit }
  ]
})

new Vue({
  el: '#app',
  router: router,
  render: h => h(App)
})
