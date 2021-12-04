<template>
  <div class="home">
    <home-welcome />
    <home-news />   
  </div>
</template>

<script>
import HomeWelcome from '@/components/HomeWelcome.vue'
import HomeNews from '@/components/HomeNews.vue'


export default {
  name: "home",
  components: {
    HomeWelcome,
    HomeNews
  }
};
</script>

<style scoped>

</style>