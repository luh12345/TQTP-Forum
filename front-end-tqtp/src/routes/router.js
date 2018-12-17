import Login from '../components/Login/Login.vue'
import Home from '../components/Home/Home.vue'
import VueRouter from 'vue-router'

const routes = [
    { path: '/', component: Home},
    { path: '/login', component: Login}
]

export const router = new VueRouter({
    routes,
    mode: 'history'
})