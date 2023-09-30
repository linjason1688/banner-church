<template>
  <q-page>
    <q-breadcrumbs class="q-ma-md">
      <q-breadcrumbs-el v-for="breadcrumb in ['系統管理', '牧養組織與職分管理', '編輯組織及職分']" :key="breadcrumb" :label="breadcrumb" />
    </q-breadcrumbs>
    <div v-if="editing" class="flex">
      <q-space></q-space>
      <div class="bg-grey-2 shadow-1 rounded-borders q-px-md q-py-sm">
        <q-btn class="block q-mb-sm" rounded color="indigo" @click="save">儲存</q-btn>
        <q-btn class="bg-white block" rounded color="indigo" outline @click="cancel">取消</q-btn>
      </div>
    </div>
    <div v-else class="flex bg-grey-2 text-indigo q-px-md q-py-sm q-ma-md items-center">
      <span>前次變更時間：{{ lastModify.dateUpdate || '' }}</span>
      <q-separator vertical spaced="lg" />
      <span>變更者：{{ lastModify.userUpdate || '' }}</span>
      <q-space></q-space>
      <q-separator vertical spaced="md" />
      <q-btn class="q-ml-sm" color="indigo" rounded @click="editing = true">編輯組織及職分</q-btn>
      <q-btn class="q-ml-sm" color="indigo" rounded @click="exportExcel">匯出</q-btn>
    </div>
    <c-row>
      <div class="col-12 flex flex-center" :class="editing ? 'col-sm-5' : ''">
        <div>
          <template v-for="org, i in orgs" :key="org.id">
            <div class="flex items-center">
              <q-btn color="grey" outline style="width:80px">{{ org.name || '　' }}</q-btn>
              <template v-if="org.title">
                <div style="border:1px solid #E0E1E1;width:50px"></div>
                <q-btn color="grey" outline style="width:80px">{{ org.title }}</q-btn>
              </template>
            </div>
            <div v-if="i < orgs.length - 1" class="flex">
              <div style="border:1px solid #E0E1E1;width:0;height:20px;margin-left:40px;"></div>
              <div v-if="org.title" style="border:1px solid #E0E1E1;width:0;height:20px;margin-left:130px;"></div>
            </div>
          </template>
        </div>
      </div>
      <div v-if="editing" class="col-12 col-sm-7">
        <q-tabs v-model="tab" class="full-width text-cyan-8 q-mb-md" color="cyan">
          <q-tab name="使用中" label="使用中" />
          <q-tab name="停用名單" label="停用名單" />
        </q-tabs>
        <table class="ministry-table full-width q-mb-md">
          <thead>
            <tr>
              <th>牧養組織名稱</th>
              <th>職分名稱</th>
              <th>上層組織</th>
              <th>狀態</th>
              <th>操作</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="org in orgs" :key="org.id" :class="org.id === undefined ? 'editing' : ''">
              <template v-if="org.id === undefined || org.editing">
                <td><q-input dense style="width:50px;margin:auto" v-model="org.name" placeholder="組織" /></td>
                <td><q-input dense style="width:50px;margin:auto" v-model="org.title" placeholder="職分" /></td>
                <td><q-select dense style="width:60px;margin:auto"
                    :options="orgs.filter(x => !org.parentNodes.includes(x) && x.id !== undefined)"
                    v-model.number="org.upperDeptId" placeholder="上層組織" option-value="id" option-label="name"
                    @update:model-value="updateDeptTree" /></td>
                <td>
                  <q-radio class="text-no-wrap" v-model="org.status" val="1" label="啟用" />
                  <q-radio class="text-no-wrap" :model-value="org.status" val="0" label="停用"
                    @update:model-value="alertIfNameExists(org)" />
                </td>
                <td></td>
              </template>
              <template v-else>
                <td>{{ org.name }}</td>
                <td>{{ org.title }}</td>
                <td>{{ ORG_NAME[org.upperDeptId] }}</td>
                <td>
                  <q-btn v-if="org.status" color="red">停用</q-btn>
                  <q-btn v-else color="green">啟用</q-btn>
                </td>
                <td>
                  <q-btn flat icon="edit" color="primary" @click="org.editing = true"></q-btn>
                </td>
              </template>
            </tr>
          </tbody>
        </table>
        <q-btn color="indigo" flat icon="add" class="full-width q-py-md"
          style="border: 2px dashed #0C31761A;border-radius:8px;" @click="add">新增組織</q-btn>
      </div>
    </c-row>
  </q-page>
</template>

<script lang="ts">
import { Notify } from "quasar";
import { DeptView } from "src/api/feature";
import { Vue } from "vue-class-component";
import { utils, writeFileXLSX } from "xlsx";

interface IDeptView extends DeptView {
  editing: boolean;
  status: string;
  parentNode?: IDeptView;
  parentNodes: IDeptView[];
}

export default class Ministry extends Vue {
  tab = "使用中";
  editing = false;
  beforeEdit: IDeptView[] = [];
  orgs: IDeptView[] = [];
  get ORG_NAME() {
    return Object.fromEntries(this.orgs.map(x => [x.id, x.name]))
  }
  get lastModify(): IDeptView {
    const lastDate = this.orgs.map(y => String(y.dateUpdate)).sort((a, b) => a.localeCompare(b)).pop();
    return this.orgs.find(x => x.dateUpdate == lastDate) || {} as IDeptView;
  }
  async mounted() {
    await this.fetchOrgs();
  }
  updateDeptTree() {
    // 轉成{ [id]:IDeptView }
    const org_map = Object.fromEntries(this.orgs.map(x => [x.id, x]));
    // 添加屬性parentNode:IDeptView
    for (let org of this.orgs) {
      org.parentNode = org_map[org.upperDeptId];
      org.parentNodes = [];
    }
    // 計算節點深度、單位遞迴防呆
    for (let { parentNode, parentNodes } of this.orgs) {
      while (parentNode) {
        if (parentNodes.includes(parentNode)) break;
        parentNodes.push(parentNode);
        parentNode = parentNode.parentNode;
      }
    }
    // 排序ORDER BY depth,id ASC
    this.orgs.sort((a, b) => a.parentNodes.length - b.parentNodes.length || a.id - b.id);
  }
  async fetchOrgs() {
    const res = await this.apis.feature.dept.fetchDepts({});
    this.orgs = (res.data || []).map(x => ({ ...x, editing: false, status: "1", parentNodes: [] }));
    // await new Promise(() => {
    //   this.orgs = [
    //     { id: 1, name: "協會", title: "", upperDeptId: 0, comment: "", editing: false, status: "1", parentNodes: [] },
    //     { id: 2, name: "旌旗", title: "", upperDeptId: 1, comment: "", editing: false, status: "1", parentNodes: [] },
    //     { id: 3, name: "教會", title: "牧師", upperDeptId: 2, comment: "", editing: false, status: "1", parentNodes: [] },
    //     { id: 4, name: "部", title: "區牧長", upperDeptId: 3, comment: "", editing: false, status: "1", parentNodes: [] },
    //     { id: 5, name: "牧區", title: "區牧", upperDeptId: 4, comment: "", editing: false, status: "1", parentNodes: [] },
    //     { id: 6, name: "督區", title: "區督", upperDeptId: 5, comment: "", editing: false, status: "1", parentNodes: [] },
    //     { id: 7, name: "區", title: "區長", upperDeptId: 6, comment: "", editing: false, status: "1", parentNodes: [] },
    //     { id: 8, name: "小組", title: "小組長", upperDeptId: 7, comment: "", editing: false, status: "1", parentNodes: [] },
    //   ]
    // });
    this.updateDeptTree();
    this.beforeEdit = this.orgs.map(x => ({ ...x }));
  }
  add() {
    const newOrg = {} as IDeptView;
    newOrg.parentNodes = [];
    this.orgs.push(newOrg);
  }
  async save() {
    for (let org of this.orgs) {
      const after = { ...org, parentNode: undefined, parentNodes: undefined };
      const before = this.beforeEdit.find(x => x.id == org.id);
      if (before) {
        if (Object.keys(before).some(key => after[key as keyof IDeptView] != before[key as keyof IDeptView]))
          await this.apis.feature.dept.putDept(after);
      } else {
        await this.apis.feature.dept.createDept(after);
      }
    }
    //this.beforeEdit = this.organizationList.slice().map(x => ({ ...x }));
    await this.fetchOrgs();
    this.editing = false;
  }
  cancel() {
    this.orgs = this.beforeEdit.map(x => ({ ...x }));
    this.editing = false;
  }
  exportExcel() {
    const workbook = utils.book_new();
    const worksheet = utils.json_to_sheet(this.orgs);
    utils.book_append_sheet(workbook, worksheet, "牧養組織與職分管理");
    writeFileXLSX(workbook, "牧養組織與職分管理.xlsx");
  }
  alertIfNameExists(org: IDeptView) {
    if (org.name) Notify.create({ color: "negative", message: "組織未淨空，無法停用", });
    else org.status = "1";
  }
}
</script>

<style>
.ministry-table th {
  white-space: nowrap;
  background: #EDEDEE;
  padding: 6px 4px;
}

.ministry-table td {
  text-align: center;
  background: #F7F7F9;
  padding: 4px;
}

.ministry-table .editing td {
  background: #FAFCFF;
}
</style>
