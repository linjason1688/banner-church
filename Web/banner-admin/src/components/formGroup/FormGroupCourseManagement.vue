<template>
  <c-row class="q-mb-sm">
    <div class="course-lab col-12 col-sm-6">
      <c-form-course-management-type v-model="syncedCourseManagementTypeId" placeholder="請選擇課程分類" outlined clearable dense />
    </div>
    <div class="course-lab col-12 col-sm-6">
      <c-form-course-management v-model:courseManagementId="syncedCourseManagementId"
      v-model:courseManagementTypeId.sync="syncedCourseManagementTypeId" placeholder="請選擇課程名稱" outlined clearable dense />
    </div>
  </c-row>
  <slot></slot>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormGroupBase } from "./FormGroupBase";
import { PropSync } from "vue-property-decorator";
import FormCourseManagement from "components/business/FormCourseManagement.vue";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";

@Options({
  components: {
    "c-form-course-management": FormCourseManagement,
    "c-form-course-management-type": FormCourseManagementType,
  },
})
export default class FormGroupCourseManagement extends FormGroupBase {

  @PropSync("courseManagementTypeId", { type: Number }) syncedCourseManagementTypeId!: number;
  @PropSync("courseManagementId", { type: Number }) syncedCourseManagementId!: number;

  created() {
    //
  }

  // courseManagementTypeId = null;
}
</script>

<style lang="scss" scoped>

.course-lab {
  width: 218px;
  margin-right: 55px;
}
</style>