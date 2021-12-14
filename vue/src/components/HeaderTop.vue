<template>
  <div class="header">
    <nav class="nav-links">

      <router-link class="nav-link" v-bind:to="{ name: 'home' }">Home</router-link><!--<span v-if="$store.state.token != ''">&nbsp;|&nbsp;</span>-->
      <router-link class="nav-link" v-bind:to="{ name: 'profile' }" v-if="$store.state.token != ''">Profile</router-link><!--<span v-if="$store.state.token != ''">&nbsp;|&nbsp;</span>-->
      <router-link class="nav-link" v-bind:to="{ name: 'map' }" v-if="$store.state.token != ''">Map</router-link><!--&nbsp;|&nbsp;-->
      <router-link class="nav-link" v-bind:to="{ name: 'messages' }" v-if="$store.state.token != ''">Messages</router-link><!--&nbsp;|&nbsp;-->
      <router-link class="nav-link" v-bind:to="{ name: 'playdate-list' }" v-if="$store.state.token != ''">My Playdates</router-link><!--&nbsp;|&nbsp;-->
      <router-link class="nav-link" v-bind:to="{ name: 'schedule' }" v-if="$store.state.token != ''">Schedule A Playdate</router-link><!--&nbsp;|&nbsp;-->
    </nav>
    <nav class="login-controls">
      <router-link class="nav-link" v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''">Log in / Sign up</router-link>
      <router-link class="nav-link" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Log out</router-link>
    </nav>
  </div>
</template>

<script>
export default {
  name: "header-top"
};
</script>

<style>
  body{
    font-family:Cursive;
  /* font-family:'Barlow Condensed'; */
}
</style>



<style scoped>

@import url('https://fonts.googleapis.com/css2?family=Barlow+Condensed:wght@500&display=swap');



.header{
    background-color: lightgrey;
    background:linear-gradient(110deg, lightgrey 70%,rgb(23, 114, 53) 74%);
  width :100vw;
  height:80px;
  position:fixed;
  top:0px;
  left:0px;
  color:white;
  display:flex;
  justify-content: space-between;
  align-items: center;
  font-size:26px;
}

.nav-links {
  margin-left: 30px;
}

.login-controls {
  margin-right:50px;
} 
.login-controls .nav-link{
  color:white;
}

.nav-link {
  /* font-family:'Barlow Condensed'; */
  font-weight: bold;
  text-decoration: none;
  color:rgb(4, 16, 20);
  margin-right:35px;
}
</style>