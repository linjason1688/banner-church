<template>
  <div>
    <div>
      <img src="../../../public/img/class_logo.svg" alt="">
    </div>
    <div>旌旗領袖學習圈 - 豐盛恩光</div>
    <div class="c-content-body">實體營會</div>
    <div>早鳥價 NT$1800</div>
    <div>原價 NT$2200</div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class ClassCard extends ComponentBase {

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
