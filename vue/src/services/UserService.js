import axios from 'axios';

export default {
    GetUserByID(id){
        return axios.get(`/profiles/${id}`)
    }
}
