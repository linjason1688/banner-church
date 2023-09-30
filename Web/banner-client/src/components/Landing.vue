<template>
  <div class="landing"></div>
</template>

<script lang="ts">
// Component
import { ComponentBase } from "src/components/ComponentBase";
import { Options } from "vue-class-component";

@Options({})
export default class Landing extends ComponentBase {
  created() {
    this.showLoading();
  }
}
</script>

<style scoped>
.landing {
  height: 100vh;
  background: linear-gradient(
    90deg,
    rgba(255, 255, 255, 1) 0%,
    rgba(238, 238, 238, 1) 50%,
    rgba(255, 255, 255, 1) 100%
  );
}
</style>
