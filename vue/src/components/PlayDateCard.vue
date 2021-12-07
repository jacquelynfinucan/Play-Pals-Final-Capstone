<template>
   <div id="main">

    <h3 id="header">Host Name: {{playdate.hostName}}</h3>
    <br/>
    <h3 class="pet-name">Host Pet Name: {{playdate.hostPet}}</h3>
    <h3 class="pet-name">Guest Pet Name: {{playdate.guestPet}}</h3>




   </div>
</template>

<script>

export default {
    name: 'PlayDateCard',
 

    props: ['playdate'],

}
</script>

<style scoped>
#main {
  border: solid 1px darkgrey;
  border-radius: 5px;

  background-color: white;

  margin-bottom: 10px;
}

#header {
  border-radius: 5px;
  
  background-color: lightblue;
    margin-top:0px;
    padding:30px;
  display: flex;
  flex-direction: row;
}

.pet-img {
  border: solid 5px darkgrey;
  border-radius: 9999px;
  
  width: 75px;
  margin: 10px;
  
  align-self: flex-start;
  justify-self: center;
}

.pet-name{ 
text-align: left;
}

.pet-body {
  padding: 10px;
}
</style>