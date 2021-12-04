import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:44315"
});

export default {

  getPets() {
    return http.get('/pets');
  },
  getPet(petID) {
      return http.get(`/pets/${petID}`);
  },
  getPetsForUser(userID) {
      return http.get(`/profiles/${userID}/pets`);
  }
}
