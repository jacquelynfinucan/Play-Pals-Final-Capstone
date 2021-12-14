<template>
  <div class="pet-list">
      <h1>My Pets</h1>
      <button id="btnAddPet" v-on:click="goToRegisterNewPet">Add A New Pet</button> <!--make sure add a new pet refreshes the form-inconsistent-->
      <div class="pets">
            <div class="status-message error" v-show="errorMsg !== ''">{{errorMsg}}</div>
            
            <div class="loading" v-if="isLoading">
                <img src="@/assets/loading-dog.gif" alt="loading gif"/>
            </div>

            
            <div class="pet" v-for="pet in this.$store.state.pets" v-bind:key="pet.pet_id" v-else>
                <pet-card v-bind:pet="pet" v-bind:isViewOnly="false"/>
            </div>
      </div>
  </div>
</template>

<script>
import petService from '@/services/PetService.js';
import PetCard from '@/components/PetCard.vue';

export default {
  name: 'pet-list',
  components: {
      PetCard
  },
  data() {
      return {
          isLoading: true,
          errorMsg: ''
      }
  },
  created() {
      this.retrievePetsForUser();
  },
  methods: {
      retrievePetsForUser() {       
        petService.getPetsForUser(this.$store.state.user.userId).then( (response) => {
            this.$store.commit("SET_PETS", response.data);
            this.isLoading = false;
        }).catch( (error) => {
            if (error.response) {
                this.errorMsg =
                "Error retrieving pets. Response received was '" +
                error.response.statusText +
                "'.";
            } else if (error.request) {
                this.errorMsg =
                "Error retrieving pets. Server could not be reached.";
            } else {
                this.errorMsg =
                "Error retrieving pets. Request could not be created.";
            }

            this.isLoading = false;
        });
      }, 
    goToRegisterNewPet() {
        this.$store.commit("SET_CURRENT_PET", {
        petName: "",
        animalType: "",
        breed: "",
        age: "",
        size: "",
        isMale: null,
        isSpayed: null,
        description: "",
        personalityTraits: [],
      });
      this.$router.push({ name: "register-pet" });
    },
  }
};
</script>

<style scoped>
.pets {
    border: solid 1px darkgrey;
    border-radius: 5px;

    padding: 10px;

    margin-bottom: 10px;

    background-color: lightgrey;
    display:grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    gap:10px;
}

.status-message.error {
    color: red;
}

button {
    margin: 5px;
}


</style>