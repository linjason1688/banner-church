<template>
  <c-select
    v-bind="$attrs"
    dense
    emit-value
    map-options
    :options="dataList"
    option-value="id"
    option-label="title"
    outlined
    :rounded="false"
    use-input
    use-chips
  />
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { CourseManagementView, QueryCourseManagementRequest } from "src/api/feature";

export default class FormCourseManagement extends ComponentBase {
  dataList: Array<CourseManagementView> = [];

  async mounted() {
    const res = await this.apis.feature.courseManagement.queryCourseManagements({} as QueryCourseManagementRequest);
    this.dataList = res.data.records;
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
