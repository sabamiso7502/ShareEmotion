<template>
	<section class="container">
		<p class="display">{{groupNumber}}</p>
		<v-btn v-on:click="pressedKey(1)" class="key" >1</v-btn>
		<v-btn v-on:click="pressedKey(2)" class="key" >2</v-btn>
		<v-btn v-on:click="pressedKey(3)" class="key" >3</v-btn>
		<p></p>
		<v-btn v-on:click="pressedKey(4)" class="key" >4</v-btn>
		<v-btn v-on:click="pressedKey(5)" class="key" >5</v-btn>
		<v-btn v-on:click="pressedKey(6)" class="key" >6</v-btn>
		<p></p>
		<v-btn v-on:click="pressedKey(7)" class="key" >7</v-btn>
		<v-btn v-on:click="pressedKey(8)" class="key" >8</v-btn>
		<v-btn v-on:click="pressedKey(9)" class="key" >9</v-btn>
		<p></p>
		<v-btn v-on:click="pressedKey(-1)" class="key" >←</v-btn>
		<v-btn v-on:click="pressedKey(0)" class="key" >0</v-btn>
		<v-btn v-on:click="toGroupPage" class="key" >→</v-btn>

	</section>
</template>
<script>

export default {
	data: function() {
		return {
			groupNumber: "-----",
			groupNumberMaxLength: 5,
			back: -1,
			index: 0
		}
	},
	methods: {
		pressedKey(keyValue) {
			console.log("called pressed key")
			console.log("keyValue is " + keyValue)
			console.log("groupNumberLength is " + this.groupNumber.length)
			if(keyValue == this.back) {
				if(this.index < 0) {
					return;
				}
				let array = this.groupNumber.split('')
				array[this.index] = '-'
				this.groupNumber = array.join('')
				this.index--
				if(this.index <= 0) {
					this.index = 0
				}
			}else {
				if(this.index >= this.groupNumberMaxLength){
					return;
				}
				let array = this.groupNumber.split('')
				array[this.index] = keyValue
				this.groupNumber = array.join('')
				this.index++
				if(this.index >= this.groupNumberMaxLength){
					this.index = this.groupNumberMaxLength - 1
				}
			}
		},
		toGroupPage() {
			this.$router.push({ path: 'listener', query: { groupNumber: this.groupNumber } })
		}
	}
}
</script>

<style>
</style>