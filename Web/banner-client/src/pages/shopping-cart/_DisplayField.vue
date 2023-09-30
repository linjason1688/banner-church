<template>
  <div v-bind:class="[nogutter ? 'q-mx-none' : 'q-mx-md', nobottomspace ? 'q-mb-none' : 'q-mb-lg']">
    <div class="c-content-title c-text-color-100 q-mb-sm" v-bind:class="[nogutter ? 'q-mx-md' : 'q-mx-none']">
      {{ label }}
    </div>
    <div class="c-content-body c-text-color-100">
      <slot></slot>
    </div>
  </div>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { FormBase } from "components/form/FormBase";

@Options({})
export default class DisplayField extends FormBase {
  @Prop({ type: String, default: () => "" })
  label!: string;

  @Prop({ type: Boolean, default: false })
  nogutter!: boolean;

  @Prop({ type: Boolean, default: false })
  nobottomspace!: boolean;

  created() {
    //
  }
}
</script>
