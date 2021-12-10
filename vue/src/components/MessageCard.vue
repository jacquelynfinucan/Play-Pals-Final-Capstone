<template>
  <div>
      <div class="message-header">
        <h3>{{message.fromUserId}}</h3>
        <h4>({{message.fromPetId}})</h4>
        <p>{{message.postDate}}</p>
      </div>
      <p>{{message.text}}</p>
  </div>
</template>

<script>
export default {
    name: 'message-card',
    props: ['message']
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
</style>