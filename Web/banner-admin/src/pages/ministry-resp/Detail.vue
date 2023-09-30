<template>
  <q-page class="q-pa-lg">
    <div class="row">
      <div class="col-12">
        <c-subtitle title="牧養職分設定"></c-subtitle>
      </div>
    </div>

    <c-form-card bordered="false">
      <q-form @submit="submitAsync" class="q-gutter-y-md">
        <c-field label="牧養職分">
          <c-input v-model="form.name"></c-input>
        </c-field>

        <c-field label="牧養層級">
          <c-input v-model="form.seq"></c-input>
        </c-field>

        <c-field label="狀態">
          <c-form-status-cd v-model="form.statusCd"></c-form-status-cd>
        </c-field>

        <div class="text-center q-mb-md">
            <c-btn-history-back class="q-mr-md" />
            <c-btn-remove v-if="isUpdateMode" @click="removeAsync" class="q-mr-md" />
            <c-btn-save type="submit" />
        </div>
      </q-form>
    </c-form-card>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import { CreateMinistryRespCommand, DeleteMinistryRespCommand, UpdateMinistryRespCommand } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";

@Options({
  meta() {
    return {
      title: "詳細資料",
    };
  },

  components: {
    "c-form-organization": FormOrganization,
  },
})
export default class Detail extends DetailComponentBase {

  form = {
    organizationId: undefined,
    name: "",
    seq: "",
    statusCd: "1",
  };

  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.form.name;
  }

  get deleteKey() {
    return this.id as unknown as number;
  }

  async mounted() {
    if (this.isUpdateMode) {
      const res = await this.apis.feature.ministryResp.getMinistryResp(this.deleteKey);
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
    this.showSuccessNotify("儲存成功");
  }

  async createAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form) as unknown as CreateMinistryRespCommand;
      await this.apis.feature.ministryResp.createMinistryResp(request);
      this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form);
      await this.apis.feature.ministryResp.putMinistryResp(request as unknown as UpdateMinistryRespCommand);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`是否要刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.ministryResp.deleteMinistryResp(request as unknown as DeleteMinistryRespCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }
}
</script>