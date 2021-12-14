<template>
  <div>
      <div class="loading" v-if="isLoading">
            <img src="@/assets/loading-dog.gif" alt="loading gif"/>
      </div>
      <div v-else>
            <h2 class="title">{{ playDateThread.title }}</h2> <!-- bind when endpoint is implemented -->
            <router-link class="return-link" :to="{ name: 'messages' }">Return to Message Threads</router-link>
            <form class="new-post-form" v-on:submit.prevent="addNewMessage">
                <input type="text" placeholder="Message Text" v-model="newMessage.messageText" required/>
                <input type="submit" />
            </form>
            <div v-for="message in this.messages" v-bind:key="message.messageID">
                <message-card v-bind:message="message"/>
            </div> 
      </div>
  </div>
</template>

<script>
import MessageCard from '../components/MessageCard';
import messageService from '../services/MessageService';
import dateService from "../services/DateService";

export default {
    name: 'thread-card',
    components: {
        MessageCard
    },
    data() {
        return {
            isLoading: true,
            errorMsg: '',
            messages: [],
            newMessage: {
                playDateID: this.$route.params.id,
                fromUserID: this.$store.state.user.userId,
                fromPetID: '',
                messageText: ''
            },
            playDateThread: {}
        };
    },
    created() {
        this.retrievePlayDateThreadForPlayDateID();    
        this.retrieveMessagesForPlayDate();      
    },
    methods: {
        addNewMessage() { 
            this.newMessage.fromPetID = this.playDateThread.hostUserID == this.$store.state.user.userId ? this.playDateThread.hostPetID : this.playDateThread.guestPetID;
            
            messageService.addMessage(this.newMessage).then( (response) => {
                
                if (response.status == 201) {                   
                    this.newMessage = {
                        playDateID: this.$route.params.id,
                        fromUserID: this.$store.state.user.userId,
                        fromPetID: '',
                        messageText: ''
                    }

                    this.retrieveMessagesForPlayDate();
                }
            });
        },
        
        retrieveMessagesForPlayDate() {
            messageService.GetMessagesForPlayDate(this.$route.params.id).then((response) => {
                this.messages = response.data;
                this.isLoading = false;
            });
        },

        retrievePlayDateThreadForPlayDateID() {
            dateService.getPlayDateThreadForPlayDateID(this.$route.params.id).then((response) => {
                this.playDateThread = response.data;
            });
        }
    }
}
</script>

<style scoped>
.title{
    display: flex;
    justify-content: center;
    font-size: 35px;
}
.return-link{
    display: flex;
    justify-content: center;
    padding-bottom: 20px;
}
.new-post-form{
    display: flex;
    justify-content: center;
    margin-bottom: 10px;
    width: 40%;
}
</style>