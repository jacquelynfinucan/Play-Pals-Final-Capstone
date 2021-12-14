<template>
  <div>
    <div class="loading" v-if="isLoading">
      <img src="@/assets/loading-dog.gif" alt="loading gif" />
    </div>
    <div v-else>
      <h2 class="title">{{ playDateThread.title }}</h2>
      <!-- bind when endpoint is implemented -->
      <form class="new-post-form" v-on:submit.prevent="addNewMessage">
        <input
          id="inputMessageText"
          type="text"
          placeholder="Message Text"
          v-model="newMessage.messageText"
          required
        />
        <input id="btnPost" type="submit" value="Post Message" />
      </form>
      <div v-for="message in this.messages" v-bind:key="message.messageID">
        <message-card v-bind:message="message" />
      </div>
    </div>
  </div>
</template>

<script>
import MessageCard from "../components/MessageCard";
import messageService from "../services/MessageService";
import dateService from "../services/DateService";

export default {
  name: "thread-card",
  components: {
    MessageCard,
  },
  data() {
    return {
      isLoading: true,
      errorMsg: "",
      messages: [],
      newMessage: {
        playDateID: this.$route.params.id,
        fromUserID: this.$store.state.user.userId,
        fromPetID: "",
        messageText: "",
      },
      playDateThread: {},
    };
  },
  created() {
    this.retrievePlayDateThreadForPlayDateID();
    this.retrieveMessagesForPlayDate();
  },
  methods: {
    addNewMessage() {
      this.newMessage.fromPetID =
        this.playDateThread.hostUserID == this.$store.state.user.userId
          ? this.playDateThread.hostPetID
          : this.playDateThread.guestPetID;

      messageService.addMessage(this.newMessage).then((response) => {
        if (response.status == 201) {
          this.newMessage = {
            playDateID: this.$route.params.id,
            fromUserID: this.$store.state.user.userId,
            fromPetID: "",
            messageText: "",
          };

          this.retrieveMessagesForPlayDate();
        }
      });
    },

    retrieveMessagesForPlayDate() {
      messageService
        .GetMessagesForPlayDate(this.$route.params.id)
        .then((response) => {
          this.messages = response.data;
          this.isLoading = false;
        });
    },

    retrievePlayDateThreadForPlayDateID() {
      dateService
        .getPlayDateThreadForPlayDateID(this.$route.params.id)
        .then((response) => {
          this.playDateThread = response.data;
        });
    },
  },
};
</script>

<style scoped>
.title {
  display: flex;
  justify-content: center;
  font-size: 35px;
}
.return-link {
  display: flex;
  justify-content: center;
  padding-bottom: 20px;
}
.new-post-form {
  display: flex;
  justify-content: center;
  margin-bottom: 10px;
  width: 100%;
}

#inputMessageText {
    width: 40%;
    margin-right: 10px;
    padding: 5px;
    border-radius: 5px;
}

#btnPost {
  background-color: var(--tertiary-color);
  border: none;
  color: white;
  padding: 10px 25px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 15px;
  border-style: solid;
  border-color: black;
  border-width: 1px;
  color: black;
  border-radius: 5px;
}
</style>