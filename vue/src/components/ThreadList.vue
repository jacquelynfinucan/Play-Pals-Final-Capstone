<template>
  <div>
        <div class="loading" v-if="isLoading">
            <img src="@/assets/loading-dog.gif" alt="loading gif"/>
        </div>

        <div v-else> 
            <h1>Your Message Threads</h1>
            <div class="filters">
                <input type="text" id="userFilter" placeHolder="User"/>
                <input type="text" id="petFilter" placeHolder="Pet"/>
            </div>
            <br/>
            <div class="thread" v-for="playDate in this.playDates" v-bind:key="playDate.play_date_id">
                <router-link v-bind:playDate="playDate" v-bind:to="{route: 'messages/:id', params:{id: playDate.playDateID}}">
                    PlaceHolder <!-- Title -->
                </router-link>
                <br/>
            </div>
        </div>
  </div>
</template>

<script>
import DateService from '../services/DateService';
export default {
    name: 'thread-list',
    data() {
        return {
            isLoading: true,
            errorMsg: '',
            playDates: [], 
        }
    },
    created() { 
        DateService.GetPlayDatesForUser(this.$store.state.profile.userId).then((response) => {
            this.playdates = response.data;
            this.isLoading = false;
        }); 
    },
    methods: { /*
        CreateThreadTitle(playDate){//wip, use to make nice title line for thread
            let fromUserName = '';
            let fromPetName = '';
            let toUserName = '';
            let toPetName = '';
            UserService.GetUserByID(playDate.fromUserId).then((response) => {
                this.fromUserName = response.firstName;
            });
            PetService.GetPetById(playDate.fromPetId).then((response) => {
                this.fromPetName = response.lastName;
            });
            
        } */
    }   
}
</script>

<style>

</style>