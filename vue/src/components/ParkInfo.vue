<template>
  <div>
      <h2> Welcome to {{location.name}} park!</h2>
      <h4> Address: {{location.formatted_address}}</h4>

      <h2> Add a play date? </h2>

        <form v-on:submit.prevent="registerPlaydate">
      <!-- <div class="status-message error" v-show="errorMsg !== ''">
        {{ errorMsg }}
      </div> -->
      
      <div>
        <label for="play-date-title">Play Date Title:</label>
        <input
          type="text"
          id="play-date-title"
          class="form-control"
          placeHolder="Playdate"
          v-model="newPlaydate.title"
          required
        />
      </div>
      <br>
        <label for="petSelection">Choose a pet:</label>
        <select v-model="newPlaydate.host_pet_id" name="petSelection" id="petSelection">
          <option  v-for="pet in pets" :key="pet.petId" :value="pet.petId" :v-text="pet.petName">{{pet.petName}}</option>/
        </select>
      <input type="submit" />

    </form>


      <!-- <h4>Playdates:</h4>
     <play-date-card
      v-for="playdate in this.playdates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    /> -->
      </div>
</template>

<script>
import petService from '../services/PetService'
import dateService from  '../services/DateService'
// import PlayDateCard from './PlayDateCard.vue'
export default {
  // components: { PlayDateCard },
    name: 'ParkInfo',
    data(){
        return{
            parkName:'placeholder',
            newPlaydate:{

            },
            locationPlaydates:{},
            location:{},
            pets:[],
        }

    },
    methods:{
       resetForm() {
      this.newPlaydate.title = "";
    },
      registerPlaydate(){
        dateService.AddPlayDate(this.newPlaydate).then((response) => {
            if (response.status == 200) {
                this.resetForm();
            }
          })
          .catch((error) => {
            if (error.response) {
              this.errorMsg =
                "Error creating playdate. Response received was " +
                error.response.statusText +
                ".";
            } else if (error.request) {
              this.errorMsg =
                "Error creating playdate. Server could not be reached.";
            } else {
              this.errorMsg =
                "Error creating playdate. Request could not be created.";
            }
          });
      }
    },
    created(){
        this.newPlaydate.host_user_id = this.$store.state.user.userId;
        //DateService.GetPlayDatesForLocation();
        this.location = this.$store.state.selectedLocation;
        this.newPlaydate.location_id = this.location.place_id;

         petService.getPetsForUser(this.$store.state.user.userId).then( (response) => {
            this.pets = response.data;
        })
    }
}
</script>

<style>

</style>