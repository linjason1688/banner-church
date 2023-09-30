<template>
  <q-btn v-bind="$attrs" color="primary">
    <slot></slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class Btn extends ButtonBase {}
</script>
