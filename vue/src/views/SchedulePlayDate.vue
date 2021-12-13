<template>
  <div>
    <h1>View Pets</h1>
    <pet-card class="list" v-bind:pet="pet" v-bind:isViewOnly="true" v-for="pet in allPets" v-bind:key="pet.petID" />
  </div>
</template>

<script>
import PetService from "../services/PetService";
import PetCard from "../components/PetCard";
export default {
  components: {
    PetCard,
  },
  data() {
    return {
      allPets: [],
      
    };
  },
  methods: {
    retrieveAllPets() {
      PetService.getAllPets().then((response) => {
        if (response.status == 200) {
          this.allPets = response.data;
        }
      });
    },
  },
  created(){
      this.retrieveAllPets()
  }
};
</script>

<style>
.list{
    display:flex;
    justify-content: space-between;
    flex-wrap: wrap;
}

</style>