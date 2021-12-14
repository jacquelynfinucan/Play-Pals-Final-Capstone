<template>
  <div>
      <br>
   <form v-on:submit.prevent="registerPlaydate">
      <!-- <div class="status-message error" v-show="errorMsg !== ''">
        {{ errorMsg }}
      </div> -->
      <h1 v-if="!this.isEdit">New Playdate Details:</h1>
      <h1 v-if="this.isEdit">Edit Playdate Details:</h1>
      <div class="form-body">
      <div>
        <label for="play-date-title">Playdate Title: </label>
        <input
          type="text"
          id="play-date-title"
          class="form-control"
          placeHolder="Playdate"
          v-model="playdate.title"
          required
        />
      </div>
        <br>
      <div>
        <label for="play-date-address">Playdate Address: </label>
        <input
          type="text"
          id="play-date-address"
          class="form-control"
          placeHolder="Playdate"
          v-model="playdate.address"
          required
        />
      </div>
      <br>
      <div>
      <label for="play-date-datetime">Playdate Date and Time: </label>
      <input type="datetime-local" id="datetime" class="form-control" v-model="playdate.dateOfPlayDate">
      </div>
      <br>
        <label for="petSelection">Choose your pet for the playdate: </label>
        <select v-model="playdate.host_pet_id" name="petSelection" id="petSelection">
          <option  v-for="pet in pets" :key="pet.petId" :value="pet.petId" :v-text="pet.petName">{{pet.petName}}</option>/
        </select>
      <br>
      <br>
      <input class="submit-button" type="submit" />
      </div>
    </form>


  </div>
</template>

<script>
import DateService from '../services/DateService'
import petService from '../services/PetService'

export default {
    data(){
        return{
          playdate:{},
          pets:[], 
          isEdit: false,
        }
    },
    methods:{
      registerPlaydate(){
        if(this.isEdit == false){
          this.playdate.guest_pet_id = this.$store.state.savedPetID;
        DateService.AddPlayDate(this.playdate).then((response) => {
            if (response.status == 200) {
                this.$router.push({ name: "playdate-list" });
            }
          })
          .catch((error) => {
            if (error.response) {
              this.errorMsg =
                "Error creating playdate. Response received was " +
                error.response.statusText +
                ".";
            } else if (error.request) {
              this.errorMsg =
                "Error creating playdate. Server could not be reached.";
            } else {
              this.errorMsg =
                "Error creating playdate. Request could not be created.";
            }
          });
        }
        else{ //in edit mode
          DateService.updatePlayDate(this.playdate.playDateID, this.playdate).then((response) => {
            if (response.status == 200) {
                this.$router.push({ name: "playdate-list" });
            }
          })
          .catch((error) => {
            if (error.response) {
              this.errorMsg =
                "Error updating playdate. Response received was " +
                error.response.statusText +
                ".";
            } else if (error.request) {
              this.errorMsg =
                "Error updating playdate. Server could not be reached.";
            } else {
              this.errorMsg =
                "Error updating playdate. Request could not be created.";
            }
          });
        }
      }
    },
    created(){
      this.playdate = this.$store.state.currentPlaydate;
      this.playdate.host_user_id = this.$store.state.user.userId;
      petService.getPetsForUser(this.$store.state.user.userId).then( (response) => {
        this.pets = response.data;
      })
      if(this.playdate.title != ""){
        this.isEdit = true;
      }
    }
}
</script>

<style scoped>
.form-body{
  border: solid 1px darkgrey;
  border-radius: 5px;
  background-color: white;
  margin-bottom: 10px;
  margin-left: 10px;
  padding:10px;
}

.submit-button {
  margin: 5px;
  background-color: var(--tertiary-color);
  border: none;
  color: white;
  padding: 10px 25px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 15px;
  border-style: solid;
  border-color: black;
  border-width: 1px;
  color:black;
  border-radius:5px;
}
</style>