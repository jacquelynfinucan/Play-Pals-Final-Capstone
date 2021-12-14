<template>
   <div id="main">
    <h2 id="header">Playdate Title: {{playdate.title}}</h2>
    <div id="card-body">
    <h3 class="date-time">Date and Time: {{formatedDate}}</h3>
    <h3 class ="host-name" :class="this.$store.state.user.userId == this.playdate.host_user_id ? 'currentUser' : 'notCurrentUser'">Host User: {{playdate.hostUsername}}</h3>
    <h3 class="pet-name">Host Pet: {{playdate.hostPetName}}</h3>
    <h3 class="pet-name" :class="this.$store.state.user.userId != this.playdate.host_user_id  ? 'currentUser' : 'notCurrentUser'">Guest User: {{playdate.guestUsername}}</h3>
    <h3 class="pet-name">Guest Pet: {{playdate.guestPetName}}</h3>
    <h3 class="address">Address: {{playdate.address}}</h3>
    <h3 v-if="this.playdate.statusID == 1" class="status pending" :class="this.$store.state.user.userId != this.playdate.host_user_id ? 'pending-guest' : 'notCurrentUser'">Status: Pending</h3>
    <h3 v-if="this.playdate.statusID == 2" class="status accepted">Status: Accepted</h3>
    <h3 v-if="this.playdate.statusID == 3" class="status rejected">Status: Rejected</h3>

    <button v-if="this.playdate.statusID == 1 && this.$store.state.user.userId != this.playdate.host_user_id" v-on:click="changeStatusToAccepted">Accept Request</button>
    <button v-if="this.playdate.statusID == 1 && this.$store.state.user.userId != this.playdate.host_user_id" v-on:click="changeStatusToRejected">Decline Request</button>

    <button v-if="this.playdate.statusID == 2 && this.$store.state.user.userId == this.playdate.host_user_id" v-on:click="sendToUpdatePlaydate">Update Playdate</button>
    <!--<button v-if="this.playdate.statusID == 2 && this.$store.state.user.userId == this.playdate.host_user_id" v-on:click="cancelPlaydate">Cancel Playdate</button>-->

    </div>
   </div>
</template>

<script>
import DateService from "../services/DateService";

export default {
    name: 'PlayDateCard',
    props: ['playdate'],
    data() {
      return{
        currentUserIsHost: false,
      }
    },
    methods: {
      changeStatusToAccepted(){
        DateService.updatePlayDateStatus(this.playdate.playDateID, 2).then((response) => {
          if (response.status == 200) {
             this.$router.go(); //push({ name: "playdate-list" });
          }
      });
      }, 
      changeStatusToRejected(){
        DateService.updatePlayDateStatus(this.playdate.playDateID, 3).then((response) => {
          if (response.status == 200) {
             this.$router.go(); //push({ name: "playdate-list" });
          }
      });
      }, 
      cancelPlaydate(){
        
      }, 
      sendToUpdatePlaydate(){
        //this.$router.push({name: });
      },
    },
    computed: {
      formatedDate() {
        let date = new Date(this.playdate.dateOfPlayDate);        
        return date.toLocaleString();
      }
    }
}
</script>

<style scoped>
#main {
  border: solid 1px darkgrey;
  border-radius: 5px;
  background-color: white;
  margin-bottom: 10px;
  margin-left: 10px;
}

#header {
  border-radius: 5px; 
  background-color:lightblue;
  margin-top:0px;
  padding:10px;
  display: flex;
  flex-direction: row;
}

#card-body{
  margin-left: 10px;
}

.currentUser{
  color: dodgerblue;
  font-style: italic;
}

.pet-img {
  border: solid 5px darkgrey;
  border-radius: 9999px;
  width: 75px;
  margin: 10px;  
  align-self: flex-start;
  justify-self: center;
}

.pet-body {
  padding: 10px;
}

.status{
  font-style: italic;
}

.pending{
  color: red;
}

.accepted{
  color: #33d348f1;
}

.pending-guest{
  background-color: yellow;
}

</style>
