<template>
  <div>
    <c-select v-bind="$attrs"
              emit-value map-options
              :options="dataList"
              option-value="id"
              option-label="teacherName"
              use-input
              use-chips
    />
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import {QueryTeacherRequest, UserView} from "src/api/feature";

export default class FormTeacher extends ComponentBase {

  dataList: Array<UserView> = [];

  async mounted() {
    const res = await this.apis.feature.teacher.queryTeachers({} as QueryTeacherRequest);
    this.dataList = res.data.records;
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
