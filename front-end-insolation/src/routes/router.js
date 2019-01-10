import Login from '../components/Login/Login.vue'
import Home from '../components/Home/Home.vue'
import CadastroUser from '../components/User/Cadastro.vue'
import Password from '../components/Password/RecuperarSenha.vue'
import VueRouter from 'vue-router'
import NProgress from 'nprogress/nprogress'
import JwtHelper from '../helper/JwtHelper'

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
                guest: true
            }
        },
        {
            path: '/cadastro-user',
            name: 'cadastro-user',
            component: CadastroUser,
            meta:{
                guest: true
            }
        },
        {
            path: '/password',
            name: 'password',
            component: Password,
            meta:{
                guest: true
            }
        }
    ],
    mode: 'history'
})

//Auth Configuration
router.beforeEach((to, from , next) => {
    NProgress.start();

    if(to.matched.some(route => route.meta.requireAuth)){
        let authToken = localStorage.getItem('auth-token')
        if(!authToken || !JwtHelper.validateJwt(authToken)){
            localStorage.removeItem('auth-token');
            next("/login")
        }
        else{
            next()
        }
    }
    else if(to.matched.some(route => route.meta.guest)){
        let authToken = localStorage.getItem('auth-token')
        if(authToken && JwtHelper.validateJwt(authToken)){
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

router.afterEach(() =>
{
    NProgress.done();
})

export {router};