<template>
<div>
  <h1>My Playdates</h1>
  <br>
  <!--
  <div class="filters">
    <span>Filters: </span>
    <input type="text" id="usernameFilter" v-model="filter.username" placeholder="Username" />&nbsp;
    <input type="text" id="petNameFilter" v-model="filter.petName" placeholder="Pet Name" />&nbsp;
    <input type="text" id="titleFilter" v-model="filter.title" placeholder="Play Date Title" />
  </div>
  -->
    <h1>Pending Playdates</h1>
    <div class="filters">
      <span>Filters: </span>
      <input type="text" id="usernameFilterPending" v-model="filterPending.username" placeholder="Username" />&nbsp;
      <input type="text" id="petNameFilterPending" v-model="filterPending.petName" placeholder="Pet Name" />&nbsp;
      <input type="text" id="titleFilterPending" v-model="filterPending.title" placeholder="Play Date Title" />
    </div>
        <br>
    <play-date-card
      v-for="playdate in this.pendingPlaydates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    />

    <h1>Confirmed Playdates</h1>
    <div class="filters">
      <span>Filters: </span>
      <input type="text" id="usernameFilterConfirmed" v-model="filterConfirmed.username" placeholder="Username" />&nbsp;
      <input type="text" id="petNameFilterConfirmed" v-model="filterConfirmed.petName" placeholder="Pet Name" />&nbsp;
      <input type="text" id="titleFilterConfirmed" v-model="filterConfirmed.title" placeholder="Play Date Title" />
    </div>
        <br>
    <play-date-card
      v-for="playdate in filteredConfirmedPlaydates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    />

    <h1>Rejected/Canceled Playdates</h1>
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
      filterConfirmed: {
        username: '',
        petName: '',
        title: ''
      },
      filterPending: {
        username: '',
        petName: '',
        title: ''
      }
    };
  },
  computed: {
    filteredConfirmedPlaydates() { 
      let filteredPlaydates = this.confirmedPlaydates;
      if (this.filterConfirmed.username != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.hostUsername.toLowerCase().includes(this.filterConfirmed.username.toLowerCase()) || playdate.guestUsername.toLowerCase().includes(this.filterConfirmed.username.toLowerCase())
        );
      }
      if (this.filterConfirmed.petName != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.hostPetName.toLowerCase().includes(this.filterConfirmed.petName.toLowerCase()) || playdate.guestPetName.toLowerCase().includes(this.filterConfirmed.petName.toLowerCase())
        );
      }
      if (this.filterConfirmed.title != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.title.toLowerCase().includes(this.filterConfirmed.title.toLowerCase())
        );
      }
      return filteredPlaydates;
    }
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

<style scoped>
#main {
  border: solid 1px darkgrey;
  border-radius: 5px;
  background-color: white;
}

</style>