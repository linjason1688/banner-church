<template>
  <div>

  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class FormAreaCode extends ComponentBase {

  @Prop({ type: String })
  title!: string;

  async mounted() {
    //
  }

}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
