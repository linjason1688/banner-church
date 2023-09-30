<template>
  <q-btn v-bind="$attrs" icon="visibility" size="sm" color="primary" flat round>
    <slot></slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnView extends ButtonBase {}
</script>
