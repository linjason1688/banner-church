<template>
  <div class="col">
    <div class="flex column items-center">
      <slot></slot>
      <div v-if="item.parentNode" class="border" style="height:16px"></div>
      <div class="relative-position" style="width:fit-content">
        <q-btn color="indigo" :outline="item != value" @click="value == item ? item.expand = !item.expand : select(item)">{{
          item.name
        }}</q-btn>
      </div>
      <div v-if="item.children?.length > 1 && item.expand" class="border" style="height:16px"></div>
    </div>
    <div class="row" v-if="item.expand">
      <OrgChart v-for="child, i in item.children" :key="child.id" :item="child" :value="value" @select="select"
        @add="add" @remove="remove">
        <template v-if="item.children.length > 1">
          <div v-if="i == 0" class="border" style="margin-left:50%;width:50%"></div>
          <div v-else-if="i == item.children.length - 1" class="border" style="margin-right:50%;width:50%">
          </div>
          <div v-else class="border" style="width:100%"></div>
        </template>
      </OrgChart>
    </div>
  </div>
</template>

<script lang="ts">
import { Emit, Prop } from "vue-property-decorator";
import { ElementaryBase } from "./ElementaryBase";
import {PastoralView} from "src/api/feature";

export interface Org extends PastoralView {
  expand: boolean;
  parentNode: Org | undefined;
  children: Org[];
}
export function Org2Tree(arr: Org[] = [], maxIter = 99999): Org {
  const rows = arr.slice().sort((a, b) => a.upperPastoralId - b.upperPastoralId);
  for (let row of rows) row.children = [];
  const root = rows.shift() || {} as Org;
  const dict: { [key: string]: Org } = { [root.id]: root };
  for (let row of rows)
    if (!row.upperPastoralId) root.children.push(dict[row.id] = row);
  while (maxIter-- > 0) {
    const row = rows.shift();
    if (!row) break;
    if (row.id in dict) continue;
    if (row?.upperPastoralId in dict) {
      dict[row.id] = row;
      row.parentNode = dict[row?.upperPastoralId];
      dict[row?.upperPastoralId].children.push(row);
    } else rows.push(row);
  }
  for (let row of rows) root.children.push(row);
  return root;
}
export default class OrgChart extends ElementaryBase {
  text: string = "";
  @Prop()
  item!: Org;
  @Prop()
  value!: Org;
  @Emit("add")
  add(e: unknown) { return e }
  @Emit("select")
  select(item: Org) { return item; }
  @Emit("remove")
  remove(item: Org) { return item; }
}
</script>

<style scoped>
.border {
  border: 1px solid #3764AC;
}
</style>
