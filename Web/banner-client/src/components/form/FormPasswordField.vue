<template>
  <q-input
    ref="field"
    v-bind="$attrs"
    v-bind:[attr.rounded]="true"
    v-bind:[attr.dense]="true"
    class="q-pb-md"
    :label="label"
    stack-label
    :type="isPwd ? 'password' : 'text'"
    v-model="password"
    :rules="[requiredRule, lengthRule, alphabetRule]"
    lazy-rules="ondemand"
  >
    <template v-slot:append>
      <q-icon :name="isPwd ? 'visibility_off' : 'visibility'" class="cursor-pointer" @click="isPwd = !isPwd" />
    </template>
  </q-input>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormBase } from "./FormBase";
import { Prop } from "vue-property-decorator";

@Options({})
export default class FormPasswordField extends FormBase {
  password = "";
  isPwd = "password";

  @Prop({ type: String })
  label!: string;

  @Prop({ type: String, default: () => "" })
  protected readonly role!: string;

  created() {
    this.switchByRole("FormInput", this.role);
  }

  requiredRule(value: string) {
    return !!value || "請輸入密碼";
  }
  lengthRule(value: string) {
    return (value.length >= 8 && value.length <= 12) || "請輸入密碼8-12位英數字";
  }
  alphabetRule(value: string) {
    return /^\w+$/.test(value) || "密碼只允許英數字";
  }
}
</script>
