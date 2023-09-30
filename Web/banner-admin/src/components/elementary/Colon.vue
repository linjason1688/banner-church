<template>
  <span v-bind="$attrs">：</span>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ElementaryBase } from "./ElementaryBase";

@Options({})
export default class Colon extends ElementaryBase {}
</script>
