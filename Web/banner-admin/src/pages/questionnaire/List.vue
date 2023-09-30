<template>
  <q-page class="q-pa-lg">
    <c-subtitle title="問卷設定"></c-subtitle>
    <c-form-card-filled>
      <q-form @submit="queryAsync" class="q-mt-md q-mb-lg">
        <c-column label="堂點">
          <c-form-organization v-model="form.organizationId"></c-form-organization>
        </c-column>
        <c-column label="問卷類型">
          <c-form-system-config v-model="form.questionnaireType" system-config="QuestionnaireType" />
        </c-column>
        <c-column label="問卷名稱">
          <c-input v-model="form.name"></c-input>
        </c-column>
        <c-column label="問卷日期">
          <c-date-picker v-model="form.questionnaireDateStart"></c-date-picker>
          <c-date-picker v-model="form.questionnaireDateEnd"></c-date-picker>
        </c-column>
        <c-column label="狀態">
          <c-form-status-cd v-model="form.statusCd"></c-form-status-cd>
        </c-column>
        <c-column class="text-right">
          <c-btn-search type="submit" />
        </c-column>
      </q-form>
    </c-form-card-filled>
    <c-btn-create class="q-mb-lg" :to="{ path: 'detail' }" />
    <c-form-card>
      <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
        <template v-slot:body-cell-action="props">
          <c-btn-action-text :to="{ path: 'detail/' + props.row.id, }" />
        </template>
      </c-table>
    </c-form-card>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { PagedRequest } from "src/data/dto";
import { ListComponentBase } from "src/components/ListComponentBase";
import { SortOrder } from "src/data/constants";
import { QueryQuestionnaireRequest, QuestionnaireView } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormSystemConfig from "components/business/FormSystemConfig.vue";
import { SystemConfigState } from "src/data/dto/SystemConfigState";

interface Questionnaire$ {
  id: number;
  organizationId: number;
  questionnaireType: string;
  isAnonymous: boolean;
  name: string;
  questionnaireDate: string;
  link: string;
  questionnaireStatus: string;
  statusCd?: string;
  creator?: string;
  updater?: string;
  dateCreate?: string;
  dateUpdate?: string;
}

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {
    "c-form-organization": FormOrganization,
    "c-form-system-config": FormSystemConfig,
  },
})
export default class QuestionnaireList extends ListComponentBase {
  isLoading = true;

  columns = [
    {
      label: "功能",
      align: "center",
      name: "action",
      column: (row: Questionnaire$) => row.id,
      style: "width: 150px;",
    },
    {
      label: "堂點",
      align: "left",
      name: "organizationId",
      column: (row: Questionnaire$) => row.organizationId,
      sortable: true,
    },

    {
      label: "問卷類型",
      align: "center",
      name: "questionnaireType",
      column: (row: Questionnaire$) => this.convertQuestionnaireType(row.questionnaireType),
      sortable: true,
    },
    {
      label: "匿名/非匿名",
      align: "left",
      name: "isAnonymous",
      column: (row: Questionnaire$) => row.isAnonymous,
      sortable: true,
    },
    {
      label: "問卷名稱",
      align: "left",
      name: "name",
      column: (row: Questionnaire$) => row.name,
      sortable: true,
    },
    {
      label: "日期",
      align: "left",
      name: "dateCreate",
      column: (row: Questionnaire$) => row.dateCreate,
      sortable: true,
    },
    {
      label: "問卷連結",
      align: "left",
      name: "link",
      column: (row: Questionnaire$) => row.link,
      sortable: true,
    },
    {
      label: "狀態",
      align: "right",
      name: "questionnaireStatus",
      column: (row: Questionnaire$) => row.questionnaireStatus,
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "name",
      column: (row: Questionnaire$) => row.name,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      column: (row: Questionnaire$) => row.dateCreate,
    },
  ];

  rows: Array<QuestionnaireView> = [];

  form = {
    organizationId: undefined,
    questionnaireType: undefined,
    name: "",
    questionnaireDate: "",
    statusCd: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  questionnaireType = new Array<SystemConfigState>();

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(paged = this.pagination) {
    this.isLoading = true;
    const res = await this.usePreviousRequestParamsAsync(req => this.apis.feature.questionnaire.queryQuestionnaires(req), { ...this.form, ...paged });
    this.rows = res.data.records;
    this.updatePagination(paged, res.data);
    this.isLoading = false;
  }

  private convertQuestionnaireType(val: string) {
    const found = this.questionnaireType.find(e => e.name = val);
    if (found) return found.value;
    return val;
  }
}
</script>

<style lang="scss" scoped></style>
