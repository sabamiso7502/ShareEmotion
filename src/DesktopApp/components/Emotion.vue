<template>
    <div class="emotion enable-float" style="font-size:48px;">{{text}}</div>
</template>

<script>
export default {
  data() {
    return {
      StyleObject: {
      }
    }
  },
  props: {
    'text': String,
    'id': String
  }
}
</script>

<style scoped>
.enable-float {
	float: right;
}

.v-enter-active {
  transition: all 8s linear;
}

.v-enter {
  transform: translateX(50vw);
}

.v-enter-to {
	transform: translateX(-100vw);
}

</style>
