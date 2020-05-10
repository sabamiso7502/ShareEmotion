<template>
	<div class="container">
		<div id="nico"></div>
		<ws @ReceiveEmotionEmit="createEmotion"></ws>
	</div>
</template>

<script>
import NicoJS from '@/node_modules/nicojs'
import WebSocket from '@/components/WebSocket.vue'

export default {
	data() {
		return {
			nico: null
		}
	},
	methods: {
		createEmotion(emotion) {
			console.log("create emotion")
			this.nico.send(emotion)
		}
	},
	mounted() {
		console.log("mounted")
		this.nico = new NicoJS({
				app: this.$el,
				width: 1920,
				height: 1080,
				font_size: 50,
				color: '#111',
				speed: 20
		})
		this.nico.listen()
		this.nico.loop(['88888','wwww','www'])
	},
	components: {
		'ws': WebSocket
	}
}

</script>

<style>
</style>