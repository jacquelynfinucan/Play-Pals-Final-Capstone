<template>
   <div id="main" style="background-color:blue;">

    <h3>Host Name: {{playdate.hostName}}</h3>
    <br/>
    <h3>Host Pet Name: {{playdate.hostPet}}</h3>
    <h3>Guest Pet Name: {{playdate.guestPet}}</h3>




   </div>
</template>

<script>

export default {
    name: 'PlayDateCard',
 

    props: ['playdate'],

}
</script>

<style>
 /* #main {
     display:grid;
 } */
</style>