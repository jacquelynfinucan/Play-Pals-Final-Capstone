<template>
  <div class="thread-list">
    <h1 class="thread-title">My Message Threads</h1>
    <div class="threads">
      
      <div class="status-message error" v-show="errorMsg !== ''">
        {{ errorMsg }}
      </div>

      <div class="loading" v-if="isLoading">
        <img src="@/assets/loading-dog.gif" alt="loading gif" />
      </div>

      <router-link v-for="playDate in this.playDates" v-bind:key="playDate.playDateID" v-bind:to="{name: 'thread', params: {id: playDate.playDateID}}">
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
    };
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
</style>