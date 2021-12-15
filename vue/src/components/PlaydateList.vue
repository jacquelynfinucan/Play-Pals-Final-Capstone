<template>
<div>
  <h1>My Playdates</h1>
    <br>
  <h1 class="playdate-status">
    Pending Playdates
    <div v-if="!pendingMinimized" v-on:click="pendingMinimized = true">
        <img class="expand-collapse-arrow" src="@/assets/collapse-arrow.png" alt="collapse"/>
    </div>
    <div v-if="pendingMinimized" v-on:click="pendingMinimized = false">
        <img class="expand-collapse-arrow" src="@/assets/expand-arrow.png" alt="expand"/>
    </div>
  </h1>
  <div class="pending" v-if="!pendingMinimized">
    <div class="filters">
      <span>Filters:</span>
      <div class="filter-category">
        <label for="usernameFilterPending">Username:</label>
        <input type="text" id="usernameFilterPending" v-model="filterPending.username" placeholder="Username" />&nbsp;
      </div>
      <div class="filter-category">
        <label for="petNameFilterPending">Pet Name:</label>
        <input type="text" id="petNameFilterPending" v-model="filterPending.petName" placeholder="Pet Name" />&nbsp;
      </div>
      <div class="filter-category">
        <label for="titleFilterPending">Playdate Title:</label>
        <input type="text" id="titleFilterPending" v-model="filterPending.title" placeholder="Playdate Title" />
      </div>
    </div>
        <br>
    <play-date-card
      v-for="playdate in filteredPendingPlaydates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    />
  </div>

  <h1 class="playdate-status">
    Confirmed Playdates
    <div v-if="!confirmedMinimized" v-on:click="confirmedMinimized = true">
      <img class="expand-collapse-arrow" src="@/assets/collapse-arrow.png" alt="collapse"/>
    </div>
    <div v-if="confirmedMinimized" v-on:click="confirmedMinimized = false">
      <img class="expand-collapse-arrow" src="@/assets/expand-arrow.png" alt="expand"/>
    </div>
  </h1>
  <div class="confirmed" v-if="!confirmedMinimized">
      <div class="filters">
        <span >Filters: </span>
        <div class="filter-category">
          <label for="usernameFilterConfirmed">Username:</label>
          <input type="text" id="usernameFilterConfirmed" v-model="filterConfirmed.username" placeholder="Username" />&nbsp;
        </div>
        <div class="filter-category">
          <label for="petNameFilterConfirmed">Pet Name:</label>
          <input type="text" id="petNameFilterConfirmed" v-model="filterConfirmed.petName" placeholder="Pet Name" />&nbsp;
        </div>
        <div class="filter-category">
          <label for="titleFilterConfirmed">Playdate Title:</label>
          <input type="text" id="titleFilterConfirmed" v-model="filterConfirmed.title" placeholder="Playdate Title" />
        </div>
      </div>
        <br>
      <play-date-card
        v-for="playdate in filteredConfirmedPlaydates"
        v-bind:key="playdate.PlayDateID"
        v-bind:playdate="playdate"
      />
  </div>

  <h1 class="playdate-status">
    Rejected Playdates
    <div v-if="!rejectedMinimized" v-on:click="rejectedMinimized = true">
      <img class="expand-collapse-arrow" src="@/assets/collapse-arrow.png" alt="collapse"/>
    </div>
    <div v-if="rejectedMinimized" v-on:click="rejectedMinimized = false">
      <img class="expand-collapse-arrow" src="@/assets/expand-arrow.png" alt="expand"/>
    </div>
  </h1>
  <div class="rejected" v-if="!rejectedMinimized">
      <div class="filters">
        <span>Filters: </span>
        <div class="filter-category">
          <label for="usernameFilterRejected">Username:</label>
          <input type="text" id="usernameFilterRejected" v-model="filterRejected.username" placeholder="Username" />&nbsp;
        </div>
        <div class="filter-category">
          <label for="petNameFilterRejected">Pet Name:</label>
          <input type="text" id="petNameFilterRejected" v-model="filterRejected.petName" placeholder="Pet Name" />&nbsp;
        </div>
        <div class="filter-category">
          <label for="titleFilterRejected">Playdate Title:</label>
          <input type="text" id="titleFilterRejected" v-model="filterRejected.title" placeholder="Playdate Title" />
        </div>
      </div>
      <play-date-card
        v-for="playdate in filteredRejectedPlaydates"
        v-bind:key="playdate.PlayDateID"
        v-bind:playdate="playdate"
      />
  </div>   
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
      pendingMinimized: false,
      filterPending: {
        username: '',
        petName: '',
        title: ''
      },
      confirmedMinimized: false,
      filterConfirmed: {
        username: '',
        petName: '',
        title: ''
      },
      rejectedMinimized: false,
      filterRejected: {
        username: '',
        petName: '',
        title: ''
      },
    };
  },
  computed: {
    filteredPendingPlaydates() { 
      let filteredPlaydates = this.pendingPlaydates;
      if (this.filterPending.username != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.hostUsername.toLowerCase().includes(this.filterPending.username.toLowerCase()) || playdate.guestUsername.toLowerCase().includes(this.filterPending.username.toLowerCase())
        );
      }
      if (this.filterPending.petName != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.hostPetName.toLowerCase().includes(this.filterPending.petName.toLowerCase()) || playdate.guestPetName.toLowerCase().includes(this.filterPending.petName.toLowerCase())
        );
      }
      if (this.filterPending.title != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.title.toLowerCase().includes(this.filterPending.title.toLowerCase())
        );
      }
      return filteredPlaydates;
    },
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
    },
    filteredRejectedPlaydates() { 
      let filteredPlaydates = this.rejectedPlaydates;
      if (this.filterRejected.username != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.hostUsername.toLowerCase().includes(this.filterRejected.username.toLowerCase()) || playdate.guestUsername.toLowerCase().includes(this.filterRejected.username.toLowerCase())
        );
      }
      if (this.filterRejected.petName != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.hostPetName.toLowerCase().includes(this.filterRejected.petName.toLowerCase()) || playdate.guestPetName.toLowerCase().includes(this.filterRejected.petName.toLowerCase())
        );
      }
      if (this.filterRejected.title != '') {
        filteredPlaydates = filteredPlaydates.filter((playdate) => playdate.title.toLowerCase().includes(this.filterRejected.title.toLowerCase())
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

h1 {
  border-radius: 5px;
  background-color: var(--primary-color);
  margin-top:0px;
  padding:20px;
  display: flex;
  flex-direction: row;
}

.playdate-status{
  justify-content: space-between;
}

.expand-collapse-arrow{
  width: 40px;
}

.filters{
  display: flex;
  border: solid 1px darkgrey;
  border-radius: 5px;

  padding: 10px;
  margin-bottom: 10px;
  display: flex;
  gap: 10px;
}
span{
  display: flex;
  align-items: center;
  font-weight: bold;
  padding-right: 30px;
}
.filter-category{
  display: flex;
  flex-direction: column;
  padding-right: 30px;
}
</style>