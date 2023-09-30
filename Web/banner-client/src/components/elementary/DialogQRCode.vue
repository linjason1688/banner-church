<template>
  <q-dialog v-model="syncedShow">
    <q-card>
      <q-card-section class="row items-center q-pb-none">
        <div class="text-h6">掃描QRCode</div>
        <q-space />
        <q-btn icon="close" flat round dense v-close-popup />
      </q-card-section>

      <q-card-section class="row flex-center">
        <q-img :src="qrcodeURL" style="height: 120px; width: 120px"></q-img>
      </q-card-section>

      <q-card-section class="row flex-center q-pt-none">
        <q-input outlined v-model="qrcodeURL" readonly>
          <template v-slot:append>
            <q-btn round dense flat icon="content_copy" @click="copyURLToClipBoard" />
          </template>
        </q-input>
      </q-card-section>
    </q-card>
  </q-dialog>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop, PropSync } from "vue-property-decorator";
import { copyToClipboard } from "quasar";

export default class DialogQRCode extends ComponentBase {
  @Prop({ type: String })
  qrcodeURL!: string;

  @PropSync("show", { type: Boolean })
  syncedShow!: boolean;

  async mounted() {
    //
  }

  copyURLToClipBoard() {
    copyToClipboard(this.qrcodeURL)
      .then(() => {
        // success!
        this.showSuccessNotify("已複製到剪貼簿");
      })
      .catch(() => {
        // fail
      });
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
