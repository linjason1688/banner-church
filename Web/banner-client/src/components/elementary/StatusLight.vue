<template>
  <q-icon :color="color" name="circle"></q-icon>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";

// Store
import { Prop } from "vue-property-decorator";
import { ElementaryBase } from "src/components/elementary/ElementaryBase";

@Options({})
export default class StatusLight extends ElementaryBase {
  @Prop({
    default: null,
  })
  private readonly status!: boolean;

  get color() {
    if (undefined === this.status || null === this.status) {
      return "grey";
    }
    return this.status ? "green" : "red";
  }
}
</script>
