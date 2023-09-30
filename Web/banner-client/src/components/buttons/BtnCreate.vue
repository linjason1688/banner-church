<template>
  <q-btn v-bind="$attrs" color="primary" outline rounded>
    <slot>新增</slot>
    <q-icon class="q-ml-xs" name="add" />
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnCreate extends ButtonBase {}
</script>
