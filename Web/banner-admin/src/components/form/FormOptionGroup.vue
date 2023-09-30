<template>
  <q-option-group v-bind="$attrs" color="primary" inline />
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";

@Options({})
export default class FormOptionGroup extends FormBase {
  created() {
    //
  }
}
</script>
