<template>
    <q-input class="q-pl-md q-pr-sm q-mb-md" dense>
        <template v-slot:after>
          <q-btn round dense flat icon="delete" />
        </template>
    </q-input>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";

@Options({})
export default class FormDeletable extends FormBase {
    created() {
        //
    }
}
</script>
