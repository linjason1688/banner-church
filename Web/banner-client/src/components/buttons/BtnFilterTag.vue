<template>
    <q-btn v-bind="$attrs" class="q-px-sm c-primary-color-500 c-primary-background-100" unelevated>
      <slot></slot>
    </q-btn>
  </template>
  
  <script lang="ts">
  // Component
  import { Options } from "vue-class-component";
  import { ButtonBase } from "./ButtonBase";
  
  @Options({})
  export default class BtnFilterTag extends ButtonBase {}
  </script>
  