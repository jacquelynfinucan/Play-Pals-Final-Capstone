<template>
  <div class="message-outer-box" :class="sender ? 'sent-message-box' : 'received-message-box'">
    <div class="message-box" :class="sender ? 'sent-message' : 'received-message'">
      <div class="message-header">
        <h3>{{message.fromUsername}}</h3>
        <h4>({{message.fromPetName}})</h4>
        <p>{{message.postDate}}</p>
      </div>
      <div class="sent-body" v-if="sender">
        <p class="message-text">{{message.messageText}}</p>
        <img class="pet-img" src="https://randomuser.me/api/portraits/lego/1.jpg" alt="pet picture" /> <!-- replace with user/pet image -->
      </div>
      <div class="received-body" v-if="!sender">
        <img class="pet-img" src="https://randomuser.me/api/portraits/lego/1.jpg" alt="pet picture" /> <!-- replace with user/pet image -->
        <p class="message-text">{{message.messageText}}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
    name: 'message-card',
    props: ['message'],
    data() {
      return {
        sender: false, //used to format messages
      };
    },
    created() {
      let id = this.$store.state.user.userId
      let fromId = this.message.fromUserID
      if( id == fromId){
        this.sender = true;
      }
    },
}
</script>

<style>
/* General */
.message-header{
  display: flex;
  align-items: baseline;
}
.message-header h3{
  font-size: 30px;
}
.message-header p{
  font-size: 12px;
  font-style: italic;
  margin-left: 5px;
}
.message-outer-box{
  display: flex;
}
.message-box{
  width: 60vw;
  display: flex;
  flex-direction: column;
  border: 2px solid black;
  border-radius: 25px;
}
.pet-img{
  max-width: 10%;
  border: 2px solid black;
  border-radius: 25px;
}
.message-text{
  font-size: 18px;
}
/* Sent Messages */
.sent-message{
  background-color: lawngreen;
}
.sent-message .message-header{
  padding-left: 5%;
}
.sent-message .message-text{
  padding-left: 15%;
  margin-right: 5%;
}
.sent-body{
  display: flex;
  justify-content: space-between;
  align-items: top;
}
.sent-body .pet-img{
  margin-right: 2%;
  margin-top: 0%;
  margin-bottom: 1%;
}
/* Received Messages */
.received-message{
  background-color: hotpink;
}
.received-message-box{
  display: flex;
  justify-content: flex-end;
  margin: 5px;
}
.received-message .message-header{
  justify-content: right;
  padding-right: 5%;
}
.received-message .message-text{
  display: flex;
  justify-content: right;
  padding-right: 15%;
  padding-left: 5%;
}
.received-body{
  display: flex;
  justify-content: space-between;
  align-items: top;
}
.received-body .pet-img{
  margin-left: 2%;
  margin-top: 0%;
  margin-bottom: 1%;
}
</style>