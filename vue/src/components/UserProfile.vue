<template>
  <div class="main">
    <h1>User Profile</h1>

    <article id="profile">
      <div>
        <h2 class="field-title">My Name</h2>
        <h5 class="field-info">{{ this.user.firstName }} {{ this.user.lastName }}</h5>
      </div>

      <div>
        <h2 class="field-title">My Location</h2>
        <h5 class="field-info">{{ this.user.zip }}</h5>
      </div>

      <div>
        <h2 class="field-title">My Contact</h2>
        <h5 class="field-info">{{ this.user.email }}</h5>
      </div>

      <button id="btnEditProfile" v-on:click="goToEditProfile">
        Edit My Info
      </button>
    </article>

    <br />
  </div>
</template>

<script>
import UserService from "../services/UserService";

export default {
  components: {},
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
  border-style: solid;
  border-color: black;
  border-width: 1px;
}

#profile {
  border-width: 1px;
  border-color: darkgray;
  border-style: solid;
  background-color: var(--secondary-color);
  margin-top:-21px;
  border-radius:5px;
}

article div:first-child {
  background-color: var(--tertiary-color);
}

.field-info, .field-title{
  margin:5px;
}

.main{
  margin-top:10px;
}

</style>