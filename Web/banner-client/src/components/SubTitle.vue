<template>
  <div>
    <div class="c-content-title q-mb-md">
      <div class="q-mb-xs">
        <q-avatar square class="q-mr-md">
          <img src="/img/stroke.svg" />
        </q-avatar>
        <span class="c-primary-color-500 c-content-title inline-block">
          {{ title }}
        </span>
        <div v-if="requiredMark == '1'" class="inline-block app-required q-ml-xs">*</div>
      </div>
      <q-separator size="2px" class="c-primary-background-500" />
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class SubTitle extends ComponentBase {
  @Prop({ type: String })
  title!: string;

  @Prop({ type: String })
  requiredMark!: string;

  async mounted() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import '../css/quasar.variables.scss';

.q-avatar {
  width: 10px !important;
}

</style>
