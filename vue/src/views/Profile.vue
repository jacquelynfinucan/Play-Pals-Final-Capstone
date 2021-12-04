<template>
  <div class="profile">
    <h1>Profile</h1>
    <p>You must be authenticated to see this</p>
    <pet-list />
  </div>
</template>

<script>
import PetList from '@/components/PetList.vue';

export default {
  name: "profile",
  components: {
    PetList
  }
};
</script>
