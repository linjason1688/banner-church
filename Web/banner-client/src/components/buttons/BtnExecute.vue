<template>
  <q-btn v-bind="$attrs" color="teal">
    <slot>執行</slot>
    <q-icon class="q-ml-xs" name="play_arrow"></q-icon>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnExecute extends ButtonBase {}
</script>
