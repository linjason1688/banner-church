<template>
  <q-field borderless v-bind="$attrs" class="q-mx-md">
    <template v-slot:label>
      <div class="row c-field-label">
        <p>{{$attrs.label}}</p>
        <p v-if="required" style="color: #F21E1E;">　*</p>
      </div>
    </template>
    <template v-slot:control>
      <div class="self-center full-width no-outline" tabindex="0">
        <div class="col">
          <slot></slot>
        </div>
      </div>
    </template>
  </q-field>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";
import { Prop } from "vue-property-decorator";

@Options({})
export default class FormField extends FormBase {

  @Prop({ type: Boolean, default:false })
  required!: boolean;

  created() {
    //
  }
}
</script>
