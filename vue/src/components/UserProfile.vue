<template>

<div class="main">
  <h1>{{this.user.FirstName}}</h1>
  <h1>{{this.user.LastName}}</h1>
  <h2>Zip: {{this.user.ZipCode}}</h2>
  <h3>Check out my pets!</h3>
  <br/>
 

</div>

</template>

<script>
 import UserService from "../services/UserService";



export default {
    name:'UserProfile',
    data() {
        return {
            user:{
              
            }
        }
    },
    computed:{
        aUser(){
            return this.$store.state.user;
        }
    },
    created(){
 UserService.GetUserByID(this.$store.state.user.userId).then((response)=>{
     this.user = response.data;
 })
     }
}
</script>

<style>
h1, h2, h3{
    text-align: center;
}
</style>