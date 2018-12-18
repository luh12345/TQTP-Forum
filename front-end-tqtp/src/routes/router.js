import Login from '../components/Login/Login.vue'
import Home from '../components/Home/Home.vue'
import VueRouter from 'vue-router'

//Create vue router
const router =  new VueRouter({
    routes:[
        { 
            path: '/',
            name: 'home',
            component: Home,
            meta: {
                requireAuth: true
            }
        },
        { 
            path: '/login',
            name: 'login',
            component: Login,
            meta:{
                loginPage: true
            }
        }
    ],
    mode: 'history'
})

//Auth Configuration
router.beforeEach((to, from , next) => {
    if(to.matched.some(route => route.meta.requireAuth)){
        let authToken = localStorage.getItem('auth-token')
        if(!authToken){
            next("/login")
        }
        else{
            next()
        }
    }
    else if(to.matched.some(route => route.meta.loginPage)){
        let authToken = localStorage.getItem('auth-token')
        if(authToken){
            next('/')
        }
        else{
            next();
        }
    }
    else{
        next()
    }
})

export {router};