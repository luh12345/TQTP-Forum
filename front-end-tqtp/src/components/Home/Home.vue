<template>
    <div>
        <p>Bem vindo ao forum da TQTP :D</p>
    </div>
</template>

<script>
import SessionHelper from '../../helper/SessionHelper.js'

export default {
   created(){
     SessionHelper.checkAuth();
   }
}
</script>

<style>

</style>
