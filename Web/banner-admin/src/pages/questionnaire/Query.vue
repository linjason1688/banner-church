<template>
  <div class="row justify-center q-pa-lg">
    <div class="col-12 col-md-8">
      <c-subtitle title="問卷填寫" />
      <c-form-card>
        <q-form @submit="queryAsync">
          <div class="row">
            <div class="col-6">
              <c-field label="問卷類型">
                <c-select></c-select>
              </c-field>
            </div>
            <div class="col-6">
              <c-field label="問卷名稱">
                <c-input></c-input>
              </c-field>
            </div>
          </div>

          <div class="row">
            <div class="col">
              <c-field label="問卷日期">
                <c-date-picker v-model="form.dateRange" prefix="From：" role="search" />
                <c-date-picker v-model="form.dateRange" prefix="To：" role="search" />
              </c-field>
            </div>
            <div class="col">
              <c-field label="填寫狀態">
                <c-select></c-select>
              </c-field>
            </div>
          </div>

          <c-btn-search></c-btn-search>
        </q-form>
      </c-form-card>

      <c-table :loading="isLoading" :columns="columns" :rows="rows" :pagination="pagination" @paginate="queryAsync">
        <template v-slot:body-cell-action="props">
          <c-btn-edit :to="{ path: '/m/questionnaire/detail', params: { id: props.row.id, }, }" />
        </template>
      </c-table>
    </div>
  </div>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { ref } from "vue";
import { ListComponentBase } from "components/ListComponentBase";
import { SortOrder } from "src/api/management";
import { UserQuestionnaire } from "src/api/feature";
import { PagedRequest } from "src/data/dto";

@Options({
  components: {},
})
export default class Query extends ListComponentBase {

  columns = [
    {
      label: "堂點",
      align: "center",
      name: "location",
      field: (row: UserQuestionnaire) => row.questionnaireGoArea,
    },
    {
      label: "問卷類型",
      align: "center",
      name: "questionnaireType",
      field: (row: UserQuestionnaire) => row.questionnaireWriteType,
    },
    {
      label: "問卷名稱",
      align: "center",
      name: "name",
      field: (row: UserQuestionnaire) => row.comment,
    },
    {
      label: "功能",
      align: "center",
      name: "action",
      field: (row: UserQuestionnaire) => row.id,
      style: "width: 100px;",
    },
  ];

  rows: { questionnaireGoArea: number; questionnaireWriteType: number; comment: string }[] = [];

  form = {
    name: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
    dateRange: ref(null),
  };

  mounted() {
    this.isLoading = false;
    this.rows = [
      {
        questionnaireGoArea: 1,
        questionnaireWriteType: 1,
        comment: "11",
      },
    ];
  }

  queryAsync(paged = this.pagination) {
    this.isLoading = false;
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';
</style>
