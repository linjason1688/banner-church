<template>
  <div class="row justify-between">
    <div class="col-12 col-md-6 q-pr-md">
      <c-form-ministry v-model="syncedMinistryId" placeholder="請選擇事工團名稱"
                       outlined clearable dense></c-form-ministry>
    </div>
    <div class="col-12 col-md-6">
      <c-form-ministry-resp v-model="syncedMinistryRespId" v-model:ministryId="syncedMinistryId" placeholder="請選擇事工團職分"
                            outlined clearable dense></c-form-ministry-resp>
    </div>
  </div>
  <slot></slot>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormGroupBase } from "./FormGroupBase";
import { PropSync } from "vue-property-decorator";
import FormMinistry from "components/business/FormMinistry.vue";
import FormMinistryResp from "components/business/FormMinistryResp.vue";

@Options({
  components: {
    "c-form-ministry": FormMinistry,
    "c-form-ministry-resp": FormMinistryResp,
  },
})
export default class FormGroupMinistry extends FormGroupBase {

  @PropSync("ministryId", { type: Number }) syncedMinistryId!: number;
  @PropSync("ministryRespId", { type: Number }) syncedMinistryRespId!: number;

  created() {
    //
  }
}
</script>
