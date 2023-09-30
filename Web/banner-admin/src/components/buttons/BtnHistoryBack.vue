<template>
  <q-btn @click="historyBack" v-bind="$attrs" rounded outline color="primary" icon="reply" unelevated :class="style">
    <slot>返回</slot>
  </q-btn>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { ButtonBase } from "./ButtonBase";
import { Prop } from "vue-property-decorator";

@Options({})
export default class BtnHistoryBack extends ButtonBase {
  historyBack() {
    this.$router.go(-1);
  }

  @Prop({ type: Boolean })
  icon!: boolean;

  @Prop({ type: Boolean })
  outlined!: boolean;

  get style() {
    return [this.outlined ? "c-btn-outlined" : "c-btn-normal"]
  }
}
</script>