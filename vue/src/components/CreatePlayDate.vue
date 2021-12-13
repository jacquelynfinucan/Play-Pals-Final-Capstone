<template>
  <div>
      <br>
   <form v-on:submit.prevent="registerPlaydate">
      <!-- <div class="status-message error" v-show="errorMsg !== ''">
        {{ errorMsg }}
      </div> -->
      
      <div>
        <label for="play-date-title">Play Date Title:</label>
        <input
          type="text"
          id="play-date-title"
          class="form-control"
          placeHolder="Playdate"
          v-model="newPlaydate.title"
          required
        />
      </div>

        <br>

      <div>
        <label for="play-date-address">Play Date Address:</label>
        <input
          type="text"
          id="play-date-address"
          class="form-control"
          placeHolder="Playdate"
          v-model="newPlaydate.address"
          required
        />
      </div>

      <br>


      <input type="datetime-local" id="datetime" class="form-control" v-model="newPlaydate.DateOfPlayDate">

      <br>
      <br>
        <label for="petSelection">Choose a pet:</label>
        <select v-model="newPlaydate.host_pet_id" name="petSelection" id="petSelection">
          <option  v-for="pet in pets" :key="pet.petId" :value="pet.petId" :v-text="pet.petName">{{pet.petName}}</option>/
        </select>
      <br>
      <br>
      <input type="submit" />
      <br>

    </form>


  </div>
</template>

<script>
import DateService from '../services/DateService'
import petService from '../services/PetService'
export default {
    data(){
        return{
            newPlaydate:{},
            pets:[]
        }
    },
    methods:{
        addAPlayDate(playdate){
            DateService.AddPlayDate(playdate);
        }
    },
        created(){
        this.newPlaydate.host_user_id = this.$store.state.user.userId;
         petService.getPetsForUser(this.$store.state.user.userId).then( (response) => {
            this.pets = response.data;
        })
    }
}
</script>

<style>

</style>