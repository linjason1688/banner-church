<template>
  <q-list padding>
    <q-expansion-item
      v-for="node in $privilegeNode.nodes"
      :key="node.functionId"
      :label="node.name"
      :default-opened="node.functionId === $activeParentFunctionId"
      expand-separator
      icon="layers"
    >
      <q-item
        v-for="subNode in node.nodes"
        :key="subNode.functionId"
        :to="{
          name: subNode.functionId,
          params: { $fnId: subNode.functionId, $fnName: subNode.name },
        }"
        class="q-pl-md"
        :class="{ 'text-primary': subNode.functionId === $activeFunctionId }"
        v-ripple
        clickable
        @click="handleMenuItemClicked(subNode)"
      >
        <q-item-section avatar>
          <q-icon :name="'dashboard'" class="invisible" />
        </q-item-section>
        <q-item-section avatar>
          {{ subNode.name }}
        </q-item-section>
        <q-tooltip :delay="1500" :offset="[0, 0]" anchor="bottom left" self="top left">
          {{ subNode.name }}
        </q-tooltip>
      </q-item>
    </q-expansion-item>
  </q-list>

  <q-list>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/profile.svg" />
      </q-item-section>
      <q-item-section>基本資料</q-item-section>
    </q-item>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/family.svg" />
      </q-item-section>
      <q-item-section>家庭狀況</q-item-section>
    </q-item>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/chargeback.svg" />
      </q-item-section>
      <q-item-section>退款費用專用帳戶</q-item-section>
    </q-item>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/other.svg" />
      </q-item-section>
      <q-item-section>其他資訊</q-item-section>
    </q-item>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/working-group.svg" />
      </q-item-section>
      <q-item-section>事工團紀錄</q-item-section>
    </q-item>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/class.svg" />
      </q-item-section>
      <q-item-section>課程歷程</q-item-section>
    </q-item>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/shepherd.svg" />
      </q-item-section>
      <q-item-section>牧養歷程</q-item-section>
    </q-item>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/group.svg" />
      </q-item-section>
      <q-item-section>小組聚會歷程</q-item-section>
    </q-item>
    <q-item clickable v-ripple>
      <q-item-section avatar>
        <q-icon name="img:/img/download.svg" />
      </q-item-section>
      <q-item-section>資源下載區</q-item-section>
    </q-item>
    <q-item clickable v-ripple :to="{ name: 'CR0100' }">
      <q-item-section avatar>
        <q-icon name="img:/img/other.svg" />
      </q-item-section>
      <q-item-section>角色管理</q-item-section>
    </q-item>
    <q-item clickable v-ripple :to="{ name: 'CR0104' }">
      <q-item-section avatar>
        <q-icon name="img:/img/other.svg" />
      </q-item-section>
      <q-item-section>角色權限設定</q-item-section>
    </q-item>
  </q-list>

  <!-- NOTE: 顏色要自己控，不能用 selected -->
  <!--
      <q-tree
        :nodes="menuTree"
        v-model:selected="currentMenuId"
        selected-color="primary"
        node-key="id"
        label-key="name"
        children-key="nodes"
        class="q-mx-md"
        no-connectors
        default-expand-all
        accordion
      >
        <template v-slot:default-header="prop">
          <div class="full-width row items-center">
            <div class="col-auto">
              <q-icon name="dashboard" class="q-mb-xs q-mr-md" />
            </div>
            <div class="col">
              {{ prop.node.name }}
            </div>
          </div>
        </template>
      </q-tree>
      -->
</template>

<script lang="ts">
/**
 * NOTE:
 * https://github.com/vuejs/vue-class-component/issues/406
 * https://davidjamesherzog.github.io/2020/12/30/vue-typescript-decorators/
 */

/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { ComponentBase } from "src/components/ComponentBase";
import { MyPrivilegeNodeView } from "src/data/dto";
import { MyLocalStorage, Sleep } from "src/util";
/* eslint-enable */

@Options({})
export default class Menu extends ComponentBase {
  // ========== props ==========

  // ========== data ==========
  activeNode = {
    functionId: "",
    parentFunctionId: "",
  };

  // ========== computed ==========
  get $privilegeNode() {
    return this.$appStore.getters.privilegeNode;
  }

  get $activeParentFunctionId() {
    return this.activeNode.parentFunctionId;
  }

  get $activeFunctionId() {
    return this.activeNode.functionId;
  }

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  created() {
    this.activeNode = MyLocalStorage.activeNode.getItem() || {
      functionId: "",
      parentFunctionId: "",
    };
  }

  mounted() {
    //
  }

  // ========== methods ==========

  // ========== listening ==========
  handleMenuItemClicked(node: MyPrivilegeNodeView) {
    this.activeNode.functionId = node.functionId;
    this.activeNode.parentFunctionId = node.parentFunctionId;
  }
  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
