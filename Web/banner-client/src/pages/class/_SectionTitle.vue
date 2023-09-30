<template>
  <div class="row no-wrap">
    <q-icon size="25px" :name="icon" class="q-mr-sm c-primary-color-500"></q-icon>
    <div class="q-mb-md c-content-title c-primary-color-500">{{ title }}</div>
  </div>
  <slot></slot>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { FormBase } from "components/form/FormBase";

@Options({})
export default class SectionTitle extends FormBase {
  @Prop({ type: String, default: () => "" })
  readonly title!: string;

  @Prop({ type: String, default: () => "" })
  readonly icon!: string;

  created() {
    //
  }
}
</script>
