<template>
  <div>
    <c-select v-bind="$attrs" emit-value map-options :options="dataList" option-value="id" option-label="title"
      use-input v-model="syncedCourseManagementId" />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { CourseManagementView, QueryCourseManagementRequest } from "src/api/feature";
import { PropSync, Watch } from "vue-property-decorator";

export default class FormCourseManagement extends ComponentBase {

  fullDataList: Array<CourseManagementView> = [];

  @PropSync("courseManagementTypeId", { type: Number })
  syncedCourseManagementTypeId!: number;

  @PropSync("courseManagementId", { type: Number })
  syncedCourseManagementId!: number | undefined;

  get dataList() {
    if (this.syncedCourseManagementTypeId) {
      return this.fullDataList.filter(e => e.courseManagementTypeId == this.syncedCourseManagementTypeId);
    }
    return this.fullDataList;
  }

  @Watch("courseManagementTypeId", { immediate: true, deep: true })
  onCourseManagementTypeIdChanged(val: number) {
    if (val == null) {
      this.syncedCourseManagementId = undefined;
    }
  }

  @Watch("syncedCourseManagementId", { immediate: true, deep: true })
  onCourseManagementIdChanged(val: number) {
    if (val == null) {
      this.syncedCourseManagementId = undefined;
    }
  }

  async mounted() {
    const res = await this.apis.feature.courseManagement.queryCourseManagements({
      courseManagementTypeId: this.syncedCourseManagementTypeId,
      size: 10000,
    } as unknown as QueryCourseManagementRequest);
    this.fullDataList = res.data.records;
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';
</style>
