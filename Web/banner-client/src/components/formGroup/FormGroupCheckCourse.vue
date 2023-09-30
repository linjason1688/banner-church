<template>
  <c-form-card class="q-mb-sm c-card">
    <c-display-field label="課程名稱">
      {{ syncedCartItem.courseName }}
    </c-display-field>
    <c-display-field label="開課堂點">
      {{ syncedCartItem.organizationName }}
    </c-display-field>
    <c-display-field label="課程日期與地點">
      <div v-for="item in syncedCartItem.courseTimeSchedules" :key="item.id" class="q-mb-sm">
        日期：{{ item.classDay }} {{ item.classTimeS }} ~ {{ item.classTimeE }}
        <br />
        地點：{{ item.place }}
      </div>
    </c-display-field>
    <c-display-field label="特殊需求" v-if="syncedCartItem.isInPlace">
      <q-checkbox
        dense
        class="q-mr-md"
        v-model="syncedCartItem.isViggieHelp"
        true-value="1"
        false-value="0"
        label="素食"
      ></q-checkbox>
      <q-checkbox
        dense
        class="q-mr-md"
        v-model="syncedCartItem.isMoveHelp"
        true-value="1"
        false-value="0"
        label="行動不便"
      ></q-checkbox>
      <q-checkbox
        dense
        class="q-mr-md"
        v-model="syncedCartItem.isPregnancyHelp"
        true-value="1"
        false-value="0"
        label="孕婦"
      ></q-checkbox>
      <q-checkbox
        dense
        class="q-mr-md"
        v-model="syncedCartItem.isOthersHelp"
        true-value="1"
        false-value="0"
        label="其他"
      ></q-checkbox>
      <q-checkbox
        dense
        class="q-mr-md"
        v-model="syncedCartItem.isCoupleSameClassHelp"
        true-value="1"
        false-value="0"
        label="夫妻同班"
      ></q-checkbox>
      <c-input
        v-if="syncedCartItem.isOthersHelp == '1'"
        placeholder="其他需求"
        v-model="syncedCartItem.isOthersHelpInformations"
        class="q-my-sm"
      ></c-input>
      <c-input
        v-if="syncedCartItem.isCoupleSameClassHelp == '1'"
        placeholder="配偶姓名"
        v-model="syncedCartItem.isCoupleSameClassInformations"
        class="q-my-sm"
      ></c-input>
    </c-display-field>
  </c-form-card>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { FormGroupBase } from "./FormGroupBase";
import { Prop, PropSync } from "vue-property-decorator";
import FormOrganization from "components/business/FormOrganization.vue";
import { CourseTimeScheduleView } from "src/api/feature/api";
import DisplayField from "pages/shopping-cart/_DisplayField.vue";

interface SelectOption {
  name: string;
  value: string;
}

class Cart {
  courseId: number = 0;
  cartItemId: number = 0;
  courseName?: string;
  organizationName?: string;
  courseTimeSchedules?: Array<CourseTimeScheduleView>;
  join1?: string;
  join2?: string;
  join3?: string;
  price?: number;
  isInPlace?: boolean;
  isViggieHelp?: string;
  isMoveHelp?: string;
  isPregnancyHelp?: string;
  isOthersHelp?: string;
  isOthersHelpInformations?: string;
  isCoupleSameClassHelp?: string;
  isCoupleSameClassInformations?: string;
}

@Options({
  components: {
    "c-form-organization": FormOrganization,
    "c-display-field": DisplayField,
  },
})
export default class FormGroupCheckCourse extends FormGroupBase {
  specialRequirement = [];

  @Prop({ default: Array<SelectOption>() }) joinList!: Array<SelectOption>;

  @PropSync("cartItem", { type: Cart }) syncedCartItem!: Cart;
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";

.c-card {
  background: #ffffff;
  border: 1px solid rgba(12, 49, 118, 0.1) !important;
  box-shadow: 0px 0px 2px rgba(0, 0, 0, 0.2), 0px 5px 10px rgba(151, 153, 158, 0.12) !important;
  border-radius: 20px !important;
}
</style>
