import axios from 'axios';

export default {
    GetParksForZip(zipCode){
        return axios.get(`/parks/${zipCode}`);
    },
    GetParksForLocation(lat,lng){
        return axios.get(`/parks/${lat}/${lng}`)
    }
}
