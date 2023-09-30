<template>
  <q-btn v-bind="$attrs" padding="xs lg" flat rounded class="c-content-body-bold c-gray-bgcolor-100">
    <slot>編輯</slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnActionText extends ButtonBase {}
</script>
