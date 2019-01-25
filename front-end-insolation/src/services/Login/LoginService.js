import axios from "axios";

export default class LoginService {
  constructor() {
    this._endpoint = process.env.VUE_APP_INSOLATION_API;
    this._fetch = axios.create({
      baseURL: this._endpoint,
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
        JwtAudience: process.env.VUE_APP_LOCAL_ENDPOINT
      }
    });
  }

  login(username, password) {
    let data = {
      Username: username,
      Password: password
    };
    let urlAuth = (this._endpoint + "Auth");
    return this._fetch.post(urlAuth, JSON.stringify(data));
  }

  logout() {
    localStorage.removeItem("auth-token");
  }

  isLogged() {
    return localStorage.getItem("auth-token") !== undefined;
  }

  signUp(user) {
    let urlSignUp = (this._endpoint + "SignUp");
    return this._fetch.post(urlSignUp, JSON.stringify(user));
  }
}