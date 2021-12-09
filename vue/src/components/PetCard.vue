<template>
  <div class="pet-card">
    <div class="pet-header">
      <img class="pet-img" src="https://randomuser.me/api/portraits/lego/1.jpg" alt="pet picture" />
      <p class="pet-name">{{ pet.petName }}</p>
      <!--eventually come back & make name, breed, and description ToUpper -->
    </div>
    <div class="pet-body">
      <p>Animal Type: {{ pet.animalType }}</p>
      <p>Breed: {{ pet.breed }}</p>
      <p>Age: {{ pet.age }}</p>
      
      <p v-if="this.pet.size == 1">Size: Small</p>
      <p v-if="this.pet.size == 2">Size: Medium</p>
      <p v-if="this.pet.size == 3">Size: Large</p>
      
      <p v-if="this.pet.isMale">Gender: Male</p>
      <p v-if="!this.pet.isMale">Gender: Female</p>
      
      <p v-if="this.pet.isSpayed">Spayed/Neutered: True</p>
      <p v-if="!this.pet.isSpayed">Spayed/Neutered: False</p>

      <p>Description: {{ pet.description }}</p>
    </div>  
  </div>
</template>

<script>
export default {
  name: 'pet-card',
  props: ['pet']
};
</script>

<style scoped>
.pet-card {
  border: solid 1px darkgrey;
  border-radius: 5px;

  background-color: white;

  margin-bottom: 10px;
}

.pet-header {
  border-radius: 5px;
  
  background-color: lightblue;

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
  font-weight: bold;
  font-size: 2rem;
}

.pet-body {
  padding: 10px;
}
</style>