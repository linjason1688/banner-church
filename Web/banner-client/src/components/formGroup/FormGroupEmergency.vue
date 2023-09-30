<template>
  <c-row>
    <div class="col-12 col-sm-5">
      <c-column label="緊急聯絡人" required>
        <c-input v-model="syncedName" role="n" :rules="[(val) => !!val || '請輸入緊急聯絡人']"></c-input>
      </c-column>
    </div>
    <div class="col-12 col-sm-3">
      <c-column label="關係" required>
        <c-input v-model="syncedRelative" role="n" :rules="[(val) => !!val || '請輸入關係']"></c-input>
      </c-column>
    </div>
    <div class="col-12 col-sm-4">
      <c-column label="電話" required>
        <c-input v-model="syncedPhone" role="n" :rules="[(val) => !!val || '請輸入電話']"></c-input>
      </c-column>
    </div>
  </c-row>
  <slot></slot>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormGroupBase } from "./FormGroupBase";
import { PropSync } from "vue-property-decorator";

@Options({})
export default class FormGroupEmergency extends FormGroupBase {
  @PropSync("name", { type: String }) syncedName!: string;

  @PropSync("relative", { type: String }) syncedRelative!: string;

  @PropSync("phone", { type: String }) syncedPhone!: string;

  created() {
    //
  }
}
</script>