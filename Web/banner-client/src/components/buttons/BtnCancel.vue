<template>
  <q-btn v-bind="$attrs" icon="close" color="indigo" rounded outline>
    <slot>取消</slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnCancel extends ButtonBase { }
</script>
