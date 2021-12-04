<template>
  <div class="header">
    <nav>
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'profile' }" v-if="$store.state.token != ''">Profile</router-link>
    </nav>
    <div class="login-controls">
      <router-link tag="button" v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''">Login</router-link>
      <router-link tag="button" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
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

  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: 
    "nav login";
}

nav {
  grid-area: nav;
}

.login-controls {
  grid-area: login;
  
  display: flex;
  justify-content: right;
}
</style>