<template>
  <div id="app">
    <header-top />
    <router-view />
    <footer-bottom />
  </div>
</template>

<script>
import HeaderTop from '@/components/HeaderTop.vue';
import FooterBottom from '@/components/FooterBottom.vue';

export default {
  components: {
    HeaderTop,
    FooterBottom
  }
};
</script>

<style>
body {
  background-color: whitesmoke;
}
</style>
