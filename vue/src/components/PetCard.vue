<template>
  <div class="pet-card">
    <div class="pet-header">
      <img
        class="pet-img"
        src="https://randomuser.me/api/portraits/lego/1.jpg"
        alt="pet picture"
      />
      <p class="pet-name">{{ pet.petName }}</p>
      <p v-if="pet.description != ''" class="description">Description: {{ pet.description }}</p>
      <!--eventually come back & make name, breed, and description first letter ToUpper or sentence case -->
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

      <p>Personality Traits:</p>
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
    <button v-if="isViewOnly == false" id="btnEditPet" v-on:click="goToEditPet">Edit Pet</button>
    <button v-if="isViewOnly == true" v-on:click="goToSchedulePlayDate(pet.petId)">Schedule Play Date</button>
    <!--<button id="btnDeletePet" v-on:click="deletePet">Delete Pet</button>-->
  </div>
</template>

<script>
import petService from "@/services/PetService.js";
export default {
  name: "pet-card",
  props: ["pet", "isViewOnly"],
  data(){
    return{

    }
  },
  methods: {
    goToEditPet() {
      this.$store.commit("SET_CURRENT_PET", this.pet);
      this.$router.push({ name: "register-pet" });
    },
    deletePet() {
      if (confirm("Are you sure?")) {
        petService.deleteAPet(this.pet.petId).then((response) => {
          if (response.status == 204) {
            this.$store.commit("REMOVE_CURRENT_PET");
            this.$router.go();//push({name: "profile"});
          }
        });
      }
    },
    goToSchedulePlayDate(petID){
      this.$store.commit("SET_SAVED_PET_ID",petID);
      this.$router.push({name:"CreateDate"}); //push to schedule play date view??
    }
  },
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

.pet-name {
  font-weight: bold;
  font-size: 2rem;
}

.pet-body {
  padding: 10px;
  height:425px;
}
</style>