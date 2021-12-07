<template>
  <div class="profile">
    <user-profile/>
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
