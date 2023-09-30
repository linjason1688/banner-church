<template>
  <div class="row">
    <div class="col-12 col-md-2">
      <div class="row justify-center" style="height: 100%">
        <div class="col-auto">
          <p class="q-px-sm q-ma-none c-content-body">志願序</p>
        </div>
        <div class="col-auto">
          <p class="q-px-sm q-pb-md c-content-body">{{ sequence }}{{ sequence == "1" ? "*" : "" }}</p>
        </div>
      </div>
    </div>
    <div class="col-12 col-md-3">
      <p class="q-px-sm q-ma-none c-content-body">星期</p>
      <c-select v-model="syncedDay" class="q-px-sm q-mb-md" dense
                emit-value map-options
                outlined
                :options="weekList" />
    </div>
    <div class="col-12 col-md-3">
      <p class="q-px-sm q-ma-none c-content-body">時段</p>
      <c-select v-model="syncedTime" class="q-px-sm q-mb-md" dense
                emit-value map-options
                outlined
                :options="timeList" />
    </div>
    <div class="col-12 col-md-4" v-if="meetupCategory=='offline'">
      <p class="q-px-sm q-ma-none c-content-body">堂點</p>
      <c-form-organization v-model="syncedChurch" class="q-px-sm q-mb-md" dense
                           emit-value map-options
                           outlined />
    </div>
  </div>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { Prop, PropSync } from "vue-property-decorator";
import { FormGroupBase } from "./FormGroupBase";
import FormOrganization from "components/business/FormOrganization.vue";

export class will {
  day = "";//星期
  time = "";//時段
  church = "";//堂點
}

@Options({
  components: {
    "c-form-organization": FormOrganization,
  },
})
export default class FormGroupMeetup extends FormGroupBase {

  @Prop({ type: String })
  sequence!: string;

  @Prop({ type: String })
  meetupCategory!: string;

  @PropSync("day", { type: String })
  syncedDay!: string;

  @PropSync("time", { type: String })
  syncedTime!: string;

  @PropSync("church", { type: String })
  syncedChurch!: string;

  weekList = [
    {
      label: "星期一",
      value: "1",
    },
    {
      label: "星期二",
      value: "2",
    },
    {
      label: "星期三",
      value: "3",
    },
    {
      label: "星期四",
      value: "4",
    },
    {
      label: "星期五",
      value: "5",
    },
    {
      label: "星期六",
      value: "6",
    },
    {
      label: "星期日",
      value: "7",
    },
  ];
  timeList = [
    {
      label: "上午",
      value: "1",
    },
    {
      label: "下午",
      value: "2",
    },
  ];

  created() {
    //
  }
}
</script>
