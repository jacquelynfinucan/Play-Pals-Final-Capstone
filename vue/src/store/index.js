import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(!currentToken) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    pets: [],
    currentPet: {
      petName: "",
      animalType: "",
      breed: "",
      age: "",
      size: "",
      isMale: null,
      isSpayed: null,
      description: "",
      personalityTraits: [],
    },
    profile: {       
      userId: "",
      firstName: "",
      lastName: "",
      zip: "",
      email: "",
    },
    selectedLocation: {},
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {

      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      state.pets = [];
      state.currentPet = {
        petName: "",
        animalType: "",
        breed: "",
        age: "",
        size: "",
        isMale: null,
        isSpayed: null,
        description: "",
        personalityTraits: [],
      };
      state.profile = {       
        userId: "",
        firstName: "",
        lastName: "",
        zip: "",
        email: "",
      };
      axios.defaults.headers.common = {};
    },
    SET_PETS(state, pets) {
      state.pets = pets;
    },
    SET_CURRENT_PET(state, pet){
      state.currentPet = pet;
    },
    ADD_PET(state, pet) {
      state.pet = pet;
      state.pets.push(pet);
    },
    SET_PROFILE(state, profile) {
      state.profile = profile;
    },
    SET_SELECTED_LOCATION(state,location){
      state.selectedLocation = location;
    }, 
    REMOVE_CURRENT_PET(state){
      state.currentPet = {
        petName: "",
        animalType: "",
        breed: "",
        age: "",
        size: "",
        isMale: null,
        isSpayed: null,
        description: "",
        personalityTraits: [],
      };
    }
  }
})
