<template>
  <div class="home">
    <h1>Pet Pals</h1>
    <h2>Welcome to Pet Pals!</h2>
    <div>
      <h3>Pet Pals offers you the abilty to:</h3> 
      <ul>
        <li> Find other pets for play dates </li>
        <li> Find other pets for play dates </li>
        <li> Find other pets for play dates </li>
      </ul>
    </div>
    <h3>New users register <router-link v-bind:to="{name: 'register'}">HERE</router-link> to get started with your new pet adventures!</h3>   
  </div>
</template>

<script>
export default {
  name: "home"
};
</script>

<style scoped>

</style>