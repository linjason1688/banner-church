<template>
  <q-btn v-bind="$attrs" icon="save" color="indigo" rounded>
    <slot>儲存</slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnSave extends ButtonBase { }
</script>
