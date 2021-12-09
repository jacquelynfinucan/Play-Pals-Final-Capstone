<template>
  <div>
      <div class="loading" v-if="isLoading">
            <img src="@/assets/loading-dog.gif" alt="loading gif"/>
      </div>
      <div v-else>
            <h2>Placeholder Thread Title</h2>
            <router-link class="nav-link" :to="{ name: 'messages' }">Return to Message Threads</router-link>
            <div> <!-- v-for each message in messages -->
                <message-card/> <!-- extra message cards for to visualize what page would look like -->
                <message-card/>
                <message-card/>
                <message-card/>
                <message-card/>
            </div> 
      </div>
  </div>
</template>

<script>
import MessageCard from '../components/MessageCard';
export default {
    name: 'thread-card',
    props: ['thread'],
    components: {
        MessageCard
    },
    data() {
        return {
            isLoading: true,
            errorMsg: '',
        };
    },
    created() {
        this.isLoading = false; //will go into a method later
    }
}
</script>

<style>
.message{
    margin: 10px;
    background-color: gray;
}
</style>