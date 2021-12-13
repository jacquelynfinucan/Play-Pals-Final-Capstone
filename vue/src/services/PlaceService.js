import axios from 'axios';

export default {
    GetParksForZip(zipCode){
        return axios.get(`/parks/${zipCode}`);
    }
}
