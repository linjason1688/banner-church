<template>
  <q-input input-class="cursor-pointer" :placeholder="isRange ? format + splitter + format : format"
    :model-value="isRange ? (value.from || format) + splitter + (value.to || format) : value"
    @update:model-value="isRange ? { from: $event.split(splitter).shift(), to: $event.split(splitter).pop() } : $event">
    <q-menu ref="picker" anchor="bottom right" self="top right">
      <q-card>
        <template v-if="isTime">
          <q-time :model-value="isRange ? value.from : value"
            @update:model-value="handlePicked(isRange ? { from: $event, to: '' } : $event)" minimal></q-time>
          <q-time v-if="isRange" :model-value="value.to"
            @update:model-value="handlePicked(isRange ? { from: value.from, to: $event } : $event)" minimal></q-time>
        </template>
        <q-date v-else :range="range" :model-value="value" @update:model-value="handlePicked" minimal
          :options="dateFilter" :mask="format"></q-date>
      </q-card>
    </q-menu>
    <template v-slot:append>
      <q-btn :icon="isTime?'schedule':'event_available'" dense flat round />
      <div v-if="hasToolTip">
        <q-icon name="info" color="secondary" />
        <q-tooltip anchor="bottom right" self="top right" :offset="[12, 16]">
          <slot name="tool-tip"></slot>
        </q-tooltip>
      </div>
    </template>
  </q-input>
</template>

<script lang="ts">
// Component
import { QMenu } from "quasar";
import { MyDateTime } from "src/util";
import { Options } from "vue-class-component";
import { Emit, Prop, Ref } from "vue-property-decorator";
import { FormBase } from "./FormBase";
interface DateRange {
  from: string;
  to: string;
}
@Options({})
export default class FormDatePicker extends FormBase {
  /**
   * role search: 查詢列 / edit: 一般輸入
   */
  @Prop({ type: String, default: "" })
  protected readonly role!: string;

  @Prop({ default: "" })
  value!: DateRange;

  @Prop({ default: "2000-01-01" })
  min!: string;

  @Prop({ default: "3000-01-01" })
  max!: string;

  @Prop({ default: false })
  range!: boolean;

  @Prop({ default: false })
  time!: boolean;

  get isRange() {
    return this.range !== false;
  }
  get isTime() {
    return this.time !== false;
  }

  get format() {
    return this.isTime ? "hh:mm" : "YYYY-MM-DD";
  }

  splitter = " to ";

  @Ref("picker")
  readonly pickerRef!: QMenu;

  get hasToolTip() {
    return !!this.$slots["tool-tip"];
  }

  created() {
    this.switchByRole("FormDatePicker", this.role);
  }

  mounted() {
    //
  }

  dateFilter(o: string) {
    const option = new MyDateTime(o);
    const greaterThanMin = option.diff(new MyDateTime(this.min).datePart).milliseconds >= 0;
    const smallerThanMax = new MyDateTime(this.max).diff(option.datePart).milliseconds >= 0;
    return greaterThanMin && smallerThanMax;
  }
  @Emit("update:modelValue")
  handlePicked(e: Event) {
    if (!this.isRange || (this.value.from && this.value.to)) this.pickerRef.hide();
    return e;
  }
}
</script>
