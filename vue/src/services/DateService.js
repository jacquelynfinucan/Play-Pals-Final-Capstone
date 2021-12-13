import axios from 'axios';

export default {
    AddPlayDates(playDate){
        return axios.post('/playdates', playDate)
    },
    GetPlayDatesForUser(userID){
        return axios.get(`/playdates/user/${userID}`)
    },
    GetPlayDatesForLocation(locationId){
        return axios.get(`playdates/place/${locationId}"`)
    },
    getPlayDateThreadsForUser(userID) {
        return axios.get(`/threads/${userID}`);
    },

    getPlayDateThreadForPlayDateID(playDateID) {
        return axios.get(`/playdates/${playDateID}/threads`);
    }
}
