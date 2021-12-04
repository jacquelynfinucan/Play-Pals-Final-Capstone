<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      
      <div class="input-controls">
        
        <div class="username-control">
          <label for="username" class="sr-only">Username</label>
          <input
            type="text"
            id="username"
            class="form-control"
            placeholder="Username"
            v-model="user.username"
            required
            autofocus
          />
        </div>
        
        <div class="password-control">
          <label for="password" class="sr-only">Password</label>
          <input
            type="password"
            id="password"
            class="form-control"
            placeholder="Password"
            v-model="user.password"
            required
          />
        </div>
        
        <router-link class="nav-link" :to="{ name: 'register' }">Need an account?</router-link>
        <button id="submit" type="submit">Sign in</button>
        
      </div>

    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push({name: 'profile'});
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>


<style scoped>
#login {
  margin-bottom: 10px;
}

.input-controls {
  border: solid 1px black;
  border-radius: 5px;
  padding: 10px;
}

.username-control {
  padding-bottom: 10px;
}

.password-control {
  padding-bottom: 10px;
}

#username {
  margin-left: 10px;
}

#password {
  margin-left: 10px;
}

#submit {
  margin-left: 10px;
}
</style>