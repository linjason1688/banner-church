<template>
  <q-btn v-bind="$attrs" icon="rate_review" size="sm" color="accent" flat  rounded>
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
