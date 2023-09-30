<template>
  <div class="row justify-center q-pa-md">
    <div class="col-12">
      <c-subtitle title="問卷填寫" />
      <c-form-card>
        <q-form @submit="queryAsync">
          <div class="row">
            <div class="col-12 col-md-6">
              <c-column label="問卷類型">
                <c-select
                  v-model="form.questionnaireType"
                  emit-value
                  map-options
                  :options="questionnaireTypeList"
                  option-value="name"
                  option-label="value"
                  clearable
                  role="o"
                ></c-select>
              </c-column>
            </div>
            <div class="col-12 col-md-6">
              <c-column label="問卷名稱">
                <c-input v-model="form.name" clearable role="n"></c-input>
              </c-column>
            </div>
          </div>

          <div class="row">
            <div class="col-12 col-md-3">
              <c-column label="問卷日期">
                <c-date-picker v-model="form.dateRangeS" clearable prefix="From：" role="n"></c-date-picker>
              </c-column>
            </div>
            <div class="col-12 col-md-3">
              <c-column label="&nbsp;">
                <c-date-picker v-model="form.dateRangeE" clearable prefix="To：" role="n"></c-date-picker>
              </c-column>
            </div>
            <div class="col-12 col-md-6">
              <c-column label="填寫狀態">
                <c-select
                  v-model="form.questionnaireWriteType"
                  emit-value
                  map-options
                  :options="questionnaireStatusList"
                  option-value="value"
                  option-label="name"
                  clearable
                  role="o"
                ></c-select>
              </c-column>
            </div>
          </div>
          <div class="row">
            <div class="col-12 self-end column items-end">
              <c-btn-search type="submit" />
            </div>
          </div>
        </q-form>
      </c-form-card>

      <c-table
        :loading="isLoading"
        :columns="columns"
        :rows="rows"
        row-key="id"
        ref="table"
        :rowsNumber="rowsNumber"
        :detail="true"
      >
        <template v-slot:body-cell-action="props">
          <q-btn
            class="q-px-lg c-gray-white c-primary-background-500"
            rounded
            unelevated
            dense
            :label="props.row.writeQuestionnaireDate == null ? '填寫' : '檢視'"
            :to="{
              path: 'detail/' + props.row.id,
              query: {
                view: props.row.writeQuestionnaireDate == null ? '0' : '1',
                questionnaireId: props.row.questionnaireId,
              },
            }"
          />
        </template>
        <template v-slot:body-cell-qrCodeInfo="props">
          <c-btn-view @click="showQRCodeInfo(props.row.id)" />
        </template>
        <template v-slot:expand="props">
          <c-column-detail :detailColumns="detailColumns" :props="props" />
          <c-entity-detail :value="props.row" />
        </template>
      </c-table>
      <!-- <c-pagination @change="queryAsync" :pagination="pagination" /> -->
      <c-dialog-qrcode v-model:show.sync="qrcodeDialog" :qrcodeURL="qrcodeURL"></c-dialog-qrcode>
    </div>
  </div>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ref } from "vue";
import { ListComponentBase } from "components/ListComponentBase";
import { SortOrder } from "src/api/management";
import {
  SystemConfigView,
  QueryUserQuestionnaireRequest,
  UserQuestionnaireView,
  QuestionnaireView,
  OrganizationView,
  QueryQrCodeRequest,
  CreateQrCodeCommand,
} from "src/api/feature";
import { convertOrganization, formatDate, SystemConfig } from "src/util";

interface Questionnaire$ extends QuestionnaireView {
  demo: string;
}

interface UserQuestionnaire$ extends UserQuestionnaireView {
  name: string;
  writeQuestionnaireDate: string;
  questionnaire: Questionnaire$;
  qrCodeInfo: string;
}

@Options({
  components: {},
})
export default class Query extends ListComponentBase {
  columns = [
    {
      label: "",
      align: "center",
      name: "action",
      field: (row: UserQuestionnaire$) => row.id,
      style: "width: 100px;",
    },
    {
      label: "堂點",
      align: "center",
      name: "questionnaireJoinLocation",
      field: (row: UserQuestionnaire$) => this.convertOrganizationName(row.questionnaire),
    },
    {
      label: "問卷類型",
      align: "center",
      name: "questionnaireType",
      field: (row: UserQuestionnaire$) => this.convertQuestionnaireType(row.questionnaire),
    },
    {
      label: "問卷名稱",
      align: "center",
      name: "name",
      field: (row: UserQuestionnaire$) => this.convertQuestionnaireName(row.questionnaire),
    },
    {
      label: "問卷日期",
      align: "center",
      name: "writeQuestionnaireDate",
      field: (row: UserQuestionnaire$) => formatDate(row.writeQuestionnaireDate),
    },
    {
      label: "問卷資訊",
      align: "center",
      name: "qrCodeInfo",
      field: (row: UserQuestionnaire$) => row.qrCodeInfo,
    },
  ];
  detailColumns = [
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: UserQuestionnaire$) => formatDate(row.dateCreate),
    },
  ];

  questionnaireStatusList = [
    {
      name: "已填寫",
      value: "1",
    },
    {
      name: "未填寫",
      value: "0",
    },
  ];

  rows: Array<UserQuestionnaire$> = [];

  rowsNumber = 0;

  qrcodeDialog = false;
  qrcodeURL = "";

  form = {
    id: 0,
    name: "",
    questionnaireType: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
    dateRangeS: ref(null),
    dateRangeE: ref(null),
    questionnaireWriteType: "",
  };

  questionnaireTypeList: Array<SystemConfigView> = [];
  organizationList: Array<OrganizationView> = [];

  async mounted() {
    this.isLoading = false;
    await this.loadState();
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async loadState() {
    this.questionnaireTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.QuestionnaireType);
    this.organizationList = (await this.apis.feature.organization.fetchOrganizations({})).data;
  }

  async queryAsync(request?: PagedRequest) {
    this.isLoading = false;

    const form = Object.assign(
      request || {
        userId: this.$appStore.getters.userProfile.id,
      },
      this.form
    ) as unknown as QueryUserQuestionnaireRequest;

    const res = await this.usePreviousRequestParamsAsync(async () => {
      return await this.apis.feature.userQuestionnaire.queryUserQuestionnaires(form);
    }, request);
    this.rows = res.data.records as Array<UserQuestionnaire$>;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
    console.log(res);
  }

  convertDisplayText(systemConfigList: Array<SystemConfigView>, index: string) {
    const found = systemConfigList.find((e) => e.name == index);
    if (found) return found.value;
    return index;
  }

  convertOrganizationName(questionnaire: Questionnaire$) {
    if (questionnaire == null) {
      return "";
    }
    return convertOrganization(this.organizationList, questionnaire.questionnaireJoinLocation);
  }

  convertQuestionnaireType(questionnaire: Questionnaire$) {
    if (questionnaire == null) {
      return "";
    }
    return this.convertDisplayText(this.questionnaireTypeList, questionnaire.questionnaireType);
  }

  convertQuestionnaireName(questionnaire: Questionnaire$) {
    if (questionnaire == null) {
      return "";
    }
    return this.convertDisplayText(this.questionnaireTypeList, questionnaire.name);
  }

  async showQRCodeInfo(id: number) {
    let referenceType = 6;
    let referenceId = id;
    let userId = this.$appStore.getters.userProfile.id;

    let queryQrCodeRequest: QueryQrCodeRequest = {
      referenceType: referenceType,
      referenceId: referenceId,
      userId: userId,
      sortProperties: [],
      size: 0,
      page: 0,
    };

    let createQrCodeCommand = {
      referenceType: referenceType,
      referenceId: referenceId,
      userId: userId,
    } as CreateQrCodeCommand;

    let queryResponse = await this.apis.feature.qrCode.queryQrCodes(queryQrCodeRequest);
    if (typeof queryResponse.data.totalCount !== "undefined" && queryResponse.data.totalCount < 1) {
      await this.apis.feature.qrCode.createQrCode(createQrCodeCommand);
    }

    let resp = await this.apis.feature.qrCode.showQrCode(referenceId, referenceType, userId);
    if (typeof resp.data == "undefined") {
      return;
    }

    this.qrcodeURL = resp.data.generateCode;
    this.qrcodeDialog = true;
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
