<template>
  <q-card flat bordered class="q-pa-xl q-py-lg q-mb-lg c-shadow-card">
    <slot></slot>
  </q-card>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { CardBase } from "./CardBase";

@Options({})
export default class ShadowCard extends CardBase {
  created() {
    //
  }
}
</script>
