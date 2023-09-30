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
        <q-tab name="info" label="事工團基本資訊"
               icon="img:/img/serve-list.svg">
        </q-tab>
        <q-tab disable label="事工團管理　　" 
               icon="img:/img/serve-manage.svg">
        </q-tab>
        <q-tab name="member" label="　　- 事工團成員管理">
        </q-tab>
        <q-tab name="attendance" label="　　- 事工團出席管理">
        </q-tab>
      </q-tabs>
    </q-drawer>

    <div class="row">
      <div class="col-12">
        <q-tab-panels v-model="tab" animated class="c-background-content">
          <q-tab-panel name="info">
            <c-working-group-info/>
          </q-tab-panel>
          <q-tab-panel name="member">
            <c-working-group-member />
          </q-tab-panel>
          <q-tab-panel name="attendance">
            <c-working-group-attendance />
          </q-tab-panel>
        </q-tab-panels>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import Info from "pages/working-group/Info.vue";
import Member from "pages/working-group/Member.vue";
import Attendance from "pages/working-group/Attendance.vue";
// import { ref } from "vue";

@Options({
  components: {
    "c-working-group-info": Info,
    "c-working-group-member": Member,
    "c-working-group-attendance": Attendance,
  },
})

export default class Index extends ComponentBase {

  isLeftDrawerShow = true;

  tab = "info";

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
