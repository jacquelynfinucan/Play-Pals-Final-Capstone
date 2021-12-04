<template>
  <div class="pet-card">
    <img class="pet-img" src="" alt="pet" />
    <h3>{{ pet.name }}</h3>
  </div>
</template>

<script>
export default {
  name: 'pet-card',
  props: ['pet']
};
</script>

<style scoped>
</style>