<template>
  <div class="row q-mb-md justify-between">
    <div class="col-12 col-md-grow">
      <c-column label="孩童姓名">
        <c-input-gutter role="edit2" v-model="syncedName" />
      </c-column>
    </div>
    <div class="col-12 col-md-grow">
      <c-column label="孩童帳號">
        <c-input-gutter role="edit2" v-model="syncedAccount" />
      </c-column>
    </div>
    <div class="col-12 col-lg-auto q-pr-md q-mb-md self-end column items-end">
      <q-btn label="編輯帳號" stack-label no-wrap unelevated rounded color="primary" />
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
export default class FormGroupKid extends FormGroupBase {

  @PropSync("name",{ type: String}) syncedName!: string;

  @PropSync("account",{ type: String}) syncedAccount!: string;

  created() {
    //
  }
}
</script>
