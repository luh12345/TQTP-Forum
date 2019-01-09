import axios from "axios";

export default class LoginService {
  constructor() {
    this._endpoint = process.env.VUE_APP_INSOLATION_API + "Auth";
  }

  login(username, password) {
    let configuration = {
      headers: {
        "Content-Type": "application/json",
        JwtAudience: process.env.VUE_APP_LOCAL_ENDPOINT
      }
    };

    let data = {
      Username: username,
      Password: password
    };

    return axios.post(this._endpoint, JSON.stringify(data), configuration);
  }

  logout() {
    localStorage.removeItem("auth-token");
  }

  isLogged(){
      return localStorage.getItem("auth-token") !== undefined;
  }
}
