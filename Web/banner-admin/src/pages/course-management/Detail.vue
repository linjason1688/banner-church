<template>
  <q-page class="q-pa-lg">
    <q-form @submit="submitAsync" class="q-gutter-y-md">

      <div class="row">
        <div class="col-12">
          <c-subtitle title="建立課程資訊" />
        </div>
      </div>

      <c-form-card class="column-lab" bordered="false">
        <div class="col-12">
          <div>
            <c-row class="row">
              <div class="course-lab col-12 col-md-6">
                <c-column label="課程分類">
                  <c-form-course-management-type v-model="form.courseManagementTypeId"
                                                 @onUpdateModelValue="onCourseManagementTypeIdChanged"
                                                 outlined clearable dense />
                </c-column>
              </div>
            </c-row>

            <c-row class="row">
              <div class="course-lab col-12 col-md-6">
                <c-column label="課程代碼">
                  <c-field>
                    {{ form.courseManagementNo }}
                  </c-field>
                </c-column>
              </div>
            </c-row>

            <c-row class="row">
              <div class="course-lab col-12 col-md-6">
                <c-column label="課程名稱">
                  <c-input v-model="form.title" dense />
                </c-column>
              </div>
            </c-row>

            <c-row class="row">
              <div class="course-lab col-12 col-md-6">
                <c-column label="課程類型">
                  <q-radio v-model="form.courseType" val="0" label="實體" />
                  <q-radio v-model="form.courseType" val="1" label="線上" />
                  <q-radio v-model="form.courseType" val="2" label="網路學校" />
                </c-column>
              </div>
            </c-row>

            <c-row class="row">
              <div class="course-lab col-12 col-md-6">
                <c-column label="課程內容">
                  <c-input v-model="form.description" type="textarea" outlined dense />
                </c-column>
              </div>
            </c-row>

            <c-row class="row">
              <div class="course-lab col-12 col-md-6">
                <c-column label="對象資格說明">
                  <c-input v-model="form.basicQualification" type="textarea" outlined dense />
                </c-column>
              </div>
            </c-row>

            <c-row class="row">
              <div class="course-lab col-12 col-md-6">
                <c-column label="結業資格說明">
                  <c-input v-model="form.graduationQualification" type="textarea" outlined dense />
                </c-column>
              </div>
            </c-row>

            <c-row class="row">
              <div class="course-lab col-12 col-md-6">
                <c-column label="狀態">
                  <c-form-status-cd v-model="form.statusCd" hasAllOptions="false" outlined clearable dense />
                </c-column>
              </div>
            </c-row>

          </div>
        </div>

        <div class="course-lab row">
          <div class="col">
            <c-btn-save type="submit" />
            <c-btn-remove v-if="isUpdateMode" @click="removeAsync" class="q-mr-md" />
            <c-btn-history-back class="q-mr-md" />
          </div>
        </div>
      </c-form-card>

    </q-form>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import {
  CreateCourseManagementCommand,
  DeleteCourseManagementCommand,
  UpdateCourseManagementCommand,
} from "src/api/feature";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";

@Options({
  meta() {
    return {
      title: "詳細資料",
    };
  },

  components: {
    "c-form-course-management-type": FormCourseManagementType,
  },
})
export default class Detail extends DetailComponentBase {

  form = {
    courseManagementTypeId: undefined,
    courseManagementNo: "",
    courseManagementType: "",
    organizationId: undefined,
    title: "",
    year: "",
    season: "",
    stage: "",
    logo: "",
    courseType: "",
    discountPrice: null,
    discountSignUpDate: null,
    coursePrice: null,
    name: "",
    statusCd: "1",
    description: "",
    basicQualification: "",
    graduationQualification: ""
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

  onCourseManagementTypeIdChanged() {
    void this.apis.feature.courseManagementType.getCourseManagementTypeOfId(Number(this.form.courseManagementTypeId))
      .then(e => {
        this.form.courseManagementNo = e.data.courseManagementTypeNo
      })
  }

  async mounted() {
    if (this.isUpdateMode) {
      const res = await this.apis.feature.courseManagement.getCourseManagement(this.deleteKey);
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
      const request = Object.assign({}, this.form) as unknown as CreateCourseManagementCommand;
      await this.apis.feature.courseManagement.createCourseManagement(request);
      this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form);
      await this.apis.feature.courseManagement.putCourseManagement(request as unknown as UpdateCourseManagementCommand);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.courseManagement.deleteCourseManagement(request as unknown as DeleteCourseManagementCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }
}
</script>

<style lang="scss" scoped>
.column-lab {
  width: 640px;
  margin: 0 auto;
}

.course-lab {
  width: 488px;
  margin: 0 auto;
}
</style>
