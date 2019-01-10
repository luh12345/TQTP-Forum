import jwt from "jsonwebtoken";

export default class JwtHelper {
  constructor() {
    throw new Error("Esta classe não pode ser instanciada.");
  }

  static validateJwt(token) {
    try {
      jwt.verify(token, process.env.VUE_APP_JWT_KEY);
      return true;
    } catch (e) {
      return false;
    }
  }
}
