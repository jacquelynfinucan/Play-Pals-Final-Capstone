import axios from 'axios';

export default {
    AddMessage(message) {
        return axios.post('/messages', message)
    },
    UpdateMessage(messageID, message) {
        return axios.put(`/messages/${messageID}`, message)
    },
    DeleteMessage(messageID) {
        return axios.delete(`/messages/${messageID}`)
    },
    GetMessage(messageID) {
        return axios.get(`/messages/${messageID}`)
    },
    GetMessagesForPlayDate(playDateID) {
        return axios.get(`/playdates/${playDateID}/messages`)
    }
}
