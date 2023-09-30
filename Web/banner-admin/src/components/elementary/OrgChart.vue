<template>
  <div class="row items-center" v-bind="$attrs">
    <slot></slot>
    <div v-if="item.parentNode" class="border" style="width:16px"></div>
    <div class="relative-position" style="width:fit-content">
      <q-input v-if="item.isInput" outlined dense v-model="item.name" placeholder="新組織" />
      <q-btn v-else :color="disabled ? 'grey' : 'indigo'" :outline="!disabled" class="q-pa-md q-my-xs"
        style="white-space:pre" @click="select(item)">{{ item.name }}</q-btn>
      <div v-if="editable && !disabled" style="position:absolute;top:-10px;right:-10px;">
        <q-btn size="xs" class="bg-white q-mr-xs" round outline color="red" icon="remove" @click="remove(item)"></q-btn>
        <q-btn size="xs" class="bg-white" round outline color="blue" icon="add" @click="add(item)"></q-btn>
      </div>
    </div>
    <div v-if="item.children?.length > 1" class="border" style="width:16px"></div>
    <div class="column justify-center">
      <OrgChart v-for="child, i in item.children" :key="i" :item="child" :value="value" :editable="editable"
        :level="level + 1" @select="select" @add="add" @remove="remove">
        <div v-if="item.children.length > 1" class="self-stretch column">
          <div class="col" v-if="i == 0"></div>
          <div class="col border"></div>
          <div class="col" v-if="i == item.children.length - 1"></div>
        </div>
      </OrgChart>
    </div>
  </div>
</template>
  
<script lang="ts">
import { Emit, Prop } from "vue-property-decorator";
import { ElementaryBase } from "./ElementaryBase";
import { OrganizationView } from "src/api/feature";

export interface Org extends OrganizationView {
  isInput?: false;
  parentNode: Org;
  children: Org[];
}

export function Org2Tree(arr: Org[], maxIter = 99999): Org {
  const rows = arr.slice().sort((a, b) => b.upperOrganizationId - a.upperOrganizationId || b.id - a.id);
  for (let row of rows) row.children = [];
  const root = rows.pop() || {} as Org;
  const dict = { [root.id]: root };
  for (let row of rows) if (!row.upperOrganizationId) root.children.push(dict[row.id] = row);
  while (maxIter-- > 0) {
    const row = rows.shift();
    if (!row) break;
    if (row.id in dict) continue;
    if (row?.upperOrganizationId in dict) {
      dict[row.id] = row;
      row.parentNode = dict[row?.upperOrganizationId];
      dict[row.upperOrganizationId].children.push(row);
    } else rows.push(row);
  }
  for (let row of rows) {
    root.children.push(row);
    row.parentNode = root;
  }
  return root;
}
export default class OrgChart extends ElementaryBase {
  @Prop() item!: Org;
  @Prop() value!: Org;
  @Prop() editable!: boolean;
  @Prop({ default: 0 }) level!: number;
  @Emit("add") add(item: Org) { return item; }
  @Emit("select") select(item: Org) { return item; }
  @Emit("remove") remove(item: Org) { return item; }
  get disabled() {
    return this.editable && this.level < 2
  }
}
</script>
  
<style scoped>
.border {
  border: 1px solid #3764AC;
}
</style>
  