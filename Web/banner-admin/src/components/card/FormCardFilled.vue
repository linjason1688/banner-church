<template>
  <q-card flat bordered class="q-pa-sm q-mb-lg c-outline-radius">
    <q-card class="q-px-lg q-pt-lg q-pb-sm c-gray-bgcolor-50">
      <slot></slot>
    </q-card>
  </q-card>
</template>
  
<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { CardBase } from "./CardBase";

@Options({})
export default class FormCardFilled extends CardBase {
  created() {
    //
  }
}
</script>