<template>
  <div>
    <h1>Welcome. Please enter your profile information.</h1>

    <div>
      <lable for="newUser">First Name</lable>
      <input
        type="text"
        id="fistName"
        class="form-control"
        placeHolder="First Name"
        v-model="newUserProfile.firstName"
        required
      />
    </div>

    <div>
      <lable for="newUser">Last Name</lable>
      <input
        type="text"
        id="lastName"
        class="form-control"
        placeHolder="Last Name"
        v-model="newUserProfilelastName"
        required
      />
    </div>

    <div>
      <lable for="newUser">ZIP Code</lable>
      <input
        type="text"
        id="zipCode"
        class="form-control"
        placeHolder="ZIP Code"
        v-model="newUserProfile.zipCode"
        required
      />
    </div>

    <div>
      <lable for="newUser">ZIP Code</lable>
      <input
        type="text"
        id="email"
        class="form-control"
        placeHolder="Email Address"
        v-model="newUserProfile.email"
        required
      />
    </div>

    <button v-on:click="ResgisterProfile">Submit</button>
  </div>
</template>

<script>
import ProfileService from "../services/ProfileService";

export default {
  name: "register-profile",
  data() {
    return {
      newUserProfile: {
        userId: this.$store.state.user.userId,
        firstName: "",
        lastName: "",
        zipCode: "",
        email: "",
      },
    };
  },
  methods: {
    ResgisterProfile(newUserProfile) {
      ProfileService.AddProfile(newUserProfile);
    },
  },
};
</script>

<style>
</style>