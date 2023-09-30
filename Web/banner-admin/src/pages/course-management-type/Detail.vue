<template>
  <q-page class="q-pa-lg">
    <q-form @submit="submitAsync" class="q-gutter-y-md">
      <div class="row">
        <div class="col-12">
          <c-subtitle title="課程分類管理" />
        </div>
      </div>
      <div class="row">
        <div class="col-12">
          <c-form-card bordered="false">
            <c-row class="row">
              <div class="col-12 col-md-6">
                <c-column label="分類代碼">
                  <c-input v-model="form.courseManagementTypeNo" outlined clearable dense />
                </c-column>
              </div>
            </c-row>
            <c-row class="row">
              <div class="col-12 col-md-6">
                <c-column label="課程分類">
                  <c-input v-model="form.name" dense />
                </c-column>
              </div>
            </c-row>
            <c-row class="row">
              <div class="col-12 col-md-6">
                <c-column label="狀態">
                  <c-form-status-cd v-model="form.statusCd" :hasAllOptions="false"
                                    outlined clearable dense/>
                </c-column>
              </div>
            </c-row>
            <c-row class="row">
              <div class="col-12 col-md-6">
                <c-column label="備註">
                  <c-input v-model="form.remark" type="textarea" outlined />
                </c-column>
              </div>
            </c-row>
            <c-row class="row">
              <div class="col-12 q-px-md q-mb-md">
                <c-btn-save type="submit" />
                <c-btn-remove v-if="isUpdateMode" @click="removeAsync" />
                <c-btn-history-back class="q-mr-md" />
              </div>
            </c-row>
          </c-form-card>
        </div>
      </div>

    </q-form>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import {
  CreateCourseManagementTypeCommand,
  DeleteCourseManagementTypeCommand,
  UpdateCourseManagementTypeCommand,
} from "src/api/feature";

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
    name: "",
    courseManagementTypeNo: "",
    description: "",
    comment: "",
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
      const res = await this.apis.feature.courseManagementType.getCourseManagementTypeOfId(this.deleteKey);
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
      const request = Object.assign({}, this.form) as unknown as CreateCourseManagementTypeCommand;
      await this.apis.feature.courseManagementType.createCourseManagementType(request);
      this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form);
      await this.apis.feature.courseManagementType.putCourseManagementType(request as unknown as UpdateCourseManagementTypeCommand);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.courseManagementType.deleteCourseManagementType(request as unknown as DeleteCourseManagementTypeCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }
}
</script>

<style lang="scss" scoped></style>
