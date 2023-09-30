<template>
  <q-page class="q-pa-md">
    <div class="row">
      <div class="col-12">
        <q-breadcrumbs class="c-hyper-link" separator="〉">
          <q-breadcrumbs-el to="/m/class/index" label="課程歷程" />
          <q-breadcrumbs-el label="課程歷程檢視" />
        </q-breadcrumbs>
      </div>
    </div>
    <div class="row justify-center q-pa-md">
      <div class="col-12 col-lg-10">
        <c-subtitle title="課程歷程"></c-subtitle>
        <div class="row inline justify-center q-mb-lg" style="width: 100%">
          <div class="row inline q-px-md">
            <p class="q-my-none c-heading-h6 c-primary-color-500">課程名稱：</p>
            <p class="q-my-none c-heading-h6 c-primary-color-300">{{ detail.courseName }}</p>
          </div>
          <div class="row inline q-px-md">
            <p class="q-my-none c-heading-h6 c-primary-color-500">年度：</p>
            <p class="q-my-none c-heading-h6 c-primary-color-300">{{ detail.year }}</p>
          </div>
          <div class="row inline q-px-md">
            <p class="q-my-none c-heading-h6 c-primary-color-500">梯次：</p>
            <p class="q-my-none c-heading-h6 c-primary-color-300">{{ detail.classNum }}</p>
          </div>
          <div class="row inline q-px-md">
            <p class="q-my-none c-heading-h6 c-primary-color-500">開課班級與時段：</p>
            <p class="q-my-none c-heading-h6 c-primary-color-300">{{ detail.courseClassSchedule }}</p>
          </div>
        </div>

        <c-table
          :loading="isLoading"
          :columns="columns"
          :detailColumns="detailColumns"
          :rows="rows"
          row-key="id"
          :rowsNumber="rowsNumber"
          class="q-mb-md"
          :detail="false"
        >
          <!-- <template v-slot:body-cell-dateCreate="props">
            <q-td> {{ props.row.dateCreate }}（{{ props.row.creator }}）</q-td>
          </template>

          <template v-slot:body-cell-dateUpdate="props">
            <q-td>
              {{ props.row.dateUpdate }}
            </q-td>
          </template>

          <template v-slot:body-cell-action="props">
            <c-btn-edit
              :to="{
                path: 'detail/' + props.row.id,
              }"
            />
          </template> -->

          <template v-slot:expand="props">
            <c-column-detail :detailColumns="detailColumns" :props="props">
              <template v-slot:detail-cell-name="row">
                <strong
                  >{{ row.label }}
                  <c-colon />
                </strong>
                {{ row.value }}
              </template>
            </c-column-detail>

            <c-entity-detail :value="props.row" />
          </template>
        </c-table>
        <!-- <c-pagination @change="queryAsync" :pagination="pagination" /> -->

        <div class="row justify-center q-mb-lg">
          <q-btn
            rounded
            unelevated
            class="c-heading-h5 c-primary-color-500 c-bgcolor-gray-white c-btn-bold"
            label="回上一頁"
            @click="onClickPrevPage"
          />
        </div>
      </div>
    </div>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { ListComponentBase } from "src/components/ListComponentBase";
import { QueryUserCourseRequest, UserCourseView, SystemConfigView } from "src/api/feature";
import { Prop } from "vue-property-decorator";
import { formatDate, SystemConfig } from "src/util";
import { SystemConfigState } from "src/data/dto/SystemConfigState";

class Detail {
  courseName: string = ""; //課程名稱
  year: string = ""; //年度
  classNum: string = ""; //梯次
  courseClassSchedule: string = ""; //開課班級與時段
}

interface List$ {
  id: number;
  courseName: string; //課程名稱
  year: string; //年度
  classNum: string; //梯次
  courseClassSchedule: string; //開課班級與時段
  attendanceType: string; //出勤狀態
  attendanceDate: string; //實際上課日期

  //detailColumns
  memo?: string;
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

  components: {},
})
export default class CourseHistoryDetail extends ListComponentBase {
  rowsNumber = 0;
  isLoading = true;

  @Prop({ type: Boolean })
  isList = false;

  @Prop({ type: Detail })
  detail!: Detail;

  columns = [
    {
      label: "出勤狀態",
      align: "center",
      name: "attendanceType",
      field: (row: List$) => this.convertDisplayText(this.attendanceTypeList, row.attendanceType),
      sortable: true,
    },
    {
      label: "實際上課日期",
      align: "center",
      name: "attendanceDate",
      field: (row: List$) => formatDate(row.attendanceDate),
      sortable: true,
    },
  ];

  detailColumns = [
    {
      label: "名稱",
      name: "memo",
      field: (row: List$) => row.memo,
    },
    {
      label: "建立時間",
      name: "dateCreate",
      field: (row: List$) => formatDate(row.dateCreate),
    },
  ];

  rows: Array<UserCourseView> = [];

  attendanceTypeList = new Array<SystemConfigState>();

  async mounted() {
    this.attendanceTypeList = this.$appStore.getters.getSystemConfig(SystemConfig.MeetAttendanceType);

    await this.queryAsync();
  }

  async queryAsync() {
    this.isLoading = true;

    let request = {
      userId: this.$appStore.getters.userProfile.id,
      courseName: this.detail.courseName,
    } as QueryUserCourseRequest;

    const res = await this.usePreviousRequestParamsAsync(async () => {
      return await this.apis.feature.userCourse.queryUserCourses(request);
    }, request);

    this.rows = res.data.records;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }

  convertDisplayText(systemConfigList: Array<SystemConfigView>, index: string) {
    const found = systemConfigList.find((e) => e.name == index);
    if (found) return found.value;
    return index;
  }

  onClickPrevPage() {
    this.$appStore.mutations.setIsCourseList(true);
  }
}
</script>

<style lang="scss" scoped></style>
