<template>
  <div>
    <h1>Welcome. Please enter your profile information.</h1>

    <div>
      <div class="status-message error" v-show="errorMsg !== ''">{{errorMsg}}</div>

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
        v-model.number="newUserProfile.zip"
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

    <button v-on:click="RegisterProfile">Submit</button>
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
      errorMsg: ''
    };
  },
  methods: {
    RegisterProfile() {
      ProfileService.AddProfile(this.newUserProfile)
        .then((response) => {
          if (response.status == 200) {
            this.$router.push({ name: "profile" });
          }
        })
        .catch((error) => {
          if (error.response) {
            this.errorMsg =
              "Error creating profile. Response received was '" +
              error.response.statusText +
              "'.";
          } else if (error.request) {
            this.errorMsg =
              "Error creating profile. Server could not be reached.";
          } else {
            this.errorMsg =
              "Error rcreating profile. Request could not be created.";
          }
        });
    },
  },
};
</script>

<style scoped>
.status-message.error {
    color: red;
}
</style>