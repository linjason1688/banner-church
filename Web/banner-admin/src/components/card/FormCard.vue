<template>
  <q-card flat bordered class="q-px-lg q-pt-md q-mb-lg" :class="style">
    <slot></slot>
  </q-card>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { CardBase } from "./CardBase";
import { Prop } from "vue-property-decorator";

@Options({})
export default class FormCard extends CardBase {

  @Prop({ type: Boolean, default: true })
  rounded!: boolean;

  @Prop({ type: Boolean })
  filled!: boolean;

  @Prop({ type: Boolean, default: true })
  outlined!: boolean;

  created() {
    //
  }

  get style() {
    return [
      this.rounded ? "c-outline-radius" : "",
      this.filled ? "c-gray-bgcolor-50" : "",
      this.outlined ? "" : "c-no-outline"
    ]
  }
}
</script>

<style scoped lang="scss">
.c-outline-radius {
  box-shadow: 0px 0px 2px rgba(0, 0, 0, 0.2), 0px 1px 5px rgba(151, 153, 158, 0.12);
  border-radius: 20px;
}

.c-no-outline {
  border: 0px !important;
}
</style>
