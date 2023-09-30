<template>
  <q-card flat bordered class="q-pa-none q-mb-lg c-shadow-card">
    <div
      class="c-gray-color-901 c-gray-background-100 row flex-center c-content-subtitle"
      style="min-height: 35px; min-width: 200px"
    >
      {{ title }}
    </div>
    <div class="c-gray-bgcolor-50 column flex-center q-pa-sm" style="min-height: 120px; min-width: 200px">
      <slot></slot>
    </div>
  </q-card>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { CardBase } from "./CardBase";
import { Prop } from "vue-property-decorator";

@Options({})
export default class TitledCard extends CardBase {
  @Prop({ default: "" })
  title!: string;

  created() {
    //
  }
}
</script>
