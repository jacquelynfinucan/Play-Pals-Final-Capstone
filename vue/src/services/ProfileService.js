import axios from 'axios';

export default {
    AddProfile(profile){
        return axios.post('/profile', profile)
    }
}

