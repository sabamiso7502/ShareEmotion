<template>
	<section class="container">
		<div>
      <input v-model="RoomNumber" placeholder="room number">
      <input v-model="Emotion" placeholder="emotion">
			<button v-on:click="sendEmotion">send</button>
		</div>
	</section>
</template>
<script>
import axios from 'axios'
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'
const connection = new HubConnectionBuilder()
  .withUrl('http://localhost:3417/EmotionHub')
  .configureLogging(LogLevel.Information)
  .build()

connection.start()

connection.on("ReceiveMessage", (user, message) => {
	const encodedMsg = `${user} says ${message}`;
	console.log(encodedMsg);
});

export default {
	data: function() {
		return {
			Emotion: "default",
			RoomNumber: "11111"
		}
	},
	methods: {
		sendEmotion() {
		console.clear()
		console.log("create emotion")
		console.log("Emotion is " + this.Emotion)
		console.log("RoomNumber is " + this.RoomNumber)
		connection.invoke("SendMessage","user","message")
		.catch(err => console.error(err));
		this.Emotion = ""
	}
  }
}


</script>