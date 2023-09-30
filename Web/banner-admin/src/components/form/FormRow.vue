<template>
    <div v-bind="$attrs" class="row q-col-gutter-md">
        <slot></slot>
    </div>
</template>

<script lang="ts">
// Component
import { FormBase } from "./FormBase";

export default class FormRow extends FormBase {

}
</script>
