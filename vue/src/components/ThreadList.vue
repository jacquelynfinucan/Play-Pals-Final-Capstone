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
            <div class="thread" v-for="playDate in playDates" v-bind:key="playDate.playDateId">
                <router-link v-bind:playDate="playDate" v-bind:to="{name: 'thread', params:{id: playDate.playDateId}}">
                    {{playDate.id}} <!-- Title -->
                </router-link>
                <br/>
            </div>
        </div>
  </div>
</template>

<script>
//import DateService from '../services/DateService';
export default {
    name: 'thread-list',
    //get all playdates for user through import or methods when implemented
    data() {
        return {
            isLoading: true,
            errorMsg: '',
            playDates: [ //hard coded temporarily
                {
                    id: 1,
                    fromUserId: 4,
                    fromPetId: 4,
                    toUserId: 3,
                    toPetId: 3,
                    dateTime: "12/21/21"
                },
                {
                    id: 2,
                    fromUserId: 3,
                    fromPetId: 3,
                    toUserId: 4,
                    toPetId: 4,
                    dateTime: "12/25/21"
                }
            ],
        };
    },
    created() {
        //get list of ALL playdates involving this user when implemented, this only gets for from user
        /*
        DateService.GetPlayDatesForUser(this.$store.state.user.userId).then((response) => {
            this.playdates = response.data;
        });
        */
        this.isLoading = false; 
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