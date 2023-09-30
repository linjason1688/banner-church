<template>
  <q-field borderless v-bind="$attrs" stack-label>
    <template v-slot:control>
      <div class="self-center full-width no-outline" tabindex="0">
        <div class="row">
          <div class="col-12 col-md-12">
            <slot></slot>
          </div>
        </div>
      </div>
    </template>
  </q-field>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";

@Options({})
export default class FormField extends FormBase {
  created() {
    //
  }
}
</script>
