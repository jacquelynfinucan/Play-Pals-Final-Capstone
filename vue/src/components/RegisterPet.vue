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
        <label for="animalType">Animal Type: </label>
        <select
          name="animalType"
          id="animalType"
          v-model="pet.animalType"
          required
        >
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
        <!--Have to require age to be at least 0, no negative numbers -->
        <label for="age">Age: </label>
        <input
          type="number"
          id="age"
          class="form-control"
          placeHolder="Age"
          v-model.number="pet.age"
        />
      </div>

      <div>
        <label for="size">Size: </label>
        <select name="size" id="size" v-model.number="pet.size" required>
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
        <select name="isSpayed" id="isSpayed" v-model="pet.isSpayed" required>
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

      <div>
        <label for="personality_title"
          >Personality Traits (check all that apply):
        </label>

        <input
          type="checkbox"
          id="Energetic"
          name="pet.personalityTraits"
          value="1"
          v-model.number="pet.personalityTraits"
        />
        <label for="1">Energetic</label>

        <input
          type="checkbox"
          id="Calm"
          name="pet.personalityTraits"
          value="2"
          v-model.number="pet.personalityTraits"
        />
        <label for="2">Calm</label>

        <input
          type="checkbox"
          id="Shy"
          name="pet.personalityTraits"
          value="3"
          v-model.number="pet.personalityTraits"
        />
        <label for="3">Shy</label>

        <input
          type="checkbox"
          id="Anxious"
          name="pet.personalityTraits"
          value="4"
          v-model.number="pet.personalityTraits"
        />
        <label for="4">Anxious</label>

        <input
          type="checkbox"
          id="Aggressive"
          name="pet.personalityTraits"
          value="5"
          v-model.number="pet.personalityTraits"
        />
        <label for="5">Aggressive</label>

        <input
          type="checkbox"
          id="Not_Good_With_Kids"
          name="pet.personalityTraits"
          value="6"
          v-model.number="pet.personalityTraits"
        />
        <label for="6">Not Good With Kids</label>

        <input
          type="checkbox"
          id="Not_Good_With_Animals_Other_Than_Dogs"
          name="pet.personalityTraits"
          value="7"
          v-model.number="pet.personalityTraits"
        />
        <label for="7">Not Good With Animals Other Than Dogs</label>

        <input
          type="checkbox"
          id="House_Trained"
          name="pet.personalityTraits"
          value="8"
          v-model.number="pet.personalityTraits"
        />
        <label for="8">House Trained</label>

        <input
          type="checkbox"
          id="Command_Trained"
          name="pet.personalityTraits"
          value="9"
          v-model.number="pet.personalityTraits"
        />
        <label for="9">Command Trained</label>
      </div>

      <label for="submit" v-if="!this.isEdit">Finished adding pets? </label>
      <input type="submit" /><br />

      <button v-if="!this.isEdit" v-on:click="moreToAdd = true">Save and add another pet</button>
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
        isMale: null,
        isSpayed: null,
        description: "",
        personalityTraits: [],
      },
      errorMsg: "",
      isEdit: false,
      moreToAdd: false,
    };
  },
  methods: {
    registerPet() {
      if (this.isEdit == false) {
        petService
          .addPetForUser(this.$store.state.user.userId, this.pet)
          .then((response) => {
            if (response.status == 200) {
              if (!this.moreToAdd) {
                this.$router.push({ name: "profile" });
              } else {
                this.$router.push({ name: "register-pet" });
                this.moreToAdd = false;
                this.resetForm();
              }
            }
          })
          .catch((error) => {
            if (error.response) {
              this.errorMsg =
                "Error creating pet. Response received was " +
                error.response.statusText +
                ".";
            } else if (error.request) {
              this.errorMsg =
                "Error creating pet. Server could not be reached.";
            } else {
              this.errorMsg =
                "Error creating pet. Request could not be created.";
            }
          });
      } else { // isEdit = true
        petService
          .updateAPet(this.pet.petId, this.pet)
          .then((response) => {
            if (response.status == 200) {
              this.$router.push({ name: "profile" });
            }
          })
          .catch((error) => {
            if (error.response) {
              this.errorMsg =
                "Error updating pet. Response received was '" +
                error.response.statusText +
                "'.";
            } else if (error.request) {
              this.errorMsg =
                "Error updating pet. Server could not be reached.";
            } else {
              this.errorMsg =
                "Error updating pet. Request could not be created.";
            }
          });
      }
    },
    resetForm() {
      this.pet = {
        petName: "",
        animalType: "",
        breed: "",
        age: "",
        size: "",
        isMale: null,
        isSpayed: null,
        description: "",
        personalityTraits: [],
      };
    },
  },
  created() {
    this.pets = this.$store.state.pets;
    this.pet = this.$store.state.currentPet;

    if (this.pet.petName != "") {
      //if there is a petName already, then we're in edit mode
      this.isEdit = true;
      this.pet.personalityTraits = [];
    }
    else
    {
      this.resetForm();
    }
  },
};
</script>

<style scoped>
.status-message.error {
  color: red;
}
</style>