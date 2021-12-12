<template>
  <div>
      <h2> Welcome to {{location.name}} park!</h2>
      <h4> Address: {{location.formatted_address}}</h4>
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
            playdates:{},
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