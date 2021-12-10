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
          required
        />
      </div>

      <div>
        <label for="animalType">Pet Type: </label>
        <select
          name="animalType"
          id="animalType"
          v-model="pet.animalType"
          required> <!--class="form-control"  -->
        <option value="Dog">Dog</option>
        <option value="Cat">Cat</option>
        <option value="Fish">Fish</option>
        <option value="Other">Other</option>
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
          required
        />
      </div>

      <div>
        <label for="age">Age: </label>
        <input
          type="number"
          id="age"
          class="form-control"
          placeHolder="Age"
          v-model.number="pet.age"
          required
        />
      </div>

      <div>
        <label for="size">Size: </label>
        <select name="size" id="size" v-model.number="pet.size" required>
          <!--class="form-control"  -->
          <option value="1">Small</option>
          <option value="2">Medium</option>
          <option value="3">Large</option>
        </select>
      </div>

      <div>
        <label for="isMale">Gender: </label>
        <select name="isMale" id="isMale" v-model="pet.isMale" required>
          <option v-bind:value="true">Male</option>
          <option v-bind:value="false">Female</option>
        </select>
      </div>

      <div>
        <label for="isSpayed">Is spayed or neutered? </label>
        <select
          name="isSpayed"
          id="isSpayed"
          v-model="pet.isSpayed"
          required
        >
          <option v-bind:value="true">Yes</option>
          <option v-bind:value="false">No</option>
        </select>
      </div>

      <div>
        <label for="description">Description: </label>
        <input
          type="textarea"
          rows="2"
          column="1"
          id="description"
          class="form-control"
          placeHolder="Description"
          v-model="pet.description"
        />
      </div>
      <!-- Come back & add pet personality traits as checkboxes -->

      <label for="submit">Finished adding pets? </label>
      <input type="submit" />

      <button v-on:click="moreToAdd=true">Add another pet</button>

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
        petName: "",
        animalType: "",
        breed: "",
        age: "",
        size: "",
        isMale: false,
        isSpayed: false,
        description: "",
      },
      errorMsg: "",
      isEdit: false,
      moreToAdd: false
    };
  },
  methods: {
    registerPet() {
      if (this.isEdit == false) {
        petService
          .addPetForUser(this.$store.state.user.userId, this.pet)
          .then((response) => {
            if (response.status == 200) {
              if(!this.moreToAdd){
                this.$router.push({ name: "profile" });
              } 
              else{
                this.$router.push({ name: "register-pet"})
                this.moreToAdd = false;
                this.resetForm();
              } 
            }
          })
          .catch((error) => {
            if (error.response) {
              this.errorMsg =
                "Error creating profile. Response received was " +
                error.response.statusText +
                ".";
            } else if (error.request) {
              this.errorMsg =
                "Error creating profile. Server could not be reached.";
            } else {
              this.errorMsg =
                "Error creating profile. Request could not be created.";
            }
          });

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
    resetForm(){
       this.pet = {
        pet_name: "",
         animal_type: "",
         breed: "",
         age: "",
         size: "",
         isMale: false,
         isSpayed: false,
         description: "",
       }
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