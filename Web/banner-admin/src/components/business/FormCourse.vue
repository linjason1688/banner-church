<template>
  <div>
    <c-select v-bind="$attrs"
              emit-value map-options
              :options="dataList"
              option-value="id"
              option-label="name"
              use-input
              @update:model-value="onUpdateModelValue"
    />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import {CourseView} from "src/api/feature";
import {Emit} from "vue-property-decorator";

export default class FormCourse extends ComponentBase {

  dataList: Array<CourseView> = [];

  async mounted() {
    const res = await this.apis.feature.course.fetchCourses({});
    this.dataList = res.data;
  }

  @Emit("onUpdateModelValue")
  onUpdateModelValue(){
    //
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
