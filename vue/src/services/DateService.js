import axios from 'axios';

export default {
    GetPlayDatesForUser(userID){
        return axios.get(`/playdates/user/${userID}`)
    },

    getPlayDateThreadsForUser(userID) {
        return axios.get(`/threads/${userID}`);
    },

    getPlayDateThreadForPlayDateID(playDateID) {
        return axios.get(`/playdates/${playDateID}/threads`);
    }
}
