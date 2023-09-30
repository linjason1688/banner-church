<template>
  <q-page class="q-pa-md">
    <q-form @submit="submitAsync" class="q-gutter-y-md">
      <div class="row">
        <div class="col">
          <c-page-title>
            課程資訊
          </c-page-title>
        </div>
      </div>

      <div class="row">
        <div class="col-12">
          <c-subtitle title="課程資訊"></c-subtitle>
        </div>
      </div>

      <c-field stack-label label="堂點">
        <c-form-organization v-model="form.organizationId"></c-form-organization>
      </c-field>

      <c-field stack-label label="名稱">
        <c-input v-model="form.name"></c-input>
      </c-field>

      <c-field stack-label label="狀態">
        <c-form-status-cd v-model="form.statusCd"></c-form-status-cd>
      </c-field>

      <div class="row">
        <div class="col">
          <c-btn-history-back class="q-mr-md" />
          <c-btn-remove v-if="isUpdateMode" @click="removeAsync" class="q-mr-md" />
          <c-btn-save type="submit" />
        </div>
      </div>
    </q-form>
  </q-page>
</template>

<script lang="ts">
/* eslint-disable */
import {
  CreateShoppingOrderCommand,
  DeleteShoppingOrderCommand,
  UpdateShoppingOrderCommand,
} from "src/api/feature";
/* eslint-enable */
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import {
  CreateCourseCommand,
  DeleteCourseCommand,
  UpdateCourseCommand,
} from "src/api/feature";
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
      const res = await this.apis.feature.course.getCourse(this.deleteKey);
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
      const request = Object.assign({}, this.form) as unknown as CreateCourseCommand;
      await this.apis.feature.course.createCourse(request);
      this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form);
      await this.apis.feature.course.putCourse(request as unknown as UpdateCourseCommand);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`是否要刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.course.deleteCourse(request as unknown as DeleteCourseCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }
}
</script>

<style lang="scss" scoped></style>
