<template>
    <q-btn color="primary" flat class="c-heading-h5" rounded>
        <q-icon class="q-mr-lg" :name="btnName"/>
        <slot></slot>
    </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnIconAfter extends ButtonBase {

    @Prop({ type: String })
    btnName!: string;
}
</script>
