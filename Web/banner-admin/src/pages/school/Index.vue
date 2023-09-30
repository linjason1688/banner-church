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
        <q-tab name="profile" label="課程管理(會友)"
               icon="img:/img/member.svg">
        </q-tab>
        <q-tab name="family" label="- 課程資訊">
        </q-tab>
        <q-tab name="payment" label="- 結業狀態">
        </q-tab>
      </q-tabs>
    </q-drawer>

    <div class="row">
      <q-tab-panels v-model="tab" animated>
        <q-tab-panel name="profile">
          <c-member-profile></c-member-profile>
        </q-tab-panel>
        <q-tab-panel name="family">
          <c-member-family></c-member-family>
        </q-tab-panel>
        <q-tab-panel name="payment">
          <c-member-payment></c-member-payment>
        </q-tab-panel>
        <q-tab-panel name="working">
          <c-member-working-group></c-member-working-group>
        </q-tab-panel>
      </q-tab-panels>
    </div>

  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { ref } from "vue";

export default class Index extends ComponentBase {

  isLeftDrawerShow = false;
  tab = ref("profile");

  async mounted() {
    //
  }

}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
