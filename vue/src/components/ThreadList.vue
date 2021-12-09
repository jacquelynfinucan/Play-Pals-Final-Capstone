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
            <div class="thread" ><!-- v-for each playdate for user -->
                <router-link class="nav-link" :to="{ name: 'thread' }">Placeholder PlayDate Thread Title 1</router-link> <!-- fill with specific playdate info later-->
                <br/>
                <router-link class="nav-link" :to="{ name: 'thread' }">Placeholder PlayDate Thread Title 2</router-link> <!-- added extra placeholder thread links to show what page would look like -->
                <br/>
                <router-link class="nav-link" :to="{ name: 'thread' }">Placeholder PlayDate Thread Title 3</router-link>
                <br/>
                <router-link class="nav-link" :to="{ name: 'thread' }">Placeholder PlayDate Thread Title 4</router-link>
                <br/>
                <router-link class="nav-link" :to="{ name: 'thread' }">Placeholder PlayDate Thread Title 5</router-link>
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