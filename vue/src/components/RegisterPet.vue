<template>
  <div>
    <h1 v-if="!this.isEdit">Welcome. Please enter your pet information.</h1>
    <h1 v-if="this.isEdit">Update your pet information.</h1>

    <form v-on:submit.prevent="registerPet">
      <div class="status-message error" v-show="errorMsg !== ''">
        {{ errorMsg }}
      </div>
      
      <div>
        <label for="petName">Pet Name: </label>
        <input
          type="text"
          id="petName"
          class="form-control"
          placeHolder="Pet Name" 
          v-model="pet.petName"
          required>
      </div>

      <div>
        <label for="animalType">Pet Type: </label>
        <select name="animalType"
          id="animalType"
          v-model="pet.animalType"
          required> <!--class="form-control"  -->
        <option value="dog">Dog</option>
        <option value="cat">Cat</option>
        <option value="fish">Fish</option>
        <option value="other">Other</option>
        </select>
      </div>

      <div>
        <label for="breed">Breed: </label>
        <input
          type="text"
          id="breed"
          class="form-control"
          placeHolder="Breed" 
          v-model="pet.breed"
          required> 
      </div>

      <div>
        <label for="age">Age: </label>
        <input
          type="number"
          id="age"
          class="form-control"
          placeHolder="Age" 
          v-model.number="pet.age"
          required> 
      </div>

      <div>
        <label for="size">Size: </label>
        <select name="size"
          id="size"
          v-model.number="pet.size"
          required> <!--class="form-control"  -->
        <option value=1>Small</option>
        <option value=2>Medium</option>
        <option value=3>Large</option>
        </select>
      </div> 

      <div>
        <label for="is_male">Gender: </label>
        <select name="is_male"
          id="is_male"
          v-model="pet.is_male"
          required> 
        <option value=true>Male</option>
        <option value=false>Female</option>
        </select>
      </div> 

      
      <div>
        <label for="is_spayed_neutered">Is spayed or neutered? </label>
        <select name="is_spayed_neutered"
          id="is_spayed_neutered" 
          v-model="pet.is_spayed_neutered"
          required> 
        <option value=true>Yes</option>
        <option value=false>No</option>
        </select>
      </div> 

      <div>
        <label for="description">Description: </label>
        <input
          type="textarea"
          rows=2
          column=1
          id="description"
          class="form-control"
          placeHolder="Description" 
          v-model="pet.description"
          required> 
      </div>

      <input type="submit">
    </form>
  </div>
</template>

<script>
import petService from "../services/PetService";

export default {
  name: "register-pet",
  data() {
    return {
      pets: [],
      pet: {
      pet_name: "",
      animal_type: "",
      breed: "", 
      age: "", 
      size: "", 
      is_male: null, 
      is_spayed_neutered: null, 
      description: ""
    },
      errorMsg: "",
      isEdit: false,
    };
  },
  methods: {
    registerPet() {
      if (this.isEdit == false) {
        petService.addPetForUser(this.$store.state.profile.userId, this.pet)
          .then((response) => {
            if (response.status == 200) {
              this.$router.push({ name: "profile" });
            }
          })
          .catch((error) => {
            if (error.response) {
              this.errorMsg =
                "Error creating profile. Response received was '" +
                error.response.statusText +
                "'.";
            } else if (error.request) {
              this.errorMsg =
                "Error creating profile. Server could not be reached.";
            } else {
              this.errorMsg =
                "Error creating profile. Request could not be created.";
            }
          });
      }
      // } else {
      //   petService.UpdateAPet(this.userId, this.pet)
      //     .then((response) => {
      //       if (response.status == 200) {
      //         this.$router.push({ name: "profile" });
      //       }
      //     })
      //     .catch((error) => {
      //       if (error.response) {
      //         this.errorMsg =
      //           "Error creating profile. Response received was '" +
      //           error.response.statusText +
      //           "'.";
      //       } else if (error.request) {
      //         this.errorMsg =
      //           "Error creating profile. Server could not be reached.";
      //       } else {
      //         this.errorMsg =
      //           "Error creating profile. Request could not be created.";
      //       }
      //     });
      // }
    }
  },
  created() {
    this.pets = this.$store.state.pets;

    // if (this.pets != []) {
    //   this.isEdit = true;
    // }
  },
};
</script>

<style scoped>
.status-message.error {
  color: red;
}
</style>