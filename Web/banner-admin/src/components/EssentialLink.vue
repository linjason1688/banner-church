<template>
  <q-list v-if="sticky" style="border-top:1px solid #D2D3D4; border-bottom:1px solid #D2D3D4">
    <div class="text-bold text-grey q-mt-md q-ml-lg">{{ title }}</div>
    <EssentialLink v-for="child in children" :key="child" v-bind="child" :level="(level || 0) + 1" />
  </q-list>
  <q-expansion-item v-else-if="children?.length > 0" v-model="expanded" expand-separator :icon="icon" :label="title"
    default-closed :header-class="expanded ? 'bg-grey-2' : ''">
    <template v-slot:header>
      <div class="flex items-center no-wrap text-no-wrap">
        <q-icon name="fiber_manual_record" style="color: #d9d9d9" size="1.7em" class="q-mr-xs" />
        {{ title }}
      </div>
    </template>
    <q-list>
      <EssentialLink v-for="child in children" :key="child" v-bind="child" :level="(level || 0) + 1" />
    </q-list>
  </q-expansion-item>
  <q-item v-else clickable v-ripple :to="link" active-class="c-active-item" class="c-item">
    <q-item-section class="q-px-md">{{ title }}</q-item-section>
  </q-item>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class EssentialLink extends ComponentBase {
  @Prop({ default: 0 }) level!: 0;
  @Prop() title!: "";
  @Prop() link!: "";
  @Prop() icon!: "";
  @Prop() sticky!: false;
  @Prop() children!: [];
  expanded = false;
  get isParent() {
    return this.children?.length > 0;
  }
}
</script>

<style>
.q-item {
  border-radius: 0px 8px 8px 0px !important;
}

.c-active-item .q-item__section {
  border-left: 4px solid #006c93 !important;
}

.c-item .q-item__section {
  border-left: 2px solid #d9d9d9;
  margin-left: 10px;
}
</style>
