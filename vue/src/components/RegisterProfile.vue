<template>
  <div>
    <h1 v-if="!this.isEdit">Welcome. Please enter your profile information.</h1>
    <h1 v-if="this.isEdit">Update your profile information.</h1>

    <form v-on:submit.prevent="registerProfile">
      <div class="status-message error" v-show="errorMsg !== ''">
        {{ errorMsg }}
      </div>
      
      <div>
        <label for="fistName">First Name: </label>
        <input
          type="text"
          id="fistName"
          class="form-control"
          placeHolder="First Name"
          v-model="profile.firstName"
          required
        />
      </div>

      <div>
        <label for="lastName">Last Name: </label>
        <input
          type="text"
          id="lastName"
          class="form-control"
          placeHolder="Last Name"
          v-model="profile.lastName"
          required
        />
      </div>

      <div>
        <label for="zipCode">ZIP Code: </label>
        <input
          type="number"
          id="zipCode"
          class="form-control"
          placeHolder="ZIP Code"
          v-model.number="profile.zip"
          required
        />
      </div>

      <div>
        <label for="emailAddress">Email Address: </label>
        <input
          type="email"
          id="emailAddress"
          class="form-control"
          placeHolder="Email Address"
          pattern=".+@.+\.com"
          v-model="profile.email"
          required
        />
      </div>
      <input type="submit" />
    </form>
  </div>
</template>

<script>
import profileService from "../services/ProfileService";

export default {
  name: "register-profile",
  data() {
    return {
      profile: {},
      errorMsg: "",
      isEdit: false,
    };
  },
  methods: {
    registerProfile() {
      if (this.isEdit == false) {
        profileService
          .AddProfile(this.profile)
          .then((response) => {
            if (response.status == 200) {
              this.$router.push({ name: "register-pet" });
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
                "Error creating profile. Request could not be created.";
            }
          });
      } else {
        profileService
          .UpdateProfile(this.profile)
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
                "Error creating profile. Request could not be created.";
            }
          });
      }
    }
  },
  created() {
    this.profile = this.$store.state.profile;

    if (this.profile.userId == "") {
      this.profile.userId = this.$store.state.user.userId;
    } else {
      this.isEdit = true;
    }
  },
};
</script>

<style scoped>
.status-message.error {
  color: red;
}

form{
  margin:5px;
}

div{
  margin:5px;
}

</style>