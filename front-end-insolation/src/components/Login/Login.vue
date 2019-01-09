<template>
  <div class="row pag">
    <div id="body_box" class="col-11 col-sm-9 col-md-7 col-lg-5 col-xl-4">
      <section id="box_login" class=" nes-container with-title">
          <h1 class="title_box fs_15">Login</h1>
          <form id="form" @submit.prevent="doLogin()">
              <div class="bloco">
                  <input type="text" id="name" class="nes-input fs_12" placeholder="Username" v-model="username" v-bind:class="{'is-error' : error}">
              </div>
              <div class="bloco bloco_margin_metade">
                  <input type="password" id="password" class="nes-input fs_12" placeholder="Password" v-model="password" v-bind:class="{'is-error' : error}">
                  <img class="show_password" src="../../assets/eyes.png" alt="mostrar senha" v-on:mousedown="mostrar('password')" v-on:mouseup="n_mostrar('password')">
              </div>
              <div class="bloco bloco_sem_margin">
                  <label class="fs_8">
                      <input type="checkbox" class="nes-checkbox">
                      <span>Manter-me conectado</span>
                  </label>
              </div>
              <div class="bloco">
                  <button type="submit" class="nes-btn is-primary fs_12">Confirmar</button>
              </div>
              <div class="bloco height_5">
                <router-link to="cadastro-user" class="underline left fs_8">Não tenho conta</router-link>
                <router-link to="password" class="underline right fs_8">Esqueci minha senha</router-link>
              </div>
          </form>
      </section>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      password: '',
      error: ''
    };
  },
  methods: {
    doLogin() {
      if (!this.username || !this.password) {
        this.error = "Preencha os campos corretamente.";
        return;
      }

      alert(`Logando o usuario ${this.username}}`);

    },

    mostrar: function (id) {
      var senha = document.getElementById(id);
      senha.type = "text";
    },

    n_mostrar: function (id){
      var senha = document.getElementById(id);
      senha.type = "password";
    }
  }
};
</script>

<style scoped>

</style>
