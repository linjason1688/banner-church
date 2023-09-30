<template>
  <q-card flat bordered class="q-pt-lg q-px-lg q-mb-lg rounded-borders">
    <slot></slot>
  </q-card>
</template>
  
<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { CardBase } from "./CardBase";

@Options({})
export default class FormCard extends CardBase {
  created() {
    //
  }
}
</script>