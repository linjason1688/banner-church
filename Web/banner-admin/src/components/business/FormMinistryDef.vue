<template>
  <div>
    <c-select v-bind="$attrs"
              emit-value map-options
              :options="dataList"
              option-value="id"
              option-label="name"
              use-input
              use-chips
    />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { MinistryDefView, QueryMinistryDefRequest } from "src/api/feature";

export default class FormMinistryDef extends ComponentBase {

  dataList: Array<MinistryDefView> = [];

  async mounted() {
    const res = await this.apis.feature.ministryDef.queryMinistryDefs({} as QueryMinistryDefRequest);
    this.dataList = res.data.records;
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
