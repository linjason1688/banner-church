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
      <q-tabs v-model="tab"
              vertical
              stretch shrink
              inline-label
      >
        <q-tab label="課程管理(會友)"
               icon="img:/img/member.svg">
        </q-tab>
        <q-tab name="course" label="- 課程資訊">
        </q-tab>
        <q-tab name="graduation" label="- 結業狀態">
        </q-tab>
      </q-tabs>
    </q-drawer>

    <div class="row">
      <div class="col-12">
        <q-tab-panels v-model="tab" animated class="c-background-content">
          <q-tab-panel name="course">
            <c-school-course />
          </q-tab-panel>
          <q-tab-panel name="graduation">
            <c-school-graduation />
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
import Course from "pages/school/Course.vue";
import Graduation from "pages/school/Graduation.vue";

@Options({

  components: {
    "c-school-course": Course,
    "c-school-graduation": Graduation,
  },
})
export default class Index extends ComponentBase {

  isLeftDrawerShow = false;
  tab = ref("course");

  async mounted() {
    //
  }

}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
