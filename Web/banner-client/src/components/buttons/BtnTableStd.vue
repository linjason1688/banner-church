<template>
  <q-btn
    v-bind="$attrs"
    class="q-py-none q-px-lg c-gray-background-100"
    rounded
    unelevated
    dense
  >
    <slot></slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnTableStd extends ButtonBase {}
</script>
