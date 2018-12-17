import { router } from "../routes/router";

export default class SessionHelper {
    constructor(){
        throw new Error("this class cannot be instantiated.");
    }

    static _isLogged(){
        return localStorage.getItem('auth-token') !== undefined;
    }

    static checkAuth(){
        let isLogged = !this._isLogged();
        if(!isLogged){
            router.push('/login');
        }
    }
}