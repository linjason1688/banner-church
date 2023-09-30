<template>
  <div>
    <q-select v-bind="$attrs"
              emit-value map-options
              :options="dataList"
              option-value="name"
              option-label="value"
              use-input
              use-chips
              dense
    >
    </q-select>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";
import { SystemConfigView } from "src/api/feature";
import { SystemConfig } from "src/util";

export default class FormSystemConfig extends ComponentBase {

  dataList: Array<SystemConfigView> = [];

  @Prop({ type: String })
  systemConfig!: SystemConfig;

  mounted() {
    this.dataList = this.$appStore.getters.getSystemConfig(this.systemConfig)
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
