<template>
  <div class="profile">
    <user-profile/>
  </div>
</template>

<script>
import UserProfile from '../components/UserProfile.vue';


export default {
  components: { UserProfile },
  name: "profile"
};
</script>
