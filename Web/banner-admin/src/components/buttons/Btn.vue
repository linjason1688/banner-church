<template>
  <q-btn v-bind="$attrs" rounded padding="xs lg" unelevated :class="style">
    <slot></slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";
import { Prop } from "vue-property-decorator";

@Options({})
export default class Btn extends ButtonBase {

  @Prop({ type: Boolean })
  outlined!: boolean;

  get style() {
    return [this.outlined ? "c-btn-outlined" : "c-btn-normal"]
  }
}
</script>

<style scoped lang="scss">
.c-btn-normal {
  font-weight: 700;
  font-size: 16px;
  color: #FFFFFF;
  background-color: #3764AC;
  border: 2px solid currentColor;
}

.c-btn-outlined {
  font-weight: 700;
  font-size: 16px;
  color: #3764AC;
  background-color: #FFFFFF;
  border: 2px solid currentColor;
}
</style>