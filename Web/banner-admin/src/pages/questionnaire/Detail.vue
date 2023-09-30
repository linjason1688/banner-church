<template>
  <q-page class="q-pa-lg">
    <c-form-card bordered="false">
      <q-form @submit="submitAsync" class="q-gutter-y-md">
      <div class="row">
        <div class="col">
          <c-page-title>
            問卷設定
          </c-page-title>
        </div>
      </div>

      <div class="row">
        <div class="col-12">
          <c-subtitle title="問卷設定"></c-subtitle>
        </div>
      </div>

      <c-field label="問卷標題">
        <c-input v-model="form.name"></c-input>
      </c-field>
      <c-field label="問卷說明">
        <c-input v-model="form.description"></c-input>
      </c-field>

      <div class="row" @click="addSection()">新增區段</div>
      <div class="row" @click="removeSection()">刪除</div>
      <div v-for="item in form.questionnaireDetailViews" :key="item.id">
        <c-field label="標題">
          <c-input v-model="item.name"></c-input>
        </c-field>
        <c-field label="說明">
          <c-input v-model="item.description"></c-input>
        </c-field>

        <div class="row" @click="addOption(item)">新增題目</div>
        <div class="row" @click="removeOption()">刪除</div>
        <div v-for="detail in item.questionnaireDetailViews" :key="detail.id" class="q-card--bordered">
          <c-field label="題目類型">
            <c-form-system-config v-model="detail.questionnaireDetailType" system-config="QuestionnaireDetailType" />
          </c-field>
          <c-field label="題目內容">
            <c-input v-model="detail.name"></c-input>
          </c-field>
          <c-field label="題目說明">
            <c-input v-model="detail.description"></c-input>
          </c-field>
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
import {
  CreateQuestionnaireCommand,
  DeleteQuestionnaireCommand,
  QuestionnaireDetailView,
  UpdateQuestionnaireCommand,
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
    id: 0,
    name: "",
    organizationId: undefined,
    questionnaireJoinLocation: "",
    questionnaireType: "",
    questionnaireDetailViews: new Array<QuestionnaireDetailView>(),
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
      const res = await this.apis.feature.questionnaire.getQuestionnaire(this.deleteKey);
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
      const request = Object.assign({}, this.form) as unknown as CreateQuestionnaireCommand;
      await this.apis.feature.questionnaire.createQuestionnaire(request);
      this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form);
      await this.apis.feature.questionnaire.putQuestionnaire(request as unknown as UpdateQuestionnaireCommand);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.questionnaire.deleteQuestionnaire(request as unknown as DeleteQuestionnaireCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }

  addOption(item: QuestionnaireDetailView) {
    const row = Object.assign({ componentType: "0" }) as QuestionnaireDetailView;
    if (!item.questionnaireDetailViews) {
      item.questionnaireDetailViews = new Array<QuestionnaireDetailView>();
    }
    // eslint-disable-next-line @typescript-eslint/no-unsafe-call,@typescript-eslint/no-unsafe-member-access
    item.questionnaireDetailViews.push(row);
  }

  addSection() {
    const row = Object.assign({ componentType: "0" }) as QuestionnaireDetailView;
    this.form.questionnaireDetailViews.push(row);
  }

}
</script>

<style lang="scss" scoped></style>
