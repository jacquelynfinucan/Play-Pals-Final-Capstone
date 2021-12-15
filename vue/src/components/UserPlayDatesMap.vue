<template>
    <div>
        <img id="refresh" src='@/assets/refresh.png' v-on:click="refreshClicked" title="Image from freepik">
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
                :position="marker.location"
                @click="markerOnClick(marker)"
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
        document.querySelector('#listener').addEventListener('center_changed', function(a) { this.bounds = a })

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
            this.updateMarkersToLocation(this.location.lat,this.location.lng);
        },
        updateMarkersToLocation(lat,lng){
            this.markers = [];
            PlaceService.GetParksForLocation(lat,lng).then((response)=>{ //need endpoint to get all playadate markers for user here instead of all parks
                this.locations = response.data.results;
                this.locations.forEach(element => {
                    element.location = {lat:element.geometry[0].location.lat,lng:element.geometry[0].location.lng};
                    this.markers.push(element)
                });
            })
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
                this.updateMarkersToLocation(this.center.lat,this.center.lng);
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