<template>
  <div v-bind="$attrs" class="q-mb-md">
    <div class="grey-7">
      <span>{{ label|| '　' }}</span>
      <span v-if="required" class="app-required">　*</span>
    </div>
    <div class="row q-gutter-md">
      <div v-if="$slots.prepend" class="col-auto">
        <slot name="prepend"></slot>
      </div>
      <div class="col">
        <slot></slot>
      </div>
      <div v-if="$slots.append" class="col-auto">
        <slot name="append"></slot>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";
import { Prop } from "vue-property-decorator";

@Options({})
export default class FormColumn extends FormBase {
  @Prop({ type: String, default: () => "" })
  label!: string;

  @Prop({ type: Boolean, default: false })
  required!: boolean;
}
</script>
