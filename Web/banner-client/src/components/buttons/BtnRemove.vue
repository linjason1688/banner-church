<template>
  <q-btn v-bind="$attrs" class="q-ma-xs" color="negative" outline>
    <slot>刪除</slot>
    <q-icon class="q-ml-xs" name="delete"></q-icon>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnRemove extends ButtonBase {}
</script>
