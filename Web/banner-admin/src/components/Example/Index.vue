<script setup lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */

import { reactive, onMounted, ref, computed } from "vue";

import { useIncrement } from "./IncrementComposition";
const props = defineProps({
  name: String,
});

const composition = useIncrement();

onMounted(() => {
  console.log("Example Component mounted");
});
</script>

<template>
  <button @click="composition.increment">
    Click {{ composition.state.count }} ({{ composition.doubleValue }}) / {{ composition.num }}
  </button>
</template>
