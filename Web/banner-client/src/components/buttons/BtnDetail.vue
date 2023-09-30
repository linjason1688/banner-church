<template>
  <q-btn v-bind="$attrs" color="primary" outline rounded>
    <slot>詳細</slot>
    <q-icon class="q-ml-xs" name="info"></q-icon>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnDetail extends ButtonBase {}
</script>
