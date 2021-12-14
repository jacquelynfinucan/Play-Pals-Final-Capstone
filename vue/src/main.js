import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import * as VueGoogleMaps from 'vue2-google-maps'
import axios from 'axios'


Vue.config.productionTip = false

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyBCEUQy7Ko99B-a-IVKJbxWkKkiqBtkjik',
  }
});

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
