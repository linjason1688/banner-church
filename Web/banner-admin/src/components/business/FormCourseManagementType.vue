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
import { CourseManagementTypeView, QueryCourseManagementTypeRequest } from "src/api/feature";
import {Emit} from "vue-property-decorator";

export default class FormCourseManagementType extends ComponentBase {

  dataList: Array<CourseManagementTypeView> = [];

  async mounted() {
    const res = await this.apis.feature.courseManagementType.queryCourseManagementTypes({} as QueryCourseManagementTypeRequest);
    this.dataList = res.data.records;
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
