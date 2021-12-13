<template>
  <div>
    <!-- <div>
      <h2>Search and add a pin</h2>
      <GmapAutocomplete
        @place_changed='setPlace'
      />
      <button
        @click='addMarker'
      >
        Add
      </button>
    </div> 
    <br>-->
    <br>
    <input type="text" />
    <br>

    <GmapMap
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
  name: 'GoogleMap',
  data() {
    return {
      center: { lat: 45.508, lng: -73.587 },
      currentPlace: null,
      markers: [],
      places: [],
      locations:[],
      icon:{
          url:"../assets/DOGPARK-MAP-MARKER-01.png"
      }
    }
  },
  mounted() {
    this.geolocate();
  },
  methods: {
    markerOnClick(marker){
        this.center=marker.location;
        this.$store.commit('SET_SELECTED_LOCATION',marker);
        this.$router.push('/park');
    },
    setPlace(place) {
      this.currentPlace = place;
    },
    // addMarker() {
    //   if (this.currentPlace) {
    //     const marker = {
    //       lat: this.currentPlace.geometry.location.lat(),
    //       lng: this.currentPlace.geometry.location.lng(),
    //     };
    //     this.markers.push({ position: marker });
    //     this.places.push(this.currentPlace);
    //     this.center = marker;
    //     this.currentPlace = null;
    //   }
    // },
    geolocate: function() {
      navigator.geolocation.getCurrentPosition(position => {
        this.center = {
          lat: position.coords.latitude,
          lng: position.coords.longitude,
        };
      });
    },
  },
  created(){
      PlaceService.GetParksForZip(44106).then((response)=>{
          this.locations = response.data.results;
          this.locations.forEach(element => {
              element.location = {lat:element.geometry[0].location.lat,lng:element.geometry[0].location.lng};
              this.markers.push(element)
          });
      })
  }
};
</script>