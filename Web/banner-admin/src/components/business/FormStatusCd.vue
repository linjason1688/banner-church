<template>
  <div class="q-gutter-md">
    <q-radio v-if="this.hasAllOptions" v-bind="$attrs" val="" label="全部" />
    <q-radio v-bind="$attrs" val="0" label="停用" />
    <q-radio v-bind="$attrs" val="1" label="啟用" />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class FormStatusCd extends ComponentBase {
  @Prop({ type: Boolean, default: false })
  hasAllOptions!: boolean;

  async mounted() {
    //
  }
}
</script>