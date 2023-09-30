<template>
  <q-page class="q-pa-lg">
    <c-form-card bordered="false">
      <q-form @submit="submitAsync" class="q-gutter-y-md">
        <div class="row">
          <div class="col-12">
            <c-subtitle title="事工團分類設定管理" />
          </div>
        </div>

        <div class="row">
          <div class="col-12 col-md-6">
            <c-field label="事工團份別代碼">
              <c-input v-model="form.ministryDefNo" class="q-my-md" />
            </c-field>
          </div>
        </div>

        <div class="row">
          <div class="col-12 col-md-6">
            <c-field label="事工團分類名稱">
              <c-input v-model="form.name" lass="q-my-md" />
            </c-field>
          </div>
        </div>

        <div class="row">
          <div class="col-12 col-md-6">
            <q-radio v-model="form.statusCd" val="1" label="啟用" />
            <q-radio v-model="form.statusCd" val="0" label="停用" />
          </div>
        </div>

        <div class="row">
          <div class="col">
            <c-btn-save type="submit" />
            <c-btn-remove v-if="isUpdateMode" @click="removeAsync" class="q-mr-md" />
            <c-btn-history-back class="q-mr-md" />
          </div>
        </div>
      </q-form>
    </c-form-card>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import { CreateMinistryDefCommand, DeleteMinistryDefCommand, UpdateMinistryDefCommand } from "src/api/feature";

@Options({
  meta() {
    return {
      title: "詳細資料",
    };
  },

  components: {},
})
export default class Detail extends DetailComponentBase {
  form = {
    ministryDefId: "",
    ministryDefNo: "",
    name: "",
    statusCd: "1",
  };

  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.form.name;
  }

  get deleteKey() {
    return this.id;
  }

  async mounted() {
    if (this.isUpdateMode) {
      const res = await this.apis.feature.ministryDef.getMinistryDef(this.id as unknown as number);
      Object.assign(this.form, res.data);
    }
  }

  @WithLoading()
  async submitAsync() {
    if (this.isUpdateMode) {
      await this.updateAsync();
    } else {
      await this.createAsync();
    }
  }

  async createAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form) as unknown as CreateMinistryDefCommand;
      await this.apis.feature.ministryDef.createMinistryDef(request);
      this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form);
      await this.apis.feature.ministryDef.putMinistryDef(request as unknown as UpdateMinistryDefCommand);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.ministryDef.deleteMinistryDef(request as unknown as DeleteMinistryDefCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }
}
</script>

<style lang="scss" scoped></style>
