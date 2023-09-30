<template>
  <div>
    <q-drawer
      v-model="isLeftDrawerShow"
      :breakpoint="768"
      :width="250"
      class="bg-grey-2"
      side="left"
      show-if-above
      bordered
    >
      <q-tabs v-model="tab" vertical stretch shrink inline-label align="left" align-label="align-label">
        <q-tab label="課程管理(會友)" icon="img:/img/member.svg" class="c-default-cursor" disable> </q-tab>
        <q-tab name="class-member" label="- 課程資訊　" align-label="align-label"> </q-tab>
        <q-tab name="other" label="- 課程作業區" align-label class="c-default-cursor" disable> </q-tab>
        <q-tab name="done" label="- 出勤紀錄　" class="c-default-cursor" disable> </q-tab>
        <q-tab name="done" label="- 結業狀態　" class="c-default-cursor" disable> </q-tab>
        <q-tab label="課程管理(講師)" icon="img:/img/teacher.svg" class="c-default-cursor" disable> </q-tab>
        <q-tab name="class-teacher" label="- 課程資訊　"> </q-tab>
        <q-tab name="done" label="- 課程作業區" class="c-default-cursor" disable> </q-tab>
        <q-tab name="done" label="- 出勤紀錄　" class="c-default-cursor" disable> </q-tab>
        <q-tab name="done" label="- 結業狀態　" class="c-default-cursor" disable> </q-tab>
      </q-tabs>
    </q-drawer>

    <div class="row">
      <div class="col-12">
        <q-tab-panels v-model="tab" animated class="c-background-content">
          <q-tab-panel name="class-member">
            <c-course-member-list></c-course-member-list>
          </q-tab-panel>
          <q-tab-panel name="class-teacher">
            <c-course-teacher-list></c-course-teacher-list>
          </q-tab-panel>
        </q-tab-panels>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { ref } from "vue";
import { Options } from "vue-class-component";
import Detail from "pages/course-member/Detail.vue";
import List from "pages/course-member/List.vue";
import TeacherList from "pages/course-teacher/List.vue";

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {
    "c-course-member-detail": Detail,
    "c-course-member-list": List,
    "c-course-teacher-list": TeacherList,
  },
})
export default class Index extends ComponentBase {
  isLeftDrawerShow = false;
  tab = ref("class-member");

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";

.c-default-cursor {
  cursor: default !important;
}
</style>
