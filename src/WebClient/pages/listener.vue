<template>
<div>
    <input v-model="Emotion" placeholder="emotion">
    <p></p>
    <v-btn v-on:click="toTopPage" class="key" >←</v-btn>
    <v-btn v-on:click="sendEmotion">→</v-btn>
</div>
</template>

<script>
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'
const connection = new HubConnectionBuilder()
  .withUrl('http://localhost:3417/EmotionHub')
  .configureLogging(LogLevel.Information)
  .build()

connection.start()

export default {
    data() {
        return {
            Emotion: "default"
        }
    },
    methods: {
        sendEmotion() {
            console.log("send emotion")
            let num = this.$route.query.groupNumber
            console.log("num = " + num)
            connection.invoke("SendEmotion",num,this.Emotion)
            .catch(err => console.error(err));
            this.Emotion = ""
        },
        toTopPage() {
			this.$router.push({ path: '/'})
		}
    }
}
</script>

<style>
</style>