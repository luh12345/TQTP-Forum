<template>
  <div class="row pag">
    <div id="body_box" class="col-11 col-sm-9 col-md-7 col-lg-5 col-xl-4">
      <section id="box_login" class="nes-container with-title">
        <h1 class="title_box fs_15">Sign Up</h1>
        <form id="form" @submit.prevent="signUp()">
          <div class="bloco">
            <input
              type="text"
              id="name"
              class="nes-input fs_12"
              placeholder="Nome"
              v-model="user.name"
              v-bind:class="{'is-error' : error}"
            >
          </div>
          <div class="bloco">
            <input
              type="text"
              id="name"
              class="nes-input fs_12"
              placeholder="Username"
              v-model="user.username"
              v-bind:class="{'is-error' : error}"
            >
          </div>
          <div class="bloco">
            <input
              type="email"
              id="mail"
              class="nes-input fs_12"
              placeholder="E-mail"
              v-model="user.email"
              v-bind:class="{'is-error' : error}"
            >
          </div>
          <div class="bloco">
            <input
              type="password"
              id="password"
              v-model="user.senha"
              class="nes-input fs_12"
              placeholder="Password"
              v-bind:class="{'is-error' : error}"
            >
            <img
              class="show_password"
              src="../../assets/eyes.png"
              alt="mostrar senha"
              v-on:mousedown="mostrar('password')"
              v-on:mouseup="n_mostrar('password')"
            >
          </div>
          <div class="bloco bloco_margin_metade">
            <input
              type="password"
              id="password_confirm"
              v-model="user.confirmarSenha"
              class="nes-input fs_12"
              placeholder="Confirmar password"
              v-bind:class="{'is-error' : error}"
            >
            <img
              class="show_password"
              src="../../assets/eyes.png"
              alt="mostrar senha"
              v-on:mousedown="mostrar('password_confirm')"
              v-on:mouseup="n_mostrar('password_confirm')"
            >
          </div>
          <div class="bloco bloco_sem_margin">
            <label class="fs_8" id="UserTerm" v-on:click="userterm()">
              <input type="checkbox" class="nes-checkbox" id="input_userterm">
              <span>Termo de Uso</span>
            </label>
          </div>
          <div class="bloco">
            <button type="submit" class="btn_confirm nes-btn is-disabled fs_12">Confirmar</button>
          </div>
          <div class="bloco height_5">
            <router-link to="login" class="underline left fs_8">Já sou cadastrado</router-link>
          </div>
        </form>
      </section>
    </div>
  </div>
</template>

<script>
import User from "../../models/Users/User.js";
import LoginService from "../../services/Login/LoginService.js";

let loginService = new LoginService();

export default {
  data() {
    return {
      user: new User(),
      isValid: false,
      error: ""
    };
  },
  methods: {
    signUp() {
      if (!this.isValid) return;
      if (this.user.senha !== this.user.confirmarSenha) {
        alert("Senhas não são iguais");
        return;
      }

      loginService
        .signUp(this.user)
        .then(res => {
          let jwt = res.data;
          localStorage.setItem("auth-token", jwt);
          this.$router.push("/");
        })
        .catch(function(error) {
          if (error.response !== undefined) {
            alert(error.response.data);
          } else {
            alert("Sistema fora do ar, por favor tente novamente mais tarde.");
          }
        });
    },

    mostrar: function(id) {
      var senha = document.getElementById(id);
      senha.type = "text";
    },

    n_mostrar: function(id) {
      var senha = document.getElementById(id);
      senha.type = "password";
    },

    userterm: function() {
      var userterm = document.getElementById("input_userterm");
      var btn = document.getElementsByClassName("btn_confirm");
      if (userterm.checked == true) {
        btn[0].classList.remove("is-disabled");
        btn[0].classList.add("is-primary");
      } else {
        btn[0].classList.remove("is-primary");
        btn[0].classList.add("is-disabled");
      }

      this.isValid = true;
    }
  }
};
</script>

<style scoped>
</style>
