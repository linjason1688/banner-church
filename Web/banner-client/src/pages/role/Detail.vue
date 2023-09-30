<template>
  <q-page class="q-pa-md">
    <q-form @submit="submit" class="column q-gutter-y-md">
      <div class="row">
        <div class="col">
          <c-page-title></c-page-title>
        </div>
        <div class="col-auto">
          <c-btn-history-back class="q-mr-md" />
          <q-btn v-if="$isUpdateMode" @click="remove" label="刪除" color="negative" class="q-mr-md" outline />
          <q-btn type="submit" label="儲存" color="primary" />
        </div>
      </div>

      <div class="row">
        <div class="col-12">
          <q-input v-model="form.name" prefix="Name：" class="q-my-md" outlined />

          <c-detail v-if="$isUpdateMode" :detail="detail" />
        </div>
      </div>
    </q-form>
  </q-page>
</template>

<script lang="ts">
/* eslint-disable no-unused-vars, @typescript-eslint/no-unused-vars */
import { Options } from "vue-class-component";
import { Ref, Prop, Watch, Emit } from "vue-property-decorator";
import { State, Getter, Action } from "vuex-class";

import { DetailComponentBase } from "src/components/DetailComponentBase";
/* eslint-enable */

import { RoleView } from "src/api/management";
import {CreateRoleCommand} from "src/api/feature";

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

  form = {
    name: "",
  };

  // ========== computed ==========

  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  async mounted() {
    if (this.$isCreateMode) {
      return;
    }

    const id = this.id;

    const res = await this.apis.management.role.findOneAsync({
      id,
    });

    this.detail = res.data;

    const { name } = this.detail;

    this.form.name = name;
  }

  // ========== methods ==========
  async submit() {
    if (this.$isCreateMode) {
      await this.apis.management.role.createAsync(this.form as CreateRoleCommand);
    } else if (this.$isUpdateMode) {
      const id = this.id;

      await this.apis.management.role.updateAsync({
        id,
        ...this.form,
      } as CreateRoleCommand);
    }

    this.showSuccessNotify("已儲存");

    await this.$router.push({
      name: "CR0100",
    });
  }

  async remove() {
    const confirm = await this.showConfirmDialogAsync(`是否要刪除 ${this.form.name}？`, "請再次確認");

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

<style lang="scss" scoped></style>
