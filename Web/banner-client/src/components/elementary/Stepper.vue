<template>
  <div v-bind="$attrs" class="row rounded-borders shadow-1">
    <div v-for="step, si in steps" :key="si" class="col flex flex-center q-py-md relative-position overflow-hidden"
      :class="si == stepIndex ? 'bg-primary text-white' : 'bg-white'">
      <template v-if="si > 0">
        <div class="shadow-1" :class="si == stepIndex + 1 ? 'bg-primary' : 'bg-white'"
          style="position:absolute;top:3px;left:-23px;padding:23px;transform-origin:center; transform:rotate(45deg)">
        </div>
        <div class="q-px-md"></div>
      </template>
      <img v-if="si < stepIndex" src="/img/step-check.svg" alt="" class="q-mr-sm" />
      <div v-else-if="step.src" :style="{ maskImage: 'url(' + step.src + ')' }" alt="" class="q-mr-sm q-pa-sm"
        :class="si == stepIndex ? 'bg-white' : 'bg-grey-10'"></div>
      <b>{{ step.name }}</b>
    </div>
  </div>
</template>

<script lang="ts">
import { Prop } from "vue-property-decorator";
import { ElementaryBase } from "./ElementaryBase";

interface Step {
  name: string;
  src: string;
  tab: string;
}
export default class Stepper extends ElementaryBase {
  @Prop()
  stepIndex!: number;
  @Prop()
  steps!: Step[];
}
</script>
