<template>
	<v-app>
		<section class="container" style="width:300px">
			<p class="display" style="width:300px">{{groupNumber}}</p>
			<v-card-actions v-for="option in options" :key="option" class="d-inline-flex">
				<v-btn v-on:click="pressedKey(option)">{{ option }}</v-btn>
			</v-card-actions>
		</section>
	</v-app>
</template>

<script>
export default {
	data: function() {
		return {
			groupNumber: "-----",
			groupNumberMaxLength: 5,
			back: '←',
			enter: '→',
			index: 0,
			options: ['7','8','9','4','5','6','1','2','3','←','0','→']
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
			}
			else if(keyValue == this.enter){
				this.toGroupPage()
			}
			else {
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
