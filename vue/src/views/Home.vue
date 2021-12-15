<template>
  <div class="home">
    <home-welcome />
    <!-- <image-slideshow/> -->
    <home-news />   
  </div>
</template>

<script>
import HomeWelcome from '@/components/HomeWelcome.vue';
import HomeNews from '@/components/HomeNews.vue';
// import ImageSlideshow from '../components/ImageSlideshow.vue';


export default {
  name: "home",
  components: {
    HomeWelcome,
    // ImageSlideshow,
    HomeNews
  }
};
</script>

<style scoped>

</style>