import Vue from 'vue'
import Router from 'vue-router'
import Profile from '../views/Profile.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import Home from '@/views/Home.vue'
import NotFound from '@/views/NotFound.vue'
import RegisterProfile from '@/views/RegisterProfile.vue'
import GoogleMap from '@/views/GoogleMapView.vue'
import RegisterPet from '@/views/RegisterPet.vue'
import Messages from '../views/Messages.vue'
import Thread from '../views/Thread.vue'
import ParkInfo from '../views/ParkInfoView'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/map',
      name: 'map',
      component: GoogleMap,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/park',
      name: 'park',
      component: ParkInfo,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/profile",
      name: "profile",
      component: Profile,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "*",
      name: "not-found",
      component: NotFound,
      meta: {
        requiresAuth: false
      }
    },
    {
      path:"/register-profile",
      name: "register-profile",
      component: RegisterProfile,
      meta: {
        requiresAuth: true
      }
    }, 
    {
      path:"/RegisterPet",
      name: "register-pet",
      component: RegisterPet,
    },
    {
      path: "/messages", //Messages view
      name: "messages",
      component: Messages,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/messages/:id", //Thread view
      name: "thread",
      component: Thread,
      meta: {
        requiresAuth: true
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
