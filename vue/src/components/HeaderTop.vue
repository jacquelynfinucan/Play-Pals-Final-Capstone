<template>
  <div class="header">
    <nav class="nav-links">
      <img src="@/assets/Play Pals-logos.jpeg" title="Dog by Martin Vanco"/>
      <router-link class="nav-link" v-bind:to="{ name: 'home' }">Home</router-link><!--<span v-if="$store.state.token != ''">&nbsp;|&nbsp;</span>-->
      <router-link class="nav-link" v-bind:to="{ name: 'profile' }" v-if="$store.state.token != ''">Profile</router-link><!--<span v-if="$store.state.token != ''">&nbsp;|&nbsp;</span>-->
      <router-link class="nav-link" v-bind:to="{ name: 'user-map', params: {id: this.$store.state.user.userId}}" v-if="$store.state.token != ''">Map User Playdates</router-link> <!-- Test User PlayDate Map -->
      <router-link class="nav-link" v-bind:to="{ name: 'playdate-list' }" v-if="$store.state.token != ''">My Playdates</router-link><!--&nbsp;|&nbsp;-->
      <router-link class="nav-link" v-bind:to="{ name: 'schedule' }" v-if="$store.state.token != ''">Pet Finder</router-link><!--&nbsp;|&nbsp;-->
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




<style scoped>

img{
  height:160px;
  position:fixed;
  top:0px;
  left:0px;
}


@import url('https://fonts.googleapis.com/css2?family=Barlow+Condensed:wght@500&display=swap');



.header{
    background:linear-gradient(110deg, var(--secondary-color) 70%,var(--primary-color)
 74%);
  width :100vw;
  height:160px;
  position:fixed;
  top:0px;
  left:0px;
  display:flex;
  justify-content: space-between;
  align-items: center;
  font-size:26px;

  z-index: 3;
}

.nav-links {
  margin-left: 190px;
}

.login-controls {
  margin-right:50px;
} 
/* .login-controls .nav-link{
  color:white;
} */

.nav-link {
  /* font-family:'Barlow Condensed'; */
  font-weight: bold;
  text-decoration: none;
  color:rgb(4, 16, 20);
  margin-right:35px;
}
</style>