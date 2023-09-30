<template>
    <div v-bind="$attrs" class="row q-col-gutter-md">
        <slot></slot>
    </div>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";

@Options({})
export default class FormRow extends FormBase {

}
</script>
