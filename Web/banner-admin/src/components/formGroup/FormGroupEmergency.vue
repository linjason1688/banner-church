<template>
  <div class="row q-mb-md justify-between">
    <div class="col-12 col-md-5">
      <c-column label="緊急聯絡人">
        <c-input-gutter role="edit2" v-model="syncedName" />
      </c-column>
    </div>
    <div class="col-12 col-md-3">
      <c-column label="關係">
        <c-input-gutter role="edit2" v-model="syncedRelative" />
      </c-column>
    </div>
    <div class="col-12 col-md-4">
      <c-column label="電話">
        <c-input-gutter role="edit2" v-model="syncedPhone" />
      </c-column>
    </div>
  </div>
  <slot></slot>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormGroupBase } from "./FormGroupBase";
import { PropSync } from "vue-property-decorator";

@Options({})
export default class FormGroupEmergency extends FormGroupBase {

  @PropSync("name",{ type: String}) syncedName!: string;

  @PropSync("relative",{ type: String}) syncedRelative!: string;

  @PropSync("phone",{ type: String}) syncedPhone!: string;

  created() {
    //
  }
}
</script>
