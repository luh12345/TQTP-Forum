<template>
<div class="row pag">
    <div id="body_box" class="col-11 col-sm-9 col-md-7 col-lg-5 col-xl-4">
        <section id="box_login" class=" nes-container with-title">
            <h1 class="title_box fs_15">Recuperação de senha</h1>
            <form id="form">
                <div class="bloco">
                    <p class="fs_10">Para recuperar sua senha, digite seu e-mail abaixo e confirme. Será enviado para seu e-mail um código de recuperação.</p>
                </div>
                <div class="bloco">
                    <input type="email" id="mail" class="nes-input fs_12" placeholder="E-mail" >
                    <!-- v-model="password.email" v-bind:class="{'is-error' : error}" -->
                </div>
                <div class="bloco">
                    <button type="submit" class="btn_confirm nes-btn is-primary fs_12">Confirmar</button>
                </div>
                <div class="bloco height_5">
                    <router-link to="login" class="underline left fs_8">Volar</router-link>
                </div>
            </form>
        </section>
    </div>
  </div>
</template>

<script>

export default {
    data(){
        return{
        }
    },
    methods:{
        
    }
};
</script>

<style>
</style>
