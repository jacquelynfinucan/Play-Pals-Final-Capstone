<template>
  <div>
    <br />
    <form v-on:submit.prevent="registerPlaydate">
      <!-- <div class="status-message error" v-show="errorMsg !== ''">
        {{ errorMsg }}
      </div> -->
      <h1 v-if="!this.isEdit">New Playdate Details:</h1>
      <h1 v-if="this.isEdit">Edit Playdate Details:</h1>
      <div class="form-body">
        <div class="form-inputs">
          <div>
            <label for="play-date-title">Playdate Title: </label>
            <input
              type="text"
              id="play-date-title"
              class="form-control"
              placeHolder="Playdate Title"
              v-model="playdate.title"
              required
            />
          </div>
          <br />
          <div>
            <label for="play-date-address">Playdate Address: </label>
            <input
              type="text"
              id="play-date-address"
              class="form-control"
              placeHolder="Playdate Address"
              v-model="playdate.address"
              required
            />
          </div>
          <br />
          <div>
            <label for="play-date-datetime">Playdate Date and Time: </label>
            <input
              type="datetime-local"
              id="datetime"
              class="form-control"
              v-model="playdate.dateOfPlayDate"
            />
          </div>
          <br />
          <label for="petSelection">Choose your pet for the playdate: </label>
          <select
            v-model="playdate.host_pet_id"
            name="petSelection"
            id="petSelection"
          >
            <option
              v-for="pet in pets"
              :key="pet.petId"
              :value="pet.petId"
              :v-text="pet.petName"
            >
              {{ pet.petName }}
            </option>
            /
          </select>
          <br />
          <br />
          <input class="submit-button" type="submit" />
          <p>
            TIP: Not sure where to host your playdate? Use the interactive map
            to find local parks. Click on a park in the map to get it's address
            and name.
          </p>
        </div>
        <div class="map-section">
          <button id="refresh" v-on:click="refreshClicked">Find Parks</button>
          <GmapMap
            ref="gMap"
            id="mapElement"
            v-on:bounds_changed="center_event"
            :center="center"
            :zoom="16"
          >
            <Gmap-Marker
              :icon="{ url: require('@/assets/DOGPARK-MAP-MARKER-01.png') }"
              :key="index"
              v-for="(marker, index) in markers"
              :position="marker.location"
              @click="markerOnClick(marker)"
            />
          </GmapMap>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import DateService from "../services/DateService";
import petService from "../services/PetService";
import PlaceService from "../services/PlaceService";

export default {
  data() {
    return {
      playdate: {},
      pets: [],
      isEdit: false,
      center: { lat: 45.508, lng: -73.587 },
      trueCenter: {},
      currentPlace: null,
      markers: [],
      places: [],
      locations: [],
      bounds: {},
      icon: {
        url: "../assets/DOGPARK-MAP-MARKER-01.png",
      },
    };
  },
  mounted() {
    this.geolocate();
  },
  methods: {
    registerPlaydate() {
      if (this.isEdit == false) {
        this.playdate.guest_pet_id = this.$store.state.savedPetID;
        DateService.AddPlayDate(this.playdate)
          .then((response) => {
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
      } else {
        //in edit mode
        DateService.updatePlayDate(this.playdate.playDateID, this.playdate)
          .then((response) => {
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
    },
    center_event(event) {
      this.bounds = event;
    },
    refreshClicked() {
      this.updateMarkersToLocation(this.location.lat, this.location.lng);
    },
    updateMarkersToLocation(lat, lng) {
      this.markers = [];
      PlaceService.GetParksForLocation(lat, lng).then((response) => {
        this.locations = response.data.results;
        this.locations.forEach((element) => {
          element.location = {
            lat: element.geometry[0].location.lat,
            lng: element.geometry[0].location.lng,
          };
          this.markers.push(element);
        });
      });
    },
    markerOnClick(marker) {
      this.center = marker.location;
      this.playdate.title = marker.name;
      this.playdate.address = marker.formatted_address;
    },
    setPlace(place) {
      this.currentPlace = place;
    },
    geolocate: function () {
      navigator.geolocation.getCurrentPosition((position) => {
        this.center = {
          lat: position.coords.latitude,
          lng: position.coords.longitude,
        };
        this.updateMarkersToLocation(this.center.lat, this.center.lng);
      });
    },
  },
  created() {
    this.playdate = this.$store.state.currentPlaydate;
    this.playdate.host_user_id = this.$store.state.user.userId;
    petService
      .getPetsForUser(this.$store.state.user.userId)
      .then((response) => {
        this.pets = response.data;
      });
    if (this.playdate.title != "") {
      this.isEdit = true;
    }
  },
  computed: {
    location: function () {
      var thisLat = (this.bounds.zb.g + this.bounds.zb.h) / 2;
      var thisLng = (this.bounds.Qa.g + this.bounds.Qa.h) / 2;
      return {
        lat: thisLat,
        lng: thisLng,
      };
    },
  },
};
</script>

<style scoped>
.form-body {
  border: solid 1px darkgrey;
  border-radius: 5px;
  background-color: white;
  margin-bottom: 10px;
  margin-left: 10px;
  padding: 10px;

  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: "inputs map";
}

div.form-inputs {
  grid-area: inputs;
}

div.map-section {
  grid-area: map;
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
  color: black;
  border-radius: 5px;
}

#refresh {
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
  color: black;
  border-radius: 5px;
}

#mapElement {
  width: 100%;
  height: 500px;
}

#play-date-title {
  width: 300px;
}

#play-date-address {
  width: 300px;
}
</style>