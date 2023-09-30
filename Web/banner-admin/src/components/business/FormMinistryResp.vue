<template>
  <div>
    <c-select v-bind="$attrs" emit-value map-options :options="dataList" option-value="id" option-label="name" use-input />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { MinistryRespView, QueryMinistryRespRequest } from "src/api/feature";
import { PropSync } from "vue-property-decorator";

export default class FormMinistryResp extends ComponentBase {
  fullDataList: Array<MinistryRespView> = [];

  @PropSync("ministryId", { type: Number })
  syncedMinistryId!: number;

  async created() {
    const res = await this.apis.feature.ministryResp.queryMinistryResps({} as QueryMinistryRespRequest);
    this.fullDataList = res.data.records;
  }

  get dataList() {
    let list = this.fullDataList.filter((e) => e.ministryId == this.syncedMinistryId);
    return list;
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
