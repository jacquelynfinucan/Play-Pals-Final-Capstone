<template>
  <div class="header">
    <nav class="nav-links">

      <router-link class="nav-link" v-bind:to="{ name: 'home' }">Home</router-link><span v-if="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link class="nav-link" v-bind:to="{ name: 'profile' }" v-if="$store.state.token != ''">Profile</router-link><span v-if="$store.state.token != ''">&nbsp;|&nbsp;</span>
      <router-link class="nav-link" v-bind:to="{ name: 'map' }" v-if="$store.state.token != ''">Map</router-link>&nbsp;|&nbsp;
      <router-link class="nav-link" v-bind:to="{ name: 'messages' }" v-if="$store.state.token != ''">Messages</router-link>
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
.header {
  background-color: lightgrey;

  padding-top: 10px;
  padding-bottom: 10px;
  padding-left: 10px;
  padding-right: 10px;

  border-radius: 5px;
  border: solid 1px darkgrey;

  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: 
    "nav login";
}

.nav-links {
  grid-area: nav;
}

.login-controls {
  grid-area: login;
  
  display: flex;
  justify-content: right;
}

.nav-link {
  font-weight: bold;
}
</style>