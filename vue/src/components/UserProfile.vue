<template>

<div class="main">
  <h1>{{this.user.firstName}}</h1>
  <h1>{{this.user.lastName}}</h1>
  <h2>Zip: {{this.user.zip}}</h2>
  <h2>Email: {{this.user.email}}</h2>
  <h3>My Playdates</h3>
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
     if(response.data.userId == 0){
         this.$router.push({ name: "register-profile" }); //should kick you to RegisterProfile view if profile doesn't exist
     }
     else{
         this.user = response.data;
     }
 })
     }
}
</script>

<style>
h1, h2, h3{
    text-align: center;
}
</style>