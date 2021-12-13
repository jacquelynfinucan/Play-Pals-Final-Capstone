<template>
  <div class="main">
    <h1>User Profile</h1>
    <button id="btnEditProfile" v-on:click="goToEditProfile">Edit Profile</button>
    <h2>First Name: {{ this.user.firstName }}</h2>
    <h2>Last Name: {{ this.user.lastName }}</h2>
    <h2>Zipcode: {{ this.user.zip }}</h2>
    <h2>Email Address: {{ this.user.email }}</h2>
    <br />
  </div>
</template>

<script>
import UserService from "../services/UserService";

export default {
  components: { },
  name: "UserProfile",
  data() {
    return {
      user: {},
    };
  },
  computed: {
    aUser() {
      return this.$store.state.user;
    },
  },
  created() {
    UserService.GetUserByID(this.$store.state.user.userId).then((response) => {
      if (response.data.userId == 0) {
        this.$store.commit("SET_PROFILE", {       
            userId: "",
            firstName: "",
            lastName: "",
            zip: "",
            email: "",
            });
        
        this.$router.push({ name: "register-profile" }); //should kick you to RegisterProfile view if profile doesn't exist

      } else {
        this.$store.commit("SET_PROFILE", response.data);   
        this.user = response.data;
      }
    });
    
  },
  methods: {
      goToEditProfile() {
          this.$router.push({name: 'register-profile'});
      }
  }
};
</script>

<style>
h1,
h2,
h3 {
  text-align: left;
}
</style>