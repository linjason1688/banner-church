<template>
  <q-btn @click="historyBack" v-bind="$attrs" color="grey">
    <q-icon name="arrow_back_ios" size="xs"></q-icon>
    <slot>返回</slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";

@Options({})
export default class BtnHistoryBack extends ButtonBase {
  historyBack() {
    this.$router.go(-1);
  }
}
</script>
