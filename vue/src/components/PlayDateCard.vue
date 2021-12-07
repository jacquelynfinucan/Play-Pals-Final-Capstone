<template>
   <div>
<!-- <UserCard/> -->
    <!-- <pet-card id="Host_Pet"/> -->
    <!-- <pet-card id="Guest_Pet"/>  -->

   </div>
</template>

<script>
// import PetCard from './PetCard.vue'
import PetService from '../services/PetService'
// import UserService from '../services/UserService'
export default {
//   components: { PetCard },
    name: 'PlayDateCard',
    data(){
        return{
            GuestPet : {},
            HostPet :{},
            HostProfile:{}
        }
    },
    // computed:{
    //     PlayDate: function(){
    //         return this.$props.playdate;
    //     }
    // },
    props: ['playdate'],
    watch:{
        playdate: function () {
        
        }
    }
    ,



    created(){
        PetService.getPetByID(this.playdate.GuestPetID).then((response)=>{
            this.GuestPet = response.data;
        })
        //    PetService.getPetByID(this.playdate.HostPetID).then((response)=>{
        //     this.HostPet = response.data;
        // }),
        // UserService.GetUserByID(this.playdate.HostUserID).then((response)=>{
        //     this.HostProfile = response.data;
        // })
    }
}
</script>

<style>

</style>