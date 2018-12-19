<template>
  <div>
    <div class="nes-container is-rounded fullscreen login-background">
        <center>
            <form @submit.prevent="cadastrarUsuario()" class="nes-container with-title is-rounded center small-form">
                <h2>Cadastro de usuário</h2>
                <input type="text" class="nes-input" v-model="user.name" v-bind:class="{'is-error' : error}" placeholder="Digite seu nome">
                <br/>
                <br/>
                <input type="text" class="nes-input" v-model="user.username" v-bind:class="{'is-error' : error}" placeholder="Digite seu username">
                <br/>
                <br/>
                <input type="email" class="nes-input" v-model="user.email" v-bind:class="{'is-error' : error}" placeholder="Digite seu email">
                <br/>
                <br/>
                <input type="password" class="nes-input" v-model="user.password" v-bind:class="{'is-error' : error}" placeholder="Digite sua senha">
                <br/>
                <br/>
                <input type="password" class="nes-input" v-model="confirmarSenha" v-bind:class="{'is-error' : error}" placeholder="Confirmar sua senha">
                <br/>
                <button to="cadastro-user" class="nes-btn is-primary" type="submit">Cadastrar</button>
                <br/>
            </form>
        </center>     
    </div>
  </div>
</template>

<script>
import User from '../../models/Users/User.js'

export default {
    data(){
        return{
            user: new User(),
            confirmarSenha: '',
        }
    },
    methods:{
        cadastrarUsuario(){
            if(this.user.password !== this.confirmarSenha){
                alert("Senhas não são iguais")
                return;
            }

            alert(`Cadastrando o ${this.user.name}`);

            //todo: chamada para o endpoint de cadastramento de usuario
        }
    }
};
</script>

<style>
</style>
