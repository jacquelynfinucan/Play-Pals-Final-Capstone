import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {

  getPetsForUser(userID) {
      return http.get(`/profiles/${userID}/pets`);
  },
  getPetByID(petID){
      return http.get(`/pets/${petID}`);
  }, 
  addPetForUser(userID, pet){
    return http.post(`/profiles/${userID}/pets`, pet)
  }, 
  updateAPet(petId, pet){
    return http.put(`/pets/${petId}`, pet)
  }, 
  deleteAPet(petId){
    return http.delete(`/pets/${petId}`)
  },
  getAllPets(){
    return http.get('/pets')
  },
  getAllPetsNotForUser(userID) {
    return http.get(`/profiles/not/${userID}/pets`)
  }
}
