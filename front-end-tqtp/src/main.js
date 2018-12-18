import Vue from 'vue'
import App from './App'
import VueRouter from 'vue-router'
import { router } from '../src/routes/router'

Vue.use(VueRouter)

new Vue({
  render: h => h(App),
  router: router
}).$mount('#app')

