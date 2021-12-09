<template>
  <div class="profile">
    <user-profile/>
    <router-link class="nav-link" :to="{ name: 'messages' }">Messages</router-link>
    <pet-list />
  </div>
</template>

<script>
import UserProfile from '../components/UserProfile.vue';
import PetList from '@/components/PetList.vue'


export default {
  components: { 
    UserProfile, 
    PetList 
  },
  name: "profile"
};
</script>
