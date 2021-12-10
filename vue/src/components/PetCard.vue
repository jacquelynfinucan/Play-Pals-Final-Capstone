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

      <p>Personality Traits: </p>
      <!-- <ul>
        <li v-for="trait in this.pet.personalityTraits" v-bind:key="trait" >
        {{trait}} 
        </li>
      </ul> -->
      <ul>
      <li v-if="this.pet.personalityTraits.includes(1)">Energetic</li>
      <li v-if="this.pet.personalityTraits.includes(2)">Calm</li>
      <li v-if="this.pet.personalityTraits.includes(3)">Shy</li>
      <li v-if="this.pet.personalityTraits.includes(4)">Anxious</li>
      <li v-if="this.pet.personalityTraits.includes(5)">Aggressive</li>
      <li v-if="this.pet.personalityTraits.includes(6)">Not Good With Kids</li>
      <li v-if="this.pet.personalityTraits.includes(7)">Not Good With Animals Other Than Dogs</li>
      <li v-if="this.pet.personalityTraits.includes(8)">House Trained</li>
      <li v-if="this.pet.personalityTraits.includes(9)">Command Trained</li>
      </ul>
    </div>  
  </div>
</template>

<script>
export default {
  name: 'pet-card',
  props: ['pet'], 
  data(){
    return {
      name : ""
    }
  }, 
  methods: {
    convertTrait(trait){
      const name ="";
      if(trait == 1)
      {
        this.name = "Energetic";
      }
      else if(trait == 2){
        this.name = "Calm";
      }
      else if(trait == 3){
        this.name = "Shy";
      }
      else if(trait == 4){
        this.name = "Anxious";
      }
      else if(trait == 5){
        this.name = "Aggressive";
      }
      else if(trait == 6){
        this.name = "Not Good With Kids";
      }
      else if(trait == 7){
        this.name = "Not Good With Animals Other Than Dogs";
      }
      else if(trait == 8){
        this.name = "House Trained";
      }
      else if(trait == 9) {
        this.name = "Command Trained";
      }
      return name;
    }
  }
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