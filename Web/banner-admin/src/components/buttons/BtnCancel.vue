<template>
  <q-btn v-bind="$attrs" class="q-ma-xs" color="negative" outline rounded>
    <q-icon class="q-ml-xs" name="delete"></q-icon>
    <slot>取消</slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnCancel extends ButtonBase {}
</script>
