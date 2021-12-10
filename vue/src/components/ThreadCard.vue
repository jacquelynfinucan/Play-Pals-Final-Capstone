<template>
  <div>
      <div class="loading" v-if="isLoading">
            <img src="@/assets/loading-dog.gif" alt="loading gif"/>
      </div>
      <div v-else>
            <h2>Placeholder Thread Title</h2>
            <router-link class="nav-link" :to="{ name: 'messages' }">Return to Message Threads</router-link>
            <div v-for="message in messages" v-bind:key="message.id">
                <message-card v-bind:message="message"/>
            </div> 
      </div>
  </div>
</template>

<script>
import MessageCard from '../components/MessageCard';
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
        //get messages for this thread(playDateId) once implemented
        this.messages = [ //hardcoded
                {
                    id: 1,
                    fromUserId: 4,
                    fromPetId: 4,
                    postDate: '2021-12-09 12:42:44.877',
                    text: 'wazzzzzuupppppp'
                },
                {
                    id: 2,
                    fromUserId: 3,
                    fromPetId: 3,
                    postDate: '2021-12-09 12:44:44.877',
                    text: 'wazzzzzuupppppp'
                },
                {
                    id: 3,
                    fromUserId: 4,
                    fromPetId: 4,
                    postDate: '2021-12-09 12:46:44.877',
                    text: 'wazzzzzuupppppp'
                },
                {
                    id: 4,
                    fromUserId: 3,
                    fromPetId: 3,
                    postDate: '2021-12-09 12:48:44.877',
                    text: 'wazzzzzuupppppp'
                },
            ]
        this.isLoading = false;
    }
}
</script>

<style>
.message{
    margin: 10px;
    background-color: gray;
}
</style>