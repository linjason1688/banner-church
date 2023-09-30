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
        <q-tab name="index" label="問卷填寫"
               icon="img:/img/question.svg">
        </q-tab>
      </q-tabs>
    </q-drawer>

    <div>
      <q-tab-panels v-model="tab" animated>
        <q-tab-panel name="index">
          <c-questionnaire-query></c-questionnaire-query>
        </q-tab-panel>
      </q-tab-panels>
    </div>

  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { ref } from "vue";
import { Options } from "vue-class-component";
import Query from "pages/questionnaire/Query.vue";
import Detail from "pages/questionnaire/Detail.vue";
import View from "pages/questionnaire/View.vue";

@Options({
  components: {
    "c-questionnaire-query": Query,
    "c-questionnaire-view": View,
    "c-questionnaire-detail": Detail,
  },
})
export default class Index extends ComponentBase {

  isLeftDrawerShow = false;
  tab = ref("index");

  async mounted() {
    //
  }

}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
