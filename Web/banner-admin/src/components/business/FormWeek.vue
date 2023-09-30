<template>
  <div>

  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class FormWeek extends ComponentBase {

  @Prop({ type: String })
  title!: string;

  weekList = [
    {
      label: "星期一",
      value: "1",
    },
    {
      label: "星期二",
      value: "2",
    },
    {
      label: "星期三",
      value: "3",
    },
    {
      label: "星期四",
      value: "4",
    },
    {
      label: "星期五",
      value: "5",
    },
    {
      label: "星期六",
      value: "6",
    },
    {
      label: "星期日",
      value: "7",
    },
  ];

  async mounted() {
    //
  }

}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
