<template>
  <div>
    <div class="container is-rounded fullscreen login-background">
      <center>
        <form @submit.prevent="doLogin()" class="container with-title is-rounded center small">
          <h2>Login</h2>
          <input type="text" class="input" v-model="username" v-bind:class="{'is-error' : error}" placeholder="Digite seu username">
          <br/>
          <input type="password" class="input" v-model="password" v-bind:class="{'is-error' : error}" placeholder="Digite seu password">
          <br/>
          <button class="btn is-success" type="submit">Login</button>
          <button class="btn" type="submit">Cadastrar</button>
          <button class="btn" type="submit">Esqueci minha senha</button>
        </form>
      </center>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      username: "",
      password: "",
      error: ""
    };
  },
  methods: {
    doLogin() {
      if (!this.username || !this.password) {
        this.error = "Preencha os campos corretamente.";
        return;
      }

      alert(`Logando o usuario ${this.username}}`);
    }
  }
};
</script>

<style scoped>
.fullscreen {
  position: fixed;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}

.center {
  margin: 0 auto;
}
.small{
  width: 500px;
  height: 500px;
  padding: 50px;
}
.login-background {
  background-image: url("../../assets/login-background.jpg");
  background-size: cover; /* <------ */
  background-repeat: no-repeat;
  background-position: center center;
}
</style>
