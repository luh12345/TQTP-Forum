<template>
  <div>
    <div class="nes-container is-rounded fullscreen login-background">
      <center>
        <form @submit.prevent="doLogin()" class="nes-container with-title is-rounded center small-form">
          <h2>Login</h2>
          <input type="text" class="nes-input" v-model="username" v-bind:class="{'is-error' : error}" placeholder="Digite seu username">
          <br/>
          <br/>
          <input type="password" class="nes-input" v-model="password" v-bind:class="{'is-error' : error}" placeholder="Digite seu password">
          <br/>
          <br/>
          <button class="nes-btn is-primary" type="submit">Login</button>
          <br/>
          <router-link to="cadastro-user" class="nes-btn">Cadastrar</router-link>
          <br/>
          <router-link to ="esqueci-minha-senha" class="nes-btn">Esqueci minha senha</router-link>
          <br/>
        </form>
      </center>
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
    }
  }
};
</script>

<style scoped>

</style>
