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
            v-model="this.$store.state.user.firstName"
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
            v-model="this.$store.state.user.lastName"
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
            v-model="this.$store.state.user.zipCode"
            required
          />
        </div>


  </div>
</template>

<script>
export default {};
</script>

<style>
</style>