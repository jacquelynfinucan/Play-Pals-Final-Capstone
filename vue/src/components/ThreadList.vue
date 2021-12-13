<template>
  <div class="thread-list">
    <h1 class="thread-title">My Message Threads</h1>
    <div class="threads">
      
      <div class="filters">
          <span>Filters: </span>
          <input type="text" id="usernameFilter" v-model="filter.username" placeholder="Username" />&nbsp;
          <input type="text" id="petNameFilter" v-model="filter.petName" placeholder="Pet Name" />&nbsp;
          <input type="text" id="titleFilter" v-model="filter.title" placeholder="Play Date Title" />
      </div>

      <div class="status-message error" v-show="errorMsg !== ''">
        {{ errorMsg }}
      </div>

      <div class="loading" v-if="isLoading">
        <img src="@/assets/loading-dog.gif" alt="loading gif" />
      </div>

      <router-link v-for="playDate in this.filteredPlayDates" v-bind:key="playDate.playDateID" v-bind:to="{name: 'thread', params: {id: playDate.playDateID}}">
          <div  class="thread-card">
              <h3>{{ playDate.title }}</h3>
              <p>Host: {{ playDate.hostUsername }}({{ playDate.hostPetName }})</p>
              <p>Guest: {{ playDate.guestUsername }}({{ playDate.guestPetName }})</p>
              <p class="last-message-date" v-if="playDate.latestMessageDate">Last Message: {{ playDate.latestMessageDate }}</p>
              <p class="last-message-date" v-else>No Messages Yet</p>
          </div>
      </router-link>

    </div>
  </div>
</template>

<script>
import dateService from "../services/DateService";

export default {
  name: "thread-list",
  data() {
    return {
      isLoading: true,
      errorMsg: "",
      playDates: [],
      filter: {
          username: '',
          petName: '',
          title: ''
      }
    };
  },
  computed: {
      filteredPlayDates() {
          let filteredThreds = this.playDates;

          if (this.filter.username != "") {
            filteredThreds = filteredThreds.filter((thread) =>
                thread.hostUsername
                    .toLowerCase()
                    .includes(this.filter.username.toLowerCase())
                || thread.guestUsername
                    .toLowerCase()
                    .includes(this.filter.username.toLowerCase())
            );
          }

          if (this.filter.petName != "") {
            filteredThreds = filteredThreds.filter((thread) =>
                thread.hostPetName
                    .toLowerCase()
                    .includes(this.filter.petName.toLowerCase())
                || thread.guestPetName
                    .toLowerCase()
                    .includes(this.filter.petName.toLowerCase())
            );
          }

          if (this.filter.title != "") {
            filteredThreds = filteredThreds.filter((thread) =>
                thread.title
                    .toLowerCase()
                    .includes(this.filter.title.toLowerCase())
            );
          }

          return filteredThreds;
      }
  },
  created() {
    this.retrieveThreadsForUser();
  },
  methods: {
    retrieveThreadsForUser() {
      dateService
        .getPlayDateThreadsForUser(this.$store.state.user.userId)
        .then((response) => {
          this.playDates = response.data;
          this.isLoading = false;
        })
        .catch((error) => {
          if (error.response) {
            this.errorMsg =
              "Error retrieving message threads. Response received was '" +
              error.response.statusText +
              "'.";
          } else if (error.request) {
            this.errorMsg =
              "Error retrieving message threads. Server could not be reached.";
          } else {
            this.errorMsg =
              "Error retrieving message threads. Request could not be created.";
          }

          this.isLoading = false;
        });
    },
  },
};
</script>

<style scoped>
.thread-card {
    border: solid 1px darkgrey;
    border-radius: 5px;

    padding: 10px;

    margin-bottom: 10px;
}

.last-message-date {
    font-style: italic;
    text-align: right;
}

.status-message.error {
    color: red;
}

.filters {
    padding-bottom: 10px;
}
</style>