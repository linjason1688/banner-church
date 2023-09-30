<template>
  <c-select
    v-bind="$attrs"
    dense
    emit-value
    map-options
    :options="dataList"
    option-value="id"
    option-label="name"
    use-input
    use-chips
    class="q-pb-md"
  />
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { CourseManagementTypeView, QueryCourseManagementTypeRequest } from "src/api/feature";

export default class FormCourseManagementType extends ComponentBase {
  dataList: Array<CourseManagementTypeView> = [];

  async mounted() {
    const res = await this.apis.feature.courseManagementType.queryCourseManagementTypes(
      {} as QueryCourseManagementTypeRequest
    );
    this.dataList = res.data.records;
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
