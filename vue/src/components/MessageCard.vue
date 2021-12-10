<template>
  <div class="message-outer-box">
    <div class="message-box" :class="sender ? 'sent-message' : 'received-message'">
      <div class="message-header">
        <h3>{{message.fromUsername}}</h3>
        <h4>({{message.fromPetName}})</h4>
        <p>{{message.postDate}}</p>
      </div>
      <p>{{message.messageText}}</p>
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
.message-header{
  display: flex;
  align-items: baseline;
}
.message-header p{
  font-size: 12px;
  font-style: italic;
  margin-left: 5px; /* may mess with background formatting later */
}
.message-outer-box{
  display: flex;
  width: 100vw;
}
.message-box{
  width: 60vw;
}
.sent-message{
  background-color: lawngreen;
}
.received-message{
  background-color: hotpink;
}
</style>