<template>
  <q-input
    v-bind="$attrs"
    input-class="cursor-pointer"
    placeholder="hh:mm"
    v-bind:[attr.rounded]="true"
    v-bind:[attr.dense]="true"
    outlined
  >
    <q-menu ref="picker" anchor="bottom right" self="top right">
      <q-card>
        <q-time @update:model-value="handlePicked" minimal></q-time>
      </q-card>
    </q-menu>
    <template v-slot:append>
      <q-btn icon="schedule" dense flat round />
    </template>
  </q-input>
</template>

<script lang="ts">
// Component
import { QMenu } from "quasar";
import { Options } from "vue-class-component";
import { Emit, Prop, Ref } from "vue-property-decorator";
import { FormBase } from "./FormBase";

@Options({})
export default class FormTimePicker extends FormBase {
  /**
   * role search: 查詢列 / edit: 一般輸入
   */
  @Prop({ type: String, default: () => "" })
  protected readonly role!: string;

  @Prop({ type: String, default: () => "" })
  value!: string;

  @Ref("picker")
  readonly pickerRef!: QMenu;

  created() {
    this.switchByRole("FormTimePicker", this.role);
  }

  @Emit("update:modelValue")
  handlePicked(e: Event) {
    this.pickerRef.hide();
    return e;
  }
}
</script>
