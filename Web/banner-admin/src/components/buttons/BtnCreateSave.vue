<template>
  <q-btn v-bind="$attrs" color="orange" large block rounded>
    <q-icon class="q-ml-xs" name="save"></q-icon>
    <slot>儲存</slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnCreateSave extends ButtonBase {}
</script>
