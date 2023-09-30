<template>
  <q-select v-bind="$attrs"
            emit-value map-options
            :options="dataList"
            option-value="id"
            option-label="name"
            use-input
            dense
  >
  </q-select>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { FetchAllPastoralRequest, PastoralView } from "src/api/feature";

export default class FormPastoral extends ComponentBase {

  dataList: Array<PastoralView> = [];

  async mounted() {
    const res = await this.apis.feature.pastoral.fetchPastorals({} as FetchAllPastoralRequest);
    this.dataList = res.data;
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
