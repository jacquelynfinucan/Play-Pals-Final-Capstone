import axios from 'axios';

export default {
    AddPlayDate(playDate){
        return axios.post('/playdates', playDate)
    },
    GetAllPlayDatesForUser(userID){
        return axios.get(`/playdates/user/${userID}`)
    },
    GetPlayDatesForLocation(locationId){
        return axios.get(`/playdates/place/${locationId}"`)
    },
    getPlayDateThreadsForUser(userID) {
        return axios.get(`/threads/${userID}`);
    },
    GetPlayDatesForUserByStatus(userID, statusID){
        return axios.get(`/playdates/users/${userID}/status/${statusID}`)
    },
    getPlayDateThreadForPlayDateID(playDateID) {
        return axios.get(`/playdates/${playDateID}/threads`);
    }, 
    updatePlayDateStatus(playDateID, statusID) {
        return axios.put(`/playdates/${playDateID}/status/${statusID}`)
    }
}
