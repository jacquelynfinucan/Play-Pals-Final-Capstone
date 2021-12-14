<template>
   <div id="main">
    <h2 id="header">Playdate Title: {{playdate.title}} 
      <router-link v-bind:to="{name: 'thread', params: {id: playdate.playDateID}}">
        <img id="img-messages" src="@/assets/message-thread-icon.png" alt="messages"/>
      </router-link>
    </h2>
    <div id="card-body">
    <h3 class="date-time">Date and Time: {{playdate.dateOfPlayDate}}</h3>
    <h3 class ="host-name">Host User: {{playdate.hostUsername}}</h3>
    <h3 class="pet-name">Host Pet: {{playdate.hostPetName}}</h3>
    <h3 class="pet-name">Guest User: {{playdate.guestUsername}}</h3>
    <h3 class="pet-name">Guest Pet: {{playdate.guestPetName}}</h3>
    <h3 class="address">Address: {{playdate.address}}</h3>
    <h3 v-if="this.playdate.statusID == 1" class="status">Status: Pending</h3>
    <h3 v-if="this.playdate.statusID == 2" class="status">Status: Accepted</h3>
    <h3 v-if="this.playdate.statusID == 3" class="status">Status: Rejected</h3>
    </div>
   </div>
</template>

<script>

export default {
    name: 'PlayDateCard',
 
    props: ['playdate'],
    data() {
      return{
        currentUserIsHost: false,
      }
    },
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
  justify-content: space-between;
}

#card-body{
  margin-left: 10px;
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

#img-messages{
  width: 35px;
}

</style>
