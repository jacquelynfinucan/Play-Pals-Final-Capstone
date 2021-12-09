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
            <div class="thread" ><!-- v-for each playdate for user -->
                <router-link class="nav-link" :to="{ name: 'thread' }">Placeholder PlayDate Thread Title</router-link> <!-- fill with specific playdate info late-->
            </div>
        </div>
  </div>
</template>

<script>

export default {
    name: 'thread-list',
    //get all playdates for user through import or methods when implemented
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

</style>