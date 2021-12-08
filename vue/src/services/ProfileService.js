import axios from 'axios';

export default {
    AddProfile(profile){
        return axios.post('/profile', profile)
    },
    GetProfile(profile){
        return axios.get(`/profile/${profile}`)
    },
    UpdateProfile(profile){
        return axios.put(`/profile`, profile)
    }
}

