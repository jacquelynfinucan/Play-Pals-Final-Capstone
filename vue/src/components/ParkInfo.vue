<template>
  <div>
      <h2> Welcome to {{parkName}} park!</h2>
      <h4>Playdates:</h4>
  <play-date-card>
      </div>
</template>

<script>
import PlayDateCard from './PlayDateCard.vue'
export default {
  components: { PlayDateCard },
    name: 'ParkInfo',
    data(){
        return{
            parkName:'placeholder',
            playdates:{},
        }

    }
}
</script>

<style>

</style>