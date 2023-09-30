<template>
  <q-page class="q-pa-lg relative-position">
    <c-subtitle title="帳號管理 / 編輯"></c-subtitle>
    <q-form @submit="submit">
      <q-card class="bg-white q-px-xl q-py-md">
        <c-column label="帳號">
          <c-input v-model="form.userNo"></c-input>
        </c-column>
        <c-column label="密碼">
          <c-input :type="showPassword ? 'text' : 'password'" v-model="form.password">
            <template v-slot:append>
              <q-btn flat @click="showPassword = !showPassword">
                <img class="eye" :src="showPassword ? '/img/eye.svg' : '/img/eye-slash.svg'">
              </q-btn>
            </template>
          </c-input>
          <template v-slot:append>
            <q-btn rounded color="primary" class="q-mb-md">變更密碼</q-btn>
          </template>
        </c-column>
        <c-column label="角色">
          <q-radio v-model="form.roleId" v-for="role in roleList" :key="role.id" :val="role.id" :label="role.name" />
        </c-column>
        <c-column label="狀態">
          <c-form-status-cd v-model="form.statusCd"></c-form-status-cd>
        </c-column>
      </q-card>
    </q-form>
    <div class="absolute absolute-bottom app-savecancel-group text-center q-py-sm">
      <c-btn-save />
      <span>　　　</span>
      <c-btn-history-back />
    </div>
  </q-page>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { RoleView } from "src/api/management";

@Options({
  meta() {
    return {
      title: "Role Detail",
    };
  },

  components: {},
})
export default class RoleDetailPage extends DetailComponentBase {
  // ========== props ==========

  // ========== vuex ==========

  // ========== data ==========
  detail = {} as RoleView;
  roleList = [
    { id: 0, name: "系統管理者" },
    { id: 1, name: "全職同工" },
    { id: 2, name: "財務同工" },
    { id: 3, name: "課程同工" },
  ];
  showPassword = false;
  form = {
    name: "",
    userNo: "",
    password: "",
    roleId: "",
    statusCd: "",
  };

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  async mounted() {
    if (this.$isCreateMode) return;
    const id = this.id;
    const res = await this.apis.management.role.findOneAsync({ id, });
    this.detail = res.data;
  }

  // ========== methods ==========
  async submit() {
    if (this.$isCreateMode) {
      // await this.apis.management.role.createAsync(this.form as CreateRoleCommand);
    } else if (this.$isUpdateMode) {
      const id = this.id;

      // await this.apis.management.role.updateAsync({
      //   id,
      //   ...this.form,
      // } as UpdateRoleCommand);
    }

    this.showSuccessNotify("已儲存");

    await this.$router.push({
      name: "CR0100",
    });
  }

  async remove() {
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.form.name}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const id = this.id;

    await this.apis.management.role.removeAsync({
      id,
    });

    this.showSuccessNotify("已刪除");

    await this.$router.push({
      name: "CR0100",
    });
  }

  // ========== listening ==========

  // ========== emit ==========
}
</script>
