<template>
  <div>
    <div class="row items-center">
      <div class="col">
        <c-page-title></c-page-title>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <c-subtitle title="課程資訊－檢視"></c-subtitle>
      </div>
    </div>
    <c-form-card class="q-mb-lg">
      <q-form @submit="queryAsync()">
        <div class="row">
          <div class="col-12 col-md-4">
            <c-column label="開課班級與時段">
              <c-select v-model="form.courseTimeScheduleId" role="o"></c-select>
            </c-column>
          </div>
          <div class="col-12 col-md-4">
            <c-column label="開課狀態">
              <c-select v-model="form.courseStatus" role="o"></c-select>
            </c-column>
          </div>
          <div class="col-12 col-md-4">
            <c-column label="學員">
              <c-input v-model="form.student" role="n"></c-input>
            </c-column>
          </div>
        </div>

        <div class="text-right items-center">
          <c-btn-search type="submit" />
        </div>
      </q-form>
    </c-form-card>
    <c-table :loading="isLoading" :columns="columns" :rows="rows" row-key="id" ref="table" :rowsNumber="rowsNumber">
    </c-table>
    <div class="row justify-center">
      <q-btn class="q-py-none q-px-lg q-mt-md q-mx-md c-heading-h5 c-text-color-white c-primary-background-500" rounded unelevated dense @click="onClickReturn()">返回</q-btn>
    </div>
  </div>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { ComponentBase } from "src/components";
import { Prop, PropSync } from "vue-property-decorator";
import { SortOrder } from "src/data/constants";
import { PagedRequest } from "src/data/dto";
import { QueryCourseTimeScheduleUserRequest, CourseTimeScheduleUserView, UserView } from "src/api/feature";

@Options({
  meta() {
    return {
      title: "清單列表",
    };
  },

  components: {},
})
export default class Detail extends ComponentBase {
  
  @Prop({ type: Number })
  courseTimeScheduleId!: number;

  @PropSync("syncedPage", { type: String })

  page!: string;
  isLoading = true;
  rowsNumber = 0;

  form = {
    courseTimeScheduleId: 0,
    courseStatus: "",
    student: "",
    sortProperties: [{ propertyName: "dateCreate", sortOrder: SortOrder.Desc }],
  };

  columns = [
    {
      label: "開課班級與時段",
      align: "left",
      name: "courseClassSchedule",
      field: (row: CourseTimeScheduleUserView) => row.courseTimeScheduleId,
      sortable: true,
    },
    {
      label: "開課狀態",
      align: "left",
      name: "courseStatus",
      field: (row: CourseTimeScheduleUserView) => (row.attendanceType ? "開啟" : "關閉"),
      sortable: true,
    },
    {
      label: "學員姓名",
      align: "left",
      name: "studentName",
      field: (row: CourseTimeScheduleUserView) => this.getUser(row.userId)?.name,
      sortable: true,
    },
    {
      label: "性別",
      align: "left",
      name: "studentGender",
      field: (row: CourseTimeScheduleUserView) => this.getUser(row.userId)?.genderType == "0" ? "女性" : "男性",
      sortable: true,
    },
  ];

  rows: Array<CourseTimeScheduleUserView> = [];

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(request?: PagedRequest) {
    this.isLoading = true;
    this.rows = [];
    this.form.courseTimeScheduleId = this.courseTimeScheduleId;
    request = Object.assign(request || {}, this.form);
    const res = await this.usePreviousRequestParamsAsync(async () => {
      return await this.apis.feature.courseTimeScheduleUser.queryCourseTimeScheduleUsers(request as QueryCourseTimeScheduleUserRequest);
    }, request);

    this.rows = res.data.records;
    this.queryUsers(this.rows)
    
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }

  users: Map<number,UserView> = new Map();
  queryUsers(courseTimeScheduleUser: CourseTimeScheduleUserView[]){
    courseTimeScheduleUser.map(async (x)=>{
      await this.apis.feature.user.getUser(x.userId)
      .then((response)=>{
        let user = response.data;
        this.users.set(user.id, user);
      })
    })
  }

  getUser(userId: number){
    return this.users.get(userId);
  }

  onClickReturn(){
    this.page = "list";
  }
}
</script>

<style lang="scss" scoped></style>
