<template>
  <div>
    <q-dialog v-bind="$attrs" v-model="syncedDialog">
      <q-card class="c-alert-card">
        <q-card-section v-if="title != undefined" class="row flex-center q-pa-lg">
          <div class="c-heading-h4 c-text-color-100 c-alert-underline">{{ title }}</div>
        </q-card-section>

        <q-card-section class="row flex-center q-pa-lg">
          <div class="c-content-body text-black q-px-xl">{{ content }}</div>
        </q-card-section>

        <q-card-actions class="row flex-center q-pa-lg">
          <c-btn
            :label="btnLabel"
            rounded
            unelevated
            padding="sm md"
            class="c-text-color-white c-primary-background-500 c-button-lg"
            v-close-popup
            @click="onClickBtn()"
          ></c-btn>
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop, PropSync, Emit } from "vue-property-decorator";

export default class DialogAlert extends ComponentBase {
  @PropSync("dialog", { type: Boolean })
  syncedDialog!: boolean;

  @Prop({ type: String })
  title!: string;

  @Prop({ type: String })
  content!: string;

  @Prop({ type: String, default: "OK" })
  btnLabel!: string;

  @Emit("click")
  onClickBtn() {
    return true;
  }

  alert = true;

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
