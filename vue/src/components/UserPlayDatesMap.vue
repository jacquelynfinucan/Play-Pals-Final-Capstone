<template>
    <div>
        <!-- <img id="refresh" src='@/assets/refresh.png' v-on:click="refreshClicked" title="Image from freepik"> -->
        <GmapMap
            ref="gMap"

            v-on:bounds_changed="center_event"

            :center='center'
            :zoom='16'
            style='width:100%;  height: 700px;'
    >
            <Gmap-Marker
                :icon="{ url: require('@/assets/DOGPARK-MAP-MARKER-01.png')}"
                :key="index"
                v-for="(marker, index) in markers"
                @click="markerOnClick(marker)"
                :position="marker.location"
                />
            
        </GmapMap>
    </div>
</template>

<script>
import PlaceService from '../services/PlaceService'
export default {
    name: 'user-play-dates-map',
    data() {
        return {
            center: { lat: 41.505, lng: -81.681 },
            trueCenter:{},
            currentPlace: null,
            markers: [],
            places: [],
            locations:[],
            bounds:{},
            icon:{
                url:"../assets/DOGPARK-MAP-MARKER-01.png"
            }
        }
    },
    mounted() { 
        this.geolocate();
    },
    computed:{
        location: function(){
            var thisLat = (this.bounds.zb.g + this.bounds.zb.h)/2;
            var thisLng = (this.bounds.Qa.g + this.bounds.Qa.h)/2;
            return {
                lat:thisLat,
                lng:thisLng
            }
        }
    },
    methods: {
        center_event(event){
            this.bounds = event;
        },
        refreshClicked(){
            this.updateMarkersToLocation(this.$store.state.user.userId); //changed to take userId
        },
        updateMarkersToLocation(userID){ //changed this method to call the locations for user endpoint
            this.markers = [];
            PlaceService.GetLocationsForUser(userID).then((response)=>{
               this.locations = response.data;
                this.locations.forEach(element => {
                  element.location={
                                lat: element.lat,
                                lng: element.lng
                            }
                    this.markers.push(element)
                });
            })
        },
        markerOnClick(marker){
            this.center=marker.location;
            // this.$store.commit('SET_SELECTED_LOCATION',marker);
            // this.$router.push('/park');
        },
        setPlace(place) {
            this.currentPlace = place;
        },
        geolocate: function() {
            navigator.geolocation.getCurrentPosition(position => {
                this.center = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude,
                };
                this.updateMarkersToLocation(this.$store.state.user.userId); //changed to take userId
            });
        },
    }
}
</script>

<style scoped>
    #refresh{
        background-color:white;
        border: black solid 4px;
        border-radius:50%;
        position:fixed;
        height:60px;
        z-index: 3;
        left: 210px;
    }
</style>