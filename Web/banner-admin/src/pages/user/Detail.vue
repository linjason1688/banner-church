<template>
  <q-page class="q-pa-lg relative-position">
    <c-subtitle title="帳號管理 / 編輯"></c-subtitle>
    <q-form @submit="submit">
      <q-card class="bg-white q-px-xl q-py-md">
        <c-column label="帳號">
          <c-input autocomplete="new-password" v-model="detail.userNo"></c-input>
        </c-column>
        <c-column label="密碼">
          <c-input autocomplete="new-password" :type="showPassword ? 'text' : 'password'" v-model="detail.password">
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
          <q-checkbox v-model="rolesId" v-for="role in roleList.filter(r => r.value != null)" :key="role.Id"
            :label="role.label" :true-value="role.value" :false-value="rolesId" />
        </c-column>
        <c-column label="狀態">
          <c-form-status-cd v-model="detail.statusCd"></c-form-status-cd>
        </c-column>
      </q-card>
    </q-form>
    <div class="absolute absolute-bottom app-savecancel-group text-center q-py-sm">
      <c-btn-save @click="submit" />
      <span>　　　</span>
      <c-btn-history-back />
    </div>
  </q-page>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";

import { DetailComponentBase } from "src/components/DetailComponentBase";
/* eslint-enable */
import { UserView } from "src/api/feature";

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
  detail = {} as UserView;
  roleList = [
    { Id: "0", label: "系統管理者", value: "05C3812D-832C-4604-9AF4-2F3EEB9F27C4" },
    { Id: "1", label: "全職同工", value: "96EBD819-F5C2-40F3-BE45-354F530ABB77" },
    { Id: "2", label: "財務同工", value: "DCEE528B-A1CF-486C-854E-A37E71C9168C" },
    { Id: "3", label: "課程同工", value: "E2821448-33AE-441A-8249-1AB010F1A002" },
  ];
  showPassword = false;
  rolesId = "";
  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  async mounted() {
    const id = this.id;
    const allowedRoleIds = ["05C3812D-832C-4604-9AF4-2F3EEB9F27C4", "96EBD819-F5C2-40F3-BE45-354F530ABB77", "DCEE528B-A1CF-486C-854E-A37E71C9168C", "E2821448-33AE-441A-8249-1AB010F1A002"];

    //找出當前User的基本資料
    await this.apis.feature.user.findUsers(Number(id))
      .then(async res => {
        if (res.data.size > 0) {
          this.detail = res.data.records[0];
        }
        //找出在RoleUserMapping裡對應User的RoleId
        const query = {
          userId: this.detail.id,
          sortProperties: [],
          page: 1,
          size: 1,
        }
        await this.apis.feature.roleUserMapping.queryRoleUserMappings(query)
          .then(async res => {
            const roleId = res.data.records[0]?.roleId;
            const roleusermappingid = res.data.records[0].id//RoleUserMapping的 id
            if (!roleId || !allowedRoleIds.includes(roleId.toUpperCase())) {
              this.rolesId = "AD74F87F-53E9-4B5A-A8F2-79718CE124B6";

              // 更新 RoleUserMapping 資料
              const updateRoleUserMappingCommand = {
                id: roleusermappingid,
                roleId: this.rolesId,
                userId: this.detail.id,
              };
              await this.apis.feature.roleUserMapping.putRoleUserMapping(updateRoleUserMappingCommand);
            }
            else {
              this.rolesId = roleId.toUpperCase();
            }
          })

        console.log("xxxxx", this.rolesId)
      })
    await this.$nextTick();
    this.$forceUpdate();
  }
  // ========== methods ==========
  async submit() {
    // 找到對應的 RoleUserMapping 資料
    const query = {
      userId: this.detail.id,
      sortProperties: [],
      page: 1,
      size: 1,
    };
    const res = await this.apis.feature.roleUserMapping.queryRoleUserMappings(query)
    const roleusermappingid = res.data.records[0].id//RoleUserMapping的 id
    // 更新 RoleUserMapping 資料
    const updateRoleUserMappingCommand = {
      id: roleusermappingid,
      roleId: this.rolesId.toString(),
      userId: this.detail.id,
    };
    await this.apis.management.user.updateAsync(this.detail);
    await this.apis.feature.roleUserMapping.putRoleUserMapping(updateRoleUserMappingCommand);
    this.showSuccessNotify("已儲存");

    //重新載入當前頁面
    //await this.$router.replace({ path: `/m/user/detail/${this.id}` });


    // await this.$router.push({
    //   path: "list",
    // });
  }

  async remove() {
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.detail.name}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const id = this.id;

    await this.apis.feature.user.removeUser(Number(id));

    this.showSuccessNotify("已刪除");

    await this.$router.push({
      path: "list",
    });
  }
  // ========== listening ==========

  // ========== emit ==========
}
</script>

<style lang="scss" scoped></style>
