<template>
<div></div>
</template>
<script>
import Vue from 'vue'
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

export default {
  data() {
    return {
      connection: null
    }
  },
  created() {
    console.log("ws created.")
    this.connection = new HubConnectionBuilder()
    .withUrl('http://localhost:3417/EmotionHub')
    .configureLogging(LogLevel.Information)
    .build()

    this.connection.start()
              .catch(function(err) {
                return console.error(err.toSting())
              })
  },
  mounted() {
    this.connection.on("ReceiveEmotion", (emotion) => {
      this.$emit('ReceiveEmotionEmit',emotion)
    })
  }
}
</script>