<template>
<div class="row pag">
    <div id="body_box" class="col-11 col-sm-9 col-md-7 col-lg-5 col-xl-4">
      <section id="box_login" class=" nes-container with-title">
            <h1 class="title_box fs_15">Login</h1>
            <form id="form" @submit.prevent="cadastrarUsuario()">
                <div class="bloco">
                    <input type="text" id="name" class="nes-input fs_12" placeholder="Username" v-model="user.username" v-bind:class="{'is-error' : error}">
                </div>
                <div class="bloco">
                    <input type="email" id="mail" class="nes-input fs_12" placeholder="E-mail" v-model="user.email" v-bind:class="{'is-error' : error}">
                </div>
                <div class="bloco">
                    <input type="password" id="password" class="nes-input fs_12" placeholder="Password">
                    <img class="show_password" src="../../assets/eyes.png" alt="mostrar senha" v-on:mousedown="mostrar('password')" v-on:mouseup="n_mostrar('password')" v-model="user.password" v-bind:class="{'is-error' : error}">
                </div>
                <div class="bloco bloco_margin_metade">
                    <input type="password" id="password_confirm" class="nes-input fs_12" placeholder="Confirm password">
                    <img class="show_password" src="../../assets/eyes.png" alt="mostrar senha" v-on:mousedown="mostrar('password_confirm')" v-on:mouseup="n_mostrar('password_confirm')" v-model="confirmarSenha" v-bind:class="{'is-error' : error}">
                </div>
                <div class="bloco bloco_sem_margin">
                    <label class="fs_8" id="UserTerm" v-on:click="userterm()">
                        <input type="checkbox" class="nes-checkbox">
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
        },

        mostrar: function (id) {
            var senha = document.getElementById(id);
            senha.type = "text";
        },

        n_mostrar: function (id){
            var senha = document.getElementById(id);
            senha.type = "password";
        },

        userterm: function (){
            if($('#UserTerm input').prop('checked') == true){
                $(".btn_confirm").removeClass("is-disabled");
                $(".btn_confirm").addClass("is-primary");
            } else{
                $(".btn_confirm").removeClass("is-primary");
                $(".btn_confirm").addClass("is-disabled");
            }
        }
    }
};
</script>

<style>
</style>
