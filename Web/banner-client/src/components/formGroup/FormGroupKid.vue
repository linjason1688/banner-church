<template>
    <c-row>
        <c-column label="兒童姓名" class="col-12 col-sm-5">
            <q-input v-model="syncedName" dense />
        </c-column>
        <c-column label="兒童帳號" class="col-12 col-sm-4">
            <q-input v-model="syncedAccount" dense />
        </c-column>
        <c-column class="col text-right">
            <q-btn color="indigo" label="編輯帳號" no-wrap rounded @click="updateChild(syncedAccount)" />
        </c-column>
    </c-row>
</template>
  
<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormGroupBase } from "./FormGroupBase";
import { Emit, PropSync } from "vue-property-decorator";

@Options({})
export default class FormGroupKid extends FormGroupBase {
    @PropSync("name", { type: String }) syncedName!: string;
    @PropSync("account", { type: String }) syncedAccount!: string;
    @Emit("update") updateChild($event = "") { return $event }
}
</script>
  