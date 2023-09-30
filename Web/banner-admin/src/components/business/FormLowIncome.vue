<template>
  <div class="q-gutter-md q-pt-md">
    <q-radio v-if="this.hasAllOptions" v-bind="$attrs" val="" label="全部" />
    <q-radio v-bind="$attrs" val="1" label="中低收入戶" />
    <q-radio v-bind="$attrs" val="0" label="一般" />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class FormLowIncome extends ComponentBase {

  @Prop({ type: Boolean, default:false })
  hasAllOptions!: boolean;

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
