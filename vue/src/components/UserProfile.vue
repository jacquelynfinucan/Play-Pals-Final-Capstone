<template>

<div class="main">
  <h1>{{this.user.firstName}}</h1>
  <h1>{{this.user.lastName}}</h1>
  <h2>Zip: {{this.user.zip}}</h2>
  <h2>Email: {{this.user.email}}</h2>
  <h3>My Pets</h3>
  <h3>My Playdates</h3>
  <br/>
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
 UserService.GetUserByID(this.$store.state.user.userId).then((response)=>{
     this.user = response.data;
 })
 DateService.GetPlayDatesForUser(this.$store.state.user.userId).then((response)=>{
     this.playdates = response.data;
 })
     }
}
</script>

<style>
h1, h2, h3{
    text-align: center;
}
</style>