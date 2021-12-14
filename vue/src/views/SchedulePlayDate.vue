<template>
  <div>
    <h1>View Pets</h1>

    <div>
      <span id="filterTitle">Pet Filters</span>
    </div>

    <div class="pet-filters">
      <div>
        <label for="petNameFilter">Pet Name: </label>
        <input
          type="text"
          name="petNameFilter"
          id="petNameFilter"
          v-model="filter.petName"
          placeholder="Pet Name"
        />
      </div>
      <div>
        <label for="breedFilter">Breed: </label>
        <input
          type="text"
          name="breedFilter"
          id="breedFilter"
          v-model="filter.breed"
          placeholder="Breed"
        />
      </div>
      <div>
        <label for="filterSize">Size: </label>
        <select name="filterSize" id="filterSize" v-model.number="filter.size">
          <option value="All">All</option>
          <option value="1">Small</option>
          <option value="2">Medium</option>
          <option value="3">Large</option>
        </select>
      </div>
      <div>
        <label for="genderFilter">Gender: </label>
        <select name="genderFilter" id="genderFilter" v-model="filter.gender">
          <option value="All">All</option>
          <option v-bind:value="true">Male</option>
          <option v-bind:value="false">Female</option>
        </select>
      </div>
      <div>
        <label for="spayedFilter">Is spayed or neutered? </label>
        <select name="spayedFilter" id="spayedFilter" v-model="filter.isSpayed">
          <option value="All">All</option>
          <option v-bind:value="true">Yes</option>
          <option v-bind:value="false">No</option>
        </select>
      </div>
      <div class="personality-filters">
        <span id="personalityTitle"
          >Personality Traits (check all that apply):
        </span>

        <div id="Energetic">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="1"
            v-model.number="filter.personalityTraits"
          />
          <label for="1">Energetic</label>
        </div>

        <div id="Calm">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="2"
            v-model.number="filter.personalityTraits"
          />
          <label for="2">Calm</label>
        </div>

        <div id="Shy">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="3"
            v-model.number="filter.personalityTraits"
          />
          <label for="3">Shy</label>
        </div>

        <div id="Anxious">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="4"
            v-model.number="filter.personalityTraits"
          />
          <label for="4">Anxious</label>
        </div>

        <div id="Aggressive">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="5"
            v-model.number="filter.personalityTraits"
          />
          <label for="5">Aggressive</label>
        </div>

        <div id="Not_Good_With_Kids">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="6"
            v-model.number="filter.personalityTraits"
          />
          <label for="6">Not Good With Kids</label>
        </div>

        <div id="Not_Good_With_Animals_Other_Than_Dogs">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="7"
            v-model.number="filter.personalityTraits"
          />
          <label for="7">Not Good With Animals Other Than Dogs</label>
        </div>

        <div id="House_Trained">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="8"
            v-model.number="filter.personalityTraits"
          />
          <label for="8">House Trained</label>
        </div>

        <div id="Command_Trained">
          <input
            type="checkbox"
            name="filter.personalityTraits"
            value="9"
            v-model.number="filter.personalityTraits"
          />
          <label for="9">Command Trained</label>
        </div>
      </div>
    </div>

    <div class="list">
      <pet-card
        v-bind:pet="pet"
        v-bind:isViewOnly="true"
        v-for="pet in filteredPets"
        v-bind:key="pet.petID"
      />
    </div>
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
      filter: {
        petName: "",
        breed: "",
        size: "All",
        gender: "All",
        isSpayed: "All",
        personalityTraits: [],
      },
    };
  },
  methods: {
    retrieveAllPets() {
      PetService.getAllPetsNotForUser(this.$store.state.user.userId).then(
        (response) => {
          if (response.status == 200) {
            this.allPets = response.data;
          }
        }
      );
    },
  },
  created() {
    this.retrieveAllPets();
  },
  computed: {
    filteredPets() {
      let filteredPets = this.allPets;

      if (this.filter.petName != "") {
        filteredPets = filteredPets.filter((pet) =>
          pet.petName.toLowerCase().includes(this.filter.petName.toLowerCase())
        );
      }

      if (this.filter.breed != "") {
        filteredPets = filteredPets.filter((pet) =>
          pet.breed.toLowerCase().includes(this.filter.breed.toLowerCase())
        );
      }

      if (this.filter.size != "All") {
        filteredPets = filteredPets.filter(
          (pet) => pet.size == this.filter.size
        );
      }

      if (this.filter.gender != "All") {
        filteredPets = filteredPets.filter(
          (pet) => pet.isMale == this.filter.gender
        );
      }

      if (this.filter.isSpayed != "All") {
        filteredPets = filteredPets.filter(
          (pet) => pet.isSpayed == this.filter.isSpayed
        );
      }

      if (this.filter.personalityTraits.length != 0) {
        filteredPets = filteredPets.filter(
          (pet) => {
            let isMatch = true;
            
            this.filter.personalityTraits.forEach((id) => {
              let isFound = pet.personalityTraits.includes(id);
              if (isFound == false) {
                isMatch = false;
              }
            });

            return isMatch;
          }
        );
      }

      return filteredPets;
    },
  },
};
</script>

<style scoped>
.list {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  gap: 10px;
}

#filterTitle {
  font-weight: bold;
}

.pet-filters {
  border: solid 1px darkgrey;
  border-radius: 5px;

  padding: 10px;
  margin-bottom: 10px;

  display: flex;
  gap: 10px;
}

.personality-filters {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-template-areas:
    "title title title"
    "energentic calm shy"
    "anxious aggressive kids"
    "otherDogs houseTrained commandTrained";
}

#personalityTitle {
  grid-area: title;
}

#Energetic {
  grid-area: energentic;
}

#Calm {
  grid-area: calm;
}

#Shy {
  grid-area: shy;
}

#Anxious {
  grid-area: anxious;
}

#Aggressive {
  grid-area: aggressive;
}

#Not_Good_With_Kids {
  grid-area: kids;
}

#Not_Good_With_Animals_Other_Than_Dogs {
  grid-area: otherDogs;
}

#House_Trained {
  grid-area: houseTrained;
}

#Command_Trained {
  grid-area: commandTrained;
}
</style>