<template>
  <q-page class="q-pa-lg">
    <q-form @submit="submitAsync" class="q-mx-auto">
      <c-subtitle title="開課管理"></c-subtitle>
      <c-form-card bordered="false">
        <c-column label="課程分類" :required=true>
          <c-form-course-management-type v-model="form.courseManagementTypeId" outlined clearable dense
            :rules="[(val) => !!val || '請選擇課程分類']" />
        </c-column>
        <c-column label="課程名稱" :required=true>
          <c-form-course-management v-model:courseManagementId.sync="form.courseManagementId"
            :course-management-type-id="form.courseManagementTypeId" outlined clearable dense
            :rules="[(val) => !!val || '請選擇課程名稱']" />
        </c-column>
        <c-column label="課程類型">
          <q-radio v-model="form.courseType" val="" label="全部" />
          <q-radio v-model="form.courseType" val="0" label="實體" />
          <q-radio v-model="form.courseType" val="1" label="線上" />
        </c-column>
        <c-column label="堂點">
          <c-form-organization v-model="form.organizationId" outlined clearable dense></c-form-organization>
        </c-column>
        <c-column label="課程名稱備註">
          <c-input v-model="form.name" dense></c-input>
        </c-column>
        <c-column label="年度" :required=true>
          <c-input v-model="form.year" dense :rules="[(val) => !!val || '請輸入年度']" />
        </c-column>
        <c-column label="季">
          <c-input v-model="form.season" dense></c-input>
        </c-column>
        <c-column label="梯次">
          <c-input v-model="form.classNum" dense></c-input>
        </c-column>
        <c-column label="課程圖片上傳">
          <c-btn-upload category="course" @uploaded="handleCourseFileUploaded" dense />
        </c-column>
        <c-column label="早鳥價格">
          <div v-for="item in form.coursePrices" :key="item.priceName">
            <c-input v-if="item.isDueDate === 'Y'" type="number" v-model="item.price" dense></c-input>
          </div>
        </c-column>
        <c-column label="早鳥日期">
          <c-date-picker v-model="form.discountSignUpDate" dense></c-date-picker>
        </c-column>
        <c-column label="原價格" :required=true>
          <div v-for="item in form.coursePrices" :key="item.priceName">
            <c-input v-if="item.isDueDate === 'N'" type="number" v-model="item.price" dense :rules="[priceRule]" />
          </div>
        </c-column>
        <c-column label="報名日期">
          <q-radio v-model="form.courseSignUpType" val="0" label="線上" class="q-ml-sm" />
          <q-radio v-model="form.courseSignUpType" val="1" label="臨櫃" class="q-ml-sm" />
          <c-row v-if="form.courseSignUpType == '1'">
            <div class="col-6">
              <c-date-picker v-model="form.signUpDateS" class="q-ml-md"></c-date-picker>
            </div>
            <div class="col-6">
              <c-date-picker v-model="form.signUpDateE" class="q-ml-md"></c-date-picker>
            </div>
          </c-row>
          <c-row v-if="form.courseSignUpType == '0'">
            <div class="col-6">
              <c-date-picker v-model="form.signUpDateS" class="q-ml-md"></c-date-picker>
            </div>
            <div class="col-6">
              <c-date-picker v-model="form.signUpDateE" class="q-ml-md"></c-date-picker>
            </div>
          </c-row>
        </c-column>
        <c-field :rules="[openDateRule]" dense>
          <c-column label="開課日期" :required=true>
            <c-row>
              <div class="col-6">
                <c-date-picker v-model="form.openDateS" class="q-ml-md"></c-date-picker>
              </div>
              <div class="col-6">
                <c-date-picker v-model="form.openDateE" class="q-ml-md"></c-date-picker>
              </div>
            </c-row>
          </c-column>
        </c-field>
        <c-column label="開課班級與時段" :required=true>
          <c-field :rules="[openTimeRule]" dense>
            <c-row v-for="item in form.courseTimeSchedules" :key="item.name">
              <c-input v-model="item.name" placeholder="請輸入班級名稱，例：A班" dense></c-input>
              <c-select v-model="item.classDay" :options="weekList" label="星期" emit-value map-options dense></c-select>
              <c-date-picker range time :value="{ from: item.classTimeS, to: item.classTimeE }"
                @update:model-value="item.classTimeS = $event.from; item.classTimeE = $event.to" dense />
              <c-input type="number" v-model="item.quota" placeholder="輸入人數" suffix="人" dense />
            </c-row>
          </c-field>
          <q-btn flat icon="add" @click="addSchedule()"></q-btn>
        </c-column>
        <c-column label="開課總人數限制">
          <c-input type="number" v-model="form.quota" dense></c-input>
        </c-column>
        <c-column label="講師設定">
          <c-row>
            <c-select class="col col-md" placeholder="從名單中選擇" v-model="selectedTeachers" emit-value map-options
              :options="selectedTeachers" option-value="id" option-label="name" clearble multiple>
            </c-select>
            <div class="row-lab col-auto items-end q-pt-lg">
              <q-btn dense outline icon="more_horiz" @click="指定講師視窗 = true; queryTeachersAsync()"></q-btn>
            </div>
            <c-input class="row-lab col-12 col-md-2" placeholder="從名單中選擇" v-model="form.teacherNames">
              <template v-slot:append><q-btn dense outline icon="more_horiz"
                  @click="指定講師視窗 = true; queryTeachersAsync()"></q-btn></template>
            </c-input>
            <c-input class="row-lab col-12 col-md-2" placeholder="輸入其他講師"></c-input>
          </c-row>
        </c-column>
        <c-column label="課程內容" :required=true>
          <c-input type="textarea" v-model="form.courseContext" clearable dense outlined
            :rules="[(val) => !!val || '請選擇課程名稱']" />
        </c-column>
        <c-column label="對象資格說明">
          <c-input type="textarea" v-model="form.description" clearable dense outlined></c-input>
        </c-column>
        <c-column label="結業資格說明">
          <c-input type="textarea" v-model="form.graduationQualification" clearable dense outlined></c-input>
        </c-column>
        <c-column label="前台特殊需求">
          <q-radio v-model="form.specialRequirement" val="1" label="顯示" />
          <q-radio v-model="form.specialRequirement" val="0" label="不顯示" />
        </c-column>
        <c-column label="狀態" :required=true :rules="[(val) => !!val || '請選擇課程名稱']">
          <c-form-status-cd v-model="form.statusCd" clearable dense />
        </c-column>
        <c-column label="表單上傳">
          <c-btn-upload category="course" @uploaded="handleFormFileUploaded" dense />
        </c-column>
      </c-form-card>

      <c-subtitle title="設定課程擋修與上課對象"></c-subtitle>
      <c-form-card>
        <c-column label="先修課程">
          <c-form-group-course-management
            v-for="(value, key) in form.courseManagementFilter.courseManagementFilterCourses" :key="key" class="q-mb-sm"
            v-model:courseManagementId="value.courseManagementId"
            v-model:courseManagementTypeId="value.courseManagementTypeId" outlined clearable dense />
          <q-btn flat icon="add" @click="addCourseManagementFilterCourse()"></q-btn>
        </c-column>
        <c-column label="性別">
          <c-form-gender v-model="form.courseManagementFilter.courseSex" />
        </c-column>
        <c-column label="年齡限制">
          <c-input v-model="form.courseManagementFilter.ageUp">
            <template v-slot:append><small>以上</small></template>
          </c-input>
          <c-input v-model="form.courseManagementFilter.ageDown">
            <template v-slot:append><small>以下</small></template>
          </c-input>
        </c-column>
        <c-column label="牧養職分">
          <q-checkbox v-for="(value, index) in ministryRespList" :key="index" v-model="pastoralFilter" :label="value.name"
            :val="value.id" />
        </c-column>
        <c-column label="事工團">
          <c-form-group-ministry v-for="(value, key) in respFilter" :key="key" v-model:ministryId="value.ministry"
            v-model:ministryRespId="value.ministryResp"></c-form-group-ministry>
          <q-btn round flat icon="add" @click="addRespFilters()"></q-btn>
        </c-column>
      </c-form-card>

      <c-subtitle title="指定報名設定"></c-subtitle>
      <c-form-card>
        <c-column label="限定報名會友">
          <c-select v-model="selectedUsers" emit-value map-options :options="selectedUsers" option-value="id"
            option-label="name" clearble multiple />
          <template v-slot:append><q-btn dense outline icon="more_horiz"
              @click="限定報名會友視窗 = true; queryUserAsync()"></q-btn></template>
        </c-column>
      </c-form-card>

      <div class="q-gutter-md q-px-md">
        <c-btn-save type="submit" />
        <c-btn-remove v-if="isUpdateMode" @click="removeAsync" class="q-mr-md" />
        <c-btn-history-back class="q-mr-md" />
      </div>
      <q-dialog v-model="限定報名會友視窗">
        <q-card style="width: 1000px">
          <div class="bg-cyan-8 text-white text-center text-h6">限定報名會友</div>
          <div class="q-px-md q-py-sm">
            <c-row>
              <c-column label="堂點">
                <c-row>
                  <c-form-organization v-model="userForm.organizationId" role="search" placeholder="選擇分點" outlined
                    clearable dense class="col-sm-6" />
                  <c-form-organization v-model="userForm.organizationId2" role="search" placeholder="選擇分點" outlined
                    clearable dense class="col-sm-6" />
                </c-row>
              </c-column>
            </c-row>
            <c-row>
              <c-column label="牧區" class="col-sm-6">
                <c-form-pastoral v-model="userForm.pastoralId" role="search" placeholder="請選擇" outlined clearable dense />
              </c-column>
              <c-column label="督區" class="col-sm-6">
                <c-form-pastoral v-model="userForm.pastoralId1" role="search" placeholder="請選擇" outlined clearable
                  dense />
              </c-column>
            </c-row>
            <c-row>
              <c-column label="區" class="col-sm-6">
                <c-form-pastoral v-model="userForm.pastoralId2" role="search" placeholder="請選擇" outlined clearable
                  dense />
              </c-column>
              <c-column label="小組" class="col-sm-6">
                <c-form-pastoral v-model="userForm.pastoralId3" role="search" placeholder="請選擇" outlined clearable
                  dense />
              </c-column>
            </c-row>
            <c-row>
              <c-column label="姓名" class="col-sm-6">
                <c-input placeholder="請輸入" v-model="userForm.name"></c-input>
              </c-column>
              <c-column label="手機" class="col-sm-6">
                <c-input placeholder="請輸入" v-model="userForm.cellPhone"></c-input>
              </c-column>
            </c-row>
            <c-row>
              <c-column label="性別" class="col-sm-6">
                <c-form-gender v-model="userForm.genderType"></c-form-gender>
              </c-column>
              <q-space></q-space>
              <div class="self-end q-pb-lg">
                <c-btn-search></c-btn-search>
              </div>
            </c-row>
            <q-table flat :columns="userColumns" :rows="userRows" row-key="id" selection="multiple"
              v-model:selected="selectedUsers" rows-per-page-label="每頁筆數"
              :pagination-label="(起, 迄, 數) => '第' + 起 + '/' + 迄 + '頁，共' + 數 + '筆'"></q-table>
            <hr>
            <div class="text-center">
              <q-btn rounded color="indigo" unelevated class="q-mx-sm" @click="setUsers(); 限定報名會友視窗 = false">送出</q-btn>
              <q-btn rounded color="indigo" outline class="q-mx-sm" @click="限定報名會友視窗 = false">取消</q-btn>
            </div>
          </div>
        </q-card>
      </q-dialog>
      <q-dialog v-model="指定講師視窗" style="width:750px">
        <q-card>
          <div class="bg-cyan-8 text-white text-center text-h6">指定講師</div>
          <q-form>
            <div class="q-px-md q-py-sm">
              <c-row>
                <c-column label="堂點">
                  <c-row>
                    <c-form-organization v-model="teacherForm.organizationId" role="search" placeholder="選擇分點" outlined
                      clearable dense class="col-sm-6" />
                    <c-form-organization v-model="teacherForm.organizationId2" role="search" placeholder="選擇分點" outlined
                      clearable dense class="col-sm-6" />
                  </c-row>
                </c-column>
              </c-row>
              <c-row>
                <c-column label="姓名" class="col-sm-6">
                  <c-input placeholder="請輸入" v-model="teacherForm.name" clearable></c-input>
                </c-column>
                <c-column label="手機" class="col-sm-6">
                  <c-input placeholder="請輸入" v-model="teacherForm.phone"></c-input>
                </c-column>
              </c-row>
              <c-row>
                <c-column label="性別" class="col-sm-6">
                  <c-form-gender v-model="teacherForm.genderType"></c-form-gender>
                </c-column>
                <q-space></q-space>
                <div class="self-end q-pb-lg">
                  <c-btn-search @click="queryTeachersAsync"></c-btn-search>
                </div>
              </c-row>
              <q-table flat :columns="指定講師欄位" :rows="teacherRows" row-key="id" selection="multiple"
                v-model:selected="selectedTeachers" rows-per-page-label="每頁筆數"
                :pagination-label="(起, 迄, 數) => '第' + 起 + '/' + 迄 + '頁，共' + 數 + '筆'"></q-table>
              <hr>
              <div class="text-center">
                <q-btn rounded color="indigo" unelevated class="q-mx-sm" @click="setTeachers(); 指定講師視窗 = false">送出</q-btn>
                <q-btn rounded color="indigo" outline class="q-mx-sm" @click="指定講師視窗 = false">取消</q-btn>
              </div>
            </div>
          </q-form>
        </q-card>
      </q-dialog>
    </q-form>
  </q-page>
</template>

<script lang="ts">
import FormCourse from "components/business/FormCourse.vue";
import FormCourseManagementType from "components/business/FormCourseManagementType.vue";
import FormOrganization from "components/business/FormOrganization.vue";
import FormTeacher from "components/business/FormTeacher.vue";
import FormGroupCourseManagement from "components/formGroup/FormGroupCourseManagement.vue";
import FormGroupMinistry from "components/formGroup/FormGroupMinistry.vue";
import {
CourseManagementView,
CreateCourseCommand,
DeleteCourseCommand,
MinistryRespView,
QueryCourseManagementRequest,
QueryTeacherRequest, QueryUserRequest,
UpdateCourseCommand
} from "src/api/feature";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import FormCourseManagement from "src/components/business/FormCourseManagement.vue";
import { FileUploadedEvent } from "src/data/dto";
import { CourseAppendixType, convertCourseManagementStatus } from "src/services";
import { formatDate } from "src/util";
import { WithLoading } from "src/util/TsDecorators";
import { Options } from "vue-class-component";
import { Watch } from "vue-property-decorator";

class Teacher {
  teacherId = 1;
  id = 1
  name = ""
  genderType = "";
  cellphone1 = "";
}

class CourseSchedule$ {
  name: string = "";
  classDay: string = "";
  classTimeS: string = "";
  classTimeE: string = "";
  quota: number = 0;
}

interface CoursePrice$ {
  priceName: string;
  price: number | null;
  isDueDate: string;
}

interface CourseAppendix$ {
  appendixType: string;
  path: string;
}

interface MinistryRespView$ extends MinistryRespView {
  checked: boolean;
}

interface RespFilter {
  id: number | undefined;
  ministry: number | undefined;
  ministryResp: number | undefined;
}

interface CourseManagementFilterCourse$ {
  id: undefined,
  courseManagementTypeId: undefined,
  courseManagementId: undefined,
}

interface CourseManagementFilterPastoral$ {
  pastoralId: number;
}

interface CourseManagementFilterResp$ {
  ministryRespId: number | undefined;
}

interface CourseManagementFilterUser$ {
  userId: number;
}

class User {
  id = 1;
  name = "";
  organizations = "";
  pastorals = "";
  genderType = "";
  cellphone1 = "";
}

interface OrganizationTree {
  id: number;
  name: string;
}

interface PastoralTree {
  id: number;
  name: string;
}

@Options({
  meta() {
    return {
      title: "詳細資料",
    };
  },

  components: {
    "c-form-course-management-type": FormCourseManagementType,
    "c-form-course-management": FormCourseManagement,
    "c-form-organization": FormOrganization,
    "c-form-teacher": FormTeacher,
    "c-form-course": FormCourse,
    "c-form-group-ministry": FormGroupMinistry,
    "c-form-group-course-management": FormGroupCourseManagement,
  },
})
export default class Detail extends DetailComponentBase {
  weekList = [
    { label: "星期一", value: "1", },
    { label: "星期二", value: "2", },
    { label: "星期三", value: "3", },
    { label: "星期四", value: "4", },
    { label: "星期五", value: "5", },
    { label: "星期六", value: "6", },
    { label: "星期日", value: "7", },
  ];
  ministryList = [
    { label: "不限身份", value: "0" },
    { label: "小組員", value: "1" },
    { label: "小組長", value: "2" },
    { label: "區長", value: "3" },
    { label: "區督", value: "4" },
    { label: "區牧", value: "5" },
  ]
  teacherForm = {
    organizationId: undefined,
    organizationId1: undefined,
    organizationId2: undefined,
    name: "",
    phone: "",
    genderType: "",
  }
  userForm = {
    organizationId: undefined,
    organizationId2: undefined,
    pastoralId: undefined,
    pastoralId1: undefined,
    pastoralId2: undefined,
    pastoralId3: undefined,
    pastoralId4: undefined,
    pastoralId5: undefined,
    name: "",
    cellPhone: "",
    genderType: "",
  }
  form = {
    courseManagementTypeId: undefined,
    courseManagementId: undefined,
    courseManagementStatus: "",
    courseManagementNo: "",
    courseManagementType: "",
    organizationId: undefined,
    title: "",
    year: "",
    season: "",
    classNum: "",
    openDate: "",
    openDateS: "",
    openDateE: "",
    signUpDateS: "",
    signUpDateE: "",
    classTimeS: "",
    classTimeE: "",
    courseSignUpType: null,
    signUpDate: "",
    wishCount: 0,
    needRecommend: "",
    acceptNewMember: "",
    discountPrice: null,
    discountSignUpDate: "",
    description: "",
    classCount: 0,
    quota: 0,
    graduationType: "",
    logo: "",
    courseType: "",
    statusCd: "1",
    name: "",
    teacherNames: "",
    courseContext: "",
    graduationQualification: "",
    specialRequirement: "",
    teachers: new Array<Teacher>(),
    courseTimeSchedules: [new CourseSchedule$()],
    coursePrices: new Array<CoursePrice$>(),
    courseAppendices: new Array<CourseAppendix$>(),
    courseManagementFilter: {
      courseSex: "",
      ageUp: undefined,
      ageDown: undefined,
      courseManagementFilterCourses: new Array<CourseManagementFilterCourse$>(),
      courseManagementFilterPastorals: Array<CourseManagementFilterPastoral$>(),
      courseManagementFilterResps: Array<CourseManagementFilterResp$>(),
      courseManagementFilterUsers: Array<CourseManagementFilterUser$>(),
    },
  };
  限定報名會友視窗 = false;
  userColumns = [
    { label: "", name: "checkbox", field: (row: User) => row.id, },
    { label: "分堂", name: "name", field: (row: User) => "", },
    { label: "分點", name: "name", field: (row: User) => "", },
    { label: "牧區", name: "name", field: (row: User) => "", },
    { label: "督區", name: "name", field: (row: User) => "", },
    { label: "區", name: "name", field: (row: User) => "", },
    { label: "小組", name: "name", field: (row: User) => "", },
    { label: "姓名", name: "name", field: (row: User) => row.name, },
    { label: "性別", name: "genderType", field: (row: User) => row.genderType === "0" ? "女" : "男", },
    { label: "手機", name: "cellphone1", field: (row: User) => row.cellphone1, },
  ];
  指定講師視窗 = false;
  指定講師欄位 = [
    { label: "", name: "checkbox", field: (row: Teacher) => row.id, },
    { label: "分堂", name: "name", field: (row: Teacher) => "台中市旌旗協會", },
    { label: "分點", name: "name", field: (row: Teacher) => "台中旌旗教會", },
    { label: "姓名", name: "name", field: (row: Teacher) => row.name, },
    { label: "性別", name: "genderType", field: (row: User) => row.genderType === "0" ? "女" : "男", },
    { label: "手機", name: "cellphone1", field: (row: Teacher) => row.cellphone1, },
  ];
  userRows: Array<User> = [new User()];
  selectedUsers: Array<User> = [];
  teacherRows: Array<Teacher> = [];
  teachers: Array<Teacher> = [new Teacher()];
  selectedTeachers: Array<Teacher> = [];
  courseManagement!: CourseManagementView;
  ministryRespList = Array<MinistryRespView>();
  ministryRespMap = new Map<number, MinistryRespView>();
  respFilter: Array<RespFilter> = [];
  pastoralFilter: Array<number> = [];

  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.form.name;
  }

  get deleteKey() {
    return this.id as unknown as number;
  }

  get formState() {
    return {
      coursePrices: this.form.coursePrices.filter(e => e.price != null)
    };
  }

  @Watch("form.courseManagementId", { immediate: true, deep: true })
  async onCourseManagementIdChanged(val: number) {
    const res = await this.apis.feature.courseManagement.queryCourseManagements({
      id: val,
    } as QueryCourseManagementRequest);

    if (res.data.size > 0) {
      this.form.courseManagementStatus =
        convertCourseManagementStatus(res.data.records[0].courseManagementStatus);
    }
  }

  @WithLoading()
  async mounted() {
    await this.apis.feature.ministryResp.fetchMinistryResps()
      .then((response) => {
        this.ministryRespList = response.data;
      })

    if (this.isUpdateMode) {
      const res = await this.apis.feature.course.getCourse(this.deleteKey);

      Object.assign(this.form, res.data);

      this.form.openDate = formatDate(this.form.openDate, "YYYY-MM-DD");
      this.form.openDateS = formatDate(this.form.openDateS, "YYYY-MM-DD");
      this.form.openDateE = formatDate(this.form.openDateE, "YYYY-MM-DD");
      this.form.signUpDateS = formatDate(this.form.signUpDateS, "YYYY-MM-DD");
      this.form.signUpDateE = formatDate(this.form.signUpDateE, "YYYY-MM-DD");
      this.form.signUpDate = formatDate(this.form.signUpDate, "YYYY-MM-DD");
      this.form.discountSignUpDate = formatDate(this.form.discountSignUpDate, "YYYY-MM-DD");

      if (res.data.courseManagementFilterId !== 0) {
        await this.apis.feature.courseManagementFilter.getCourseManagementFilter(res.data.courseManagementFilterId)
          .then(res => {
            Object.assign(this.form, res.data);
          })
      }

      await this.apis.feature.courseManagement.getCourseManagement(this.form.courseManagementId || 0)
        .then(res1 => {
          this.courseManagement = res1.data;
          Object.assign(this.form, this.courseManagement);
        });

    } else {
      this.addCourseManagementFilterCourse();
      this.addRespFilters();
    }

    if (this.form.coursePrices.length === 0) {
      this.form.coursePrices.push({
        priceName: "原價",
        price: null,
        isDueDate: "N",
      });
      this.form.coursePrices.push({
        priceName: "早鳥價",
        price: null,
        isDueDate: "Y",
      });
    }
  }

  @WithLoading()
  async submitAsync() {
    this.saveState();
    if (this.isUpdateMode) {
      await this.updateAsync();
    } else {
      await this.createAsync();
    }

    this.showSuccessNotify("儲存成功");
  }

  saveState() {
    this.form.openDate = this.form.openDateS;
    this.form.courseManagementFilter.courseManagementFilterUsers = this.selectedUsers.map(e => ({
      userId: e.id,
    }))
    this.form.courseManagementFilter.courseManagementFilterPastorals = this.pastoralFilter.map(e => ({
      pastoralId: e
    }));
    this.form.courseManagementFilter.courseManagementFilterResps = this.respFilter
      .map(e => ({ ministryRespId: e.ministryResp, }))
      .filter(e => e.ministryRespId != null && e.ministryRespId != undefined)
  }

  async createAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form, this.formState) as unknown as CreateCourseCommand;
      await this.apis.feature.course.createCourse(request);
      //this.$router.go(-1);
    });
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form, this.formState);
      await this.apis.feature.course.putCourse(request as unknown as UpdateCourseCommand);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.course.deleteCourse(request as unknown as DeleteCourseCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }

  addSchedule() {
    this.form.courseTimeSchedules.push({
      name: "",
      classDay: "",
      classTimeS: "",
      classTimeE: "",
      quota: 0,
    });
  }

  addCourseManagementFilterCourse() {
    this.form.courseManagementFilter.courseManagementFilterCourses.push({
      id: undefined,
      courseManagementTypeId: undefined,
      courseManagementId: undefined,
    });
  }

  addRespFilters() {
    this.respFilter.push({
      id: undefined,
      ministry: undefined,
      ministryResp: undefined
    });

    this.form.courseManagementFilter.courseManagementFilterResps.push({
      ministryRespId: undefined,
    })
  }

  handleFormFileUploaded(e: FileUploadedEvent) {
    this.saveCourseAppendixState(CourseAppendixType.File, e.fileKey);
  }

  handleCourseFileUploaded(e: FileUploadedEvent) {
    this.saveCourseAppendixState(CourseAppendixType.Cover, e.fileKey);
  }

  saveCourseAppendixState(appendixType: CourseAppendixType, fileKey: string) {
    if (this.form.courseAppendices == null) {
      this.form.courseAppendices = new Array<CourseAppendix$>();
    }
    const found = this.form.courseAppendices.find(e => e.appendixType == appendixType.toString());
    if (found) {
      found.path = fileKey;
    } else {
      this.form.courseAppendices.push({
        appendixType: appendixType.toString(),
        path: fileKey,
      },
      );
    }
  }

  openDateRule() {
    if (this.form.openDateS && this.form.openDateE) {
      return true;
    }
    return "請選擇開課日期";
  }

  openTimeRule() {
    for (const e of this.form.courseTimeSchedules) {
      console.log(e.name && e.classTimeS && e.classTimeE && e.quota && e.classDay);
      if (e.name && e.classTimeS && e.classTimeE && e.quota && e.classDay) {
        return true;
      }
    }
    return "請輸入開課班級與時段所有欄位";
  }

  priceRule(val: string) {
    if (val) {
      return true;
    }
    return "請輸入原價";
  }

  async getMinistryResp() {
    await this.apis.feature.ministryResp.fetchMinistryResps()
      .then((response) => {
        if (response.data) {
          this.ministryRespList = response.data;
          response.data.map((x) => {
            this.ministryRespMap.set(x.id, x);
          })
        }
      })
  }

  async queryUserAsync() {
    const request = Object.assign({ size: 3000 }, this.userForm);
    await this.apis.feature.user.queryUsers(request as unknown as QueryUserRequest)
      .then(res => {
        this.userRows = res.data.records.map(e => ({
          id: e.id,
          name: e.name,
          organizations: "",
          pastorals: "",
          genderType: e.genderType,
          cellphone1: e.cellPhone1
        }))
        console.log(this.userRows)
      });
  }
  async queryTeachersAsync() {
    const request = Object.assign({ size: 3000 }, this.teacherForm);
    await this.apis.feature.teacher.queryTeachers(request as unknown as QueryTeacherRequest)
      .then(res => {
        this.teacherRows = res.data.records.map(e => ({
          teacherId: e.id,
          id: e.id,
          name: e.name,
          organizations: "",
          pastorals: "",
          genderType: e.genderType,
          cellphone1: e.cellPhone1
        }))
      })
  }
  setTeachers() {
    this.form.teachers = this.selectedTeachers
    this.form.teacherNames = this.form.teachers.map(e => { return e.name }).join(",")
  }
  setUsers() {
    this.form.courseManagementFilter.courseManagementFilterUsers = this.selectedUsers.map(e => ({
      userId: e.id
    }))
  }
}
</script>

<style lang="scss" scoped>
.row-lab {
  margin-right: 50px;
}
</style>
