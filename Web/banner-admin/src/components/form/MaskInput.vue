<template>
  <q-input
    v-bind="$attrs"
    :value="displayValue"
    @input="handleInputProxy($event)"
    @focus="isFocused = true"
    @blur="isFocused = false"
  >
    <slot></slot>
  </q-input>
</template>

<script lang="ts">
// Component
import { isFunction } from "lodash";
import { Options } from "vue-class-component";
import { Emit, Prop } from "vue-property-decorator";
import { FormBase } from "./FormBase";

// eslint-disable-next-line no-unused-vars
type Formatter = (v: unknown) => string;

function defaultFormatter(v: unknown) {
  return v;
}

/**
 * current component is not working correctly
 */
@Options({})
export default class MaskInput extends FormBase {
  /**
   * role search: 查詢列 / edit: 一般輸入
   */
  @Prop({ type: String, default: () => "" })
  protected readonly role!: string;

  //
  @Prop({ default: () => undefined })
  private value: unknown;

  @Prop({ default: () => defaultFormatter })
  private formatter!: Formatter;
  private isFocused = false;

  get displayValue() {
    if (this.isFocused) {
      return this.value;
    }
    return this.formatter(this.value);
  }

  created() {
    //
    if (!this.formatter || !isFunction(this.formatter)) {
      console.log(this.formatter);
      throw new Error("MaskInput's formatter should be a funtion");
    }
  }

  handleInputProxy(e: unknown) {
    if (this.isFocused) {
      return this.handleInput(e);
    } else {
      return this.handleInput(this.value);
    }
  }

  @Emit("input")
  handleInput(e: unknown) {
    return e;
  }
}
</script>
