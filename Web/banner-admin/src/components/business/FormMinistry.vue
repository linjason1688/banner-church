<template>
  <div>
    <c-select v-bind="$attrs"
              emit-value map-options
              :options="dataList"
              option-value="id"
              option-label="name"
              use-input
    />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { MinistryView, QueryMinistryRequest } from "src/api/feature";

export default class FormMinistry extends ComponentBase {

  dataList: Array<MinistryView> = [];

  async created() {
    const res = await this.apis.feature.ministry.queryMinistry({} as QueryMinistryRequest);
    this.dataList = res.data.records;
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
