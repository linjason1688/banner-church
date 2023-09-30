<template>
  <q-btn v-bind="$attrs" color="indigo" rounded>
    <q-icon class="q-mx-xs" name="search"></q-icon>
    <slot>查詢</slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnSearch extends ButtonBase {}
</script>
