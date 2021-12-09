<template>
  <div>
      <div class="message-header">
        <h3>Message Sender</h3>
        <p>post time</p>
      </div>
      <p>Placeholder Message Text</p>
  </div>
</template>

<script>
export default {
    name: 'message'
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