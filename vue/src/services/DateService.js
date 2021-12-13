import axios from 'axios';

export default {
    AddPlayDates(playdate){
        return axios.post('/playdates',playdate)
    },
    GetPlayDatesForUser(userID){
        return axios.get(`/playdates/user/${userID}`)
    },
    GetPlayDatesForLocation(locationId){
        return axios.get(`playdates/place/${locationId}"`)
    },
    getPlayDateThreadsForUser(userID) {
        return axios.get(`/threads/${userID}`)
    }
}
