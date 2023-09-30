<template>
  <q-page class="q-pa-md">
    <div class="row items-center">
      <div class="col">
        <c-page-title></c-page-title>
      </div>
      <div class="col-auto">
        <c-btn-history-back class="q-mr-md" />
        <q-btn @click="updatePrivilegeAsync" label="儲存" color="primary" />
      </div>
    </div>
    <div class="row q-ma-md">
      <div class="col-6 offset-3">
        <c-select
          v-model="selectedRole"
          @update:model-value="handleRoleChangedAsync"
          :options="roles"
          option-label="name"
          option-value="id"
          outlined
        ></c-select>
      </div>
    </div>

    <div class="row">
      <div class="col-6 offset-3">
        <!--TODO: privileges-->
        <q-markup-table class="p-table">
          <thead>
            <th>選單名稱</th>
            <th>檢視</th>
            <th>新增/編輯</th>
            <th>刪除</th>
            <th>下載</th>
            <th>上傳</th>
          </thead>
          <tbody>
            <tr v-for="item in privileges" :key="item.id">
              <td>{{ item.name }}</td>
              <td><q-checkbox v-model="item.viewGranted"></q-checkbox></td>
              <td><q-checkbox v-model="item.modifyGranted"></q-checkbox></td>
              <td><q-checkbox v-model="item.deleteGranted"></q-checkbox></td>
              <td><q-checkbox v-model="item.downloadGranted"></q-checkbox></td>
              <td><q-checkbox v-model="item.uploadGranted"></q-checkbox></td>
            </tr>
          </tbody>
        </q-markup-table>
      </div>
    </div>
  </q-page>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { DetailComponentBase } from "src/components/DetailComponentBase";
import { keys } from "lodash";
import { PrivilegeView } from "src/api/management";
/* eslint-enable */

import { QTree } from "quasar";

import { PrivilegeNodeView, RoleView } from "src/api/management";
import Enumerable from "linq";
import { WithLoading } from "src/util/TsDecorators";
import { BusinessError } from "src/data/errors";

interface NodeView extends PrivilegeNodeView {
  //
  modified?: boolean;
  parent?: NodeView;
}

@Options({
  meta() {
    return {
      title: "Role Privilege",
    };
  },

  components: {},
})
export default class RolePrivilegePage extends DetailComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  selectedRole: RoleView | null = null;

  roles: Array<RoleView> = [];
  // 全部攤平
  privileges: Array<PrivilegeNodeView> = [];

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========
  @Ref("tree")
  readonly treeRef!: QTree;

  // ========== hook ==========
  async mounted() {
    await this.fetchRolesAsync();

    if (this.roles.length) {
      this.selectedRole = this.roles[0];
      await this.handleRoleChangedAsync(this.selectedRole);
    }
  }

  @WithLoading()
  async fetchRolesAsync() {
    const res = await this.apis.management.role.fetchAllAsync({});

    this.roles = res.data;
  }

  @WithLoading()
  async fetchRoleAuthPrivildegsAsync() {
    await this.$nextTick();

    if (this.treeRef) {
      this.treeRef.expandAll();
    }
  }

  @WithLoading()
  async handleRoleChangedAsync(role: RoleView) {
    const res = await this.apis.management.privilege.fetchRolePrivilegeAsync({
      roleId: role.id,
    });

    this.privileges = res.data;
  }

  // ========== methods ==========

  @WithLoading()
  async updatePrivilegeAsync() {
    if (!this.selectedRole) {
      throw new BusinessError("請選擇角色");
    }

    // mapping
    const itmes = this.privileges.map((it) => {
      return {
        privilegeId: it.id,
        functionId: it.functionId,
        viewGranted: it.viewGranted,
        enable: true,
        modifyGranted: it.modifyGranted,
        deleteGranted: it.deleteGranted,
        uploadGranted: it.uploadGranted,
        downloadGranted: it.downloadGranted,
      };
    });

    //
    await this.apis.management.privilege.authRolePrivilegeAsync({
      roleId: this.selectedRole?.id,
      privilegeAuthItems: itmes,
    });

    await this.fetchRoleAuthPrivildegsAsync();

    this.showSuccessNotify("已儲存");
  }

  private flattenNodes(nodes: NodeView[]): NodeView[] {
    return Enumerable.from(nodes)
      .select((node: NodeView) => {
        if (node.nodes && node.nodes.length) {
          node.nodes.forEach((it: NodeView) => {
            it.parent = node;
          });
          return this.flattenNodes(node.nodes as NodeView[]).concat(node);
        }
        return [node];
      })
      .selectMany((ary) => ary)
      .toArray();
  }

  private retrieveAllParentIds(node: NodeView | undefined): string[] {
    if (!node) {
      return [];
    }
    const keys = [node.id];

    return keys.concat(...this.retrieveAllParentIds(node.parent));
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped>
.p-table {
  thead {
    th {
      width: 300px;
    }
    :first-child {
      width: 600px;
    }
  }
}
</style>
