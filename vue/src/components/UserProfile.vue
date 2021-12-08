<template>

<div class="main">
  <h1>User Profile</h1>
  <h2>First Name: {{this.user.firstName}}</h2>
  <h2>Last Name: {{this.user.lastName}}</h2>
  <h2>Zipcode: {{this.user.zip}}</h2>
  <h2>Email Address: {{this.user.email}}</h2>
  <br/>

  <h1>My Playdates</h1>
    <play-date-card v-for="playdate in this.playdates" v-bind:key="playdate.PlayDateID" v-bind:playdate="playdate"/>

</div>

</template>

<script>
 import UserService from "../services/UserService";
 import DateService from "../services/DateService";
 import PlayDateCard from './PlayDateCard.vue';



export default {
  components: { PlayDateCard },
    name:'UserProfile',
    data() {
        return {
            user:{
              
            },
            playdates:{

            }
        }
    },
    computed:{
        aUser(){
            return this.$store.state.user;
        }
    },
    created(){
    ProfileService.GetProfile(this.$store.state.user.userId).then((response)=>{
     if(response.data.userId == 0){
         this.$router.push({ name: "register-profile" }); //should kick you to RegisterProfile view if profile doesn't exist
     }
     else{
         this.user = response.data;
     }
 })
 DateService.GetPlayDatesForUser(this.$store.state.user.userId).then((response)=>{
     this.playdates = response.data;
 })
     }
}
</script>

<style>
h1, h2, h3{
    text-align: left;
}
</style>