<script src="https://cdnjs.cloudflare.com/ajax/libs/velocity/1.2.3/velocity.min.js"></script>

<template>
	<section class="container">
		<div>
			<transition-group v-on:after-enter="afterEnter">
			  <emotion v-for="e in emotions" v-bind:key="e.id" :text="e.text" :id="e.id"></emotion>
			</transition-group >
		</div>
		<ws @ReceiveEmotionEmit="createEmotion"></ws>
	</section>
</template>
<script src="https://cdnjs.cloudflare.com/ajax/libs/velocity/1.2.3/velocity.min.js"></script>

<script>
import Vue from 'vue'
import Emotion from '@/components/Emotion.vue'
import WebSocket from '@/components/WebSocket.vue'

const win = window.remote.getCurrentWindow()
export default {
	data: function() {
		return {
			emotions: []
		}
	},
	methods: {
		onMouseEnter () {
			//win.setIgnoreMouseEvents(false)
		},
        onMouseLeave () {
			//win.setIgnoreMouseEvents(true, { forward: true })
		},
		createEmotion(emotion) {
			console.clear()
			console.log("create emotion")
			let time = "time:" + new Date().getTime()
			this.emotions.push({text: emotion,id: time})
		},
		clearEmotion() {
			console.clear()
			console.log("clear emotion")
			this.emotions = []
		},
		afterEnter: function (el) {
			this.emotions.splice(0, 1)
			console.log("end anime")
		},
  },
  components: {
    'emotion': Emotion,
	'ws': WebSocket
  },
   head: {
    meta: [
      { name: 'viewport', content: 'width=device-width, initial-scale=1.0' }
	]
   }
}


</script>

<style scoped>
.container {
	/*
	min-height: 100vh;
	display: flex;
	justify-content: center;
	align-items: center;
	text-align: center;*/
}
.btn {
	margin: 0 8px;
}

.enable-float {
	float: right;
}

</style>
