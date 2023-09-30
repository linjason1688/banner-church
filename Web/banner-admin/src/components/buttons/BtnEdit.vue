<template>
  <q-btn v-bind="$attrs" color="primary" size="md" flat rounded label="編輯" >
    <slot></slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnEdit extends ButtonBase {}
</script>
