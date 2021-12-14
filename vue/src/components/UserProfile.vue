<template>
  <div class="main">
    <div class="user-info">
      <h1>User Profile</h1>
      
      <!--
    <article>
      <h2>First Name: {{ this.user.firstName }}</h2>
      <h2>Last Name: {{ this.user.lastName }}</h2>
      <h2>Zipcode: {{ this.user.zip }}</h2>
      <h2>Email Address: {{ this.user.email }}</h2>
      <br />
    </article>
  -->

      <article>
        <div>
          <h2>My Name</h2>
          <h5>{{ this.user.firstName }} {{ this.user.lastName }}</h5>
        </div>

        <div>
          <h2>My Location</h2>
          <h5>{{ this.user.zip }}</h5>
        </div>

        <div>
          <h2>My Contact</h2>
          <h5>{{ this.user.email }}</h5>
        </div>

        <button id="btnEditProfile" v-on:click="goToEditProfile">Edit My Info</button>

      </article>
    </div>

    <h1>My Playdates</h1>
    <play-date-card
      v-for="playdate in this.playdates"
      v-bind:key="playdate.PlayDateID"
      v-bind:playdate="playdate"
    />
  </div>
</template>

<script>
import UserService from "../services/UserService";
import DateService from "../services/DateService";
import PlayDateCard from "./PlayDateCard.vue";

export default {
  components: { PlayDateCard },
  name: "UserProfile",
  data() {
    return {
      user: {},
      playdates: {},
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
    DateService.GetPlayDatesForUser(this.$store.state.user.userId).then(
      (response) => {
        this.playdates = response.data;
      }
    );
  },
  methods: {
    goToEditProfile() {
      this.$router.push({ name: "register-profile" });
    },
  },
};
</script>

<style>
h1,
h2,
h3 {
  text-align: left;
}

article > div {
  text-align: left;
  background-color: white;
  border-radius: 10px;
  padding: 2px;
  padding-left: 10px;
  margin: 10px;
  border-style:solid;
  border-color:black;
  border-width:1px;
}

article {
  border-width: 1px;
  border-color: black;
  border-style: solid;
  background-color:lightgray;
}

article div:first-child {
  background-color: rgb(250, 128, 114);
}

button {
  margin: 5px;
  background-color: #59d697;
  border: none;
  color: white;
  padding: 10px 25px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 15px;
  border-style:solid;
  border-color:black;
  border-width:1px;
}

h2,
h5 {
  margin: 5px;
}
</style>