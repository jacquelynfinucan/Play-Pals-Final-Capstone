<template>
<div>
    <h1>Pending Playdates</h1>
    <play-date-card
      v-for="playdate in this.pendingPlaydates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    />

    <h1>Confirmed Playdates</h1>
    <play-date-card
      v-for="playdate in this.confirmedPlaydates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    />

    <h1>Rejected Playdates</h1>
    <play-date-card
      v-for="playdate in this.rejectedPlaydates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    />
</div>
</template>

<script>
import PlayDateCard from "./PlayDateCard.vue";
import DateService from "../services/DateService";

export default {
    components: { PlayDateCard },
    data() {
    return {
      pendingPlaydates: [],
      confirmedPlaydates: [],
      rejectedPlaydates: [],
    };
  },
    created(){
        DateService.GetAllPlayDatesForUser(this.$store.state.user.userId).then( (response) => {
        this.playdates = response.data;
      });
      DateService.GetPlayDatesForUserByStatus(this.$store.state.user.userId, 1).then( (response) => {
        this.pendingPlaydates = response.data;
      });
      DateService.GetPlayDatesForUserByStatus(this.$store.state.user.userId, 2).then( (response) => {
        this.confirmedPlaydates = response.data;
      });
      DateService.GetPlayDatesForUserByStatus(this.$store.state.user.userId, 3).then( (response) => {
        this.rejectedPlaydates = response.data;
      });
    }
}
</script>

<style>
#main {
  border: solid 1px darkgrey;
  border-radius: 5px;
  background-color: white;
  margin-bottom: 10px;
}

h1 {
  border-radius: 5px;
  background-color: #59d697;
  margin-top:0px;
  padding:20px;
  display: flex;
  flex-direction: row;
}
</style>