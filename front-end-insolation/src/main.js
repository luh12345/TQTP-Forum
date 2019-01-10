import Vue from 'vue'
import App from './App'
import VueRouter from 'vue-router'
import { router } from '../src/routes/router'

//CSS
import '../node_modules/nes.css/css/nes.css'
import '../src/styles/main.css'
import '../src/styles/nprogress.css'
import '../src/styles/grid.min.css'

Vue.use(VueRouter)

new Vue({
  render: h => h(App),
  router: router
}).$mount('#app')

