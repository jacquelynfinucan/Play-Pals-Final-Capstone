<template>
  <div>
      <div class="loading" v-if="isLoading">
            <img src="@/assets/loading-dog.gif" alt="loading gif"/>
      </div>
      <div v-else>
            <h2 class="title">Placeholder Thread Title</h2> <!-- bind when endpoint is implemented -->
            <router-link class="return-link" :to="{ name: 'messages' }">Return to Message Threads</router-link>
            <div v-for="message in this.messages" v-bind:key="message.messageID">
                <message-card v-bind:message="message"/>
            </div> 
      </div>
  </div>
</template>

<script>
import MessageCard from '../components/MessageCard';
import MessageService from '../services/MessageService';
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
        };
    },
    created() {    
        MessageService.GetMessagesForPlayDate(this.$route.params.id).then((response) => {
            this.messages = response.data;
            this.isLoading = false;
        });
        
    }
}
</script>

<style>
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
</style>