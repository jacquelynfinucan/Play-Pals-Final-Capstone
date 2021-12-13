<template>
  <div>
      <h2> Welcome to {{location.name}} park!</h2>
      <h4> Address: {{location.formatted_address}}</h4>

      <h2> Add a play date? </h2>

        <form v-on:submit.prevent="registerProfile">
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
    </form>


      <h4>Playdates:</h4>
     <play-date-card
      v-for="playdate in this.playdates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    />
      </div>
</template>

<script>
import PlayDateCard from './PlayDateCard.vue'
//import DateService from '../services/DateService'
export default {
  components: { PlayDateCard },
    name: 'ParkInfo',
    data(){
        return{
            parkName:'placeholder',
            newPlaydate:{},
            locationPlaydates:{},
            location:{},
        }

    },
    created(){
        //DateService.GetPlayDatesForLocation();
        this.location = this.$store.state.selectedLocation;
    }
}
</script>

<style>

</style>