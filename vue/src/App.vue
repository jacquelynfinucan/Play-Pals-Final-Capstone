<template>
  <div id="app">
    <header-top />
    <router-view id="router" />
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
@import url('./UniversalStyles.css');
#router{
  margin-top:160px;
  padding-top: 0px;
  padding-bottom: 0px;
}
.nav-link:hover {
  color: red;
}
</style>
