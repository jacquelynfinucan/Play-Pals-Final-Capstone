<template>
  <div>
    <h1>Welcome. Please enter your profile information.</h1>

    <div>
      <label for="newUser">First Name</label>
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
      <label for="newUser">Last Name</label>
      <input
        type="text"
        id="lastName"
        class="form-control"
        placeHolder="Last Name"
        v-model="newUserProfile.lastName"
        required
      />
    </div>

    <div>
      <label for="newUser">ZIP Code</label>
      <input
        type="text"
        id="zipCode"
        class="form-control"
        placeHolder="ZIP Code"
        v-model="newUserProfile.zip"
        required
      />
    </div>

    <div>
      <label for="newUser">Email Address</label>
      <input
        type="text"
        id="emailAddress"
        class="form-control"
        placeHolder="Email Address"
        v-model="newUserProfile.email"
        required
      />
    </div>

    <button v-on:click="RegisterProfile(this.newUserProfile)">Submit</button>
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
        zip: "",
        email: "",
      },
      registrationErrors: false,
      registrationErrorMsg: "",
    };
  },
  methods: {
    RegisterProfile(newUserProfile) {
      ProfileService.AddProfile(newUserProfile)
        .then((response) => {
          if (response.status == 201) {
            this.$router.push({
              path: "/profile",
              query: { registration: "success" },
            });
          }
        })
        .catch((error) => {
          const response = error.response;
          this.registrationErrors = true;
          if (response.status === 400) {
            this.registrationErrorMsg = "Bad Request: Validation Errors";
          }
        });
    },
  },
};
</script>

<style>
</style>