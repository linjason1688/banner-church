<template>
  <q-page class="q-pa-lg">
    <q-breadcrumbs class="q-mb-md">
      <q-breadcrumbs-el v-for="breadcrumb in ['牧養管理', '成人會友資料管理', '編輯']" :key="breadcrumb" :label="breadcrumb" />
    </q-breadcrumbs>
    <q-form @submit="submitAsync">
      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">基本資料</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <c-subtitle title="帳戶資訊" />
        <q-card class="q-pa-md q-mb-md">
          <c-column label="帳號" required>
            <c-input placeholder="請輸入帳號" v-model="form.name" :rules="[(val) => !!val || '請輸入帳號']"></c-input>
          </c-column>
          <c-column label="密碼" required>
            <c-input placeholder="請輸入8-12位英數字" v-model="form.password" :type="isPwd ? 'password' : 'text'">
              <template v-slot:append>
                <q-icon :name="isPwd ? 'visibility_off' : 'visibility'" class="cursor-pointer" @click="isPwd = !isPwd" />
              </template>
            </c-input>
          </c-column>
        </q-card>
        <c-subtitle title="個人資料" />
        <q-card class="q-pa-md q-mb-md">
          <c-column label="姓名">
            <c-input placeholder="姓名" v-model="form.name"></c-input>
          </c-column>
          <c-column label="性別">
            <c-form-gender v-model="form.genderType" />
          </c-column>
          <c-column label="身分證字號 (或居留證 / 護照號碼)">
            <c-input placeholder="請輸入身分證字號或居留證 / 護照號碼" v-model="form.idNumber"></c-input>
          </c-column>
          <c-column label="出生年月日(西元)">
            <c-date-picker v-model="form.birthday"></c-date-picker>
          </c-column>
          <c-column label="教育程度">
            <c-form-system-config v-model="form.eduType" systemConfig="EduType" />
          </c-column>
          <c-column label="職業">
            <c-form-system-config v-model="form.jobType" systemConfig="JobType" />
          </c-column>
          <c-column label="婚姻" required>
            <q-radio v-model="form.isMarried" val="0" label="未婚" />
            <q-radio v-model="form.isMarried" val="1" label="已婚" />
          </c-column>
        </q-card>
        <c-subtitle title="信仰資料" />
        <q-card class="q-pa-md q-mb-md">
          <c-column label="信仰狀態及受洗資料" required>
            <q-radio class="full-width" v-model="form.baptizedType" label="已受洗" val="0" />
            <div class="q-pl-xl" v-if="form.baptizedType === '0'">
              <c-column label="受洗時間">
                <c-date-picker v-model="form.baptizedTime" />
              </c-column>
              <c-column label="過去在哪個教會">
                <q-radio class="full-width" v-model="form.churchType" label="旌旗教會" val="0" />
                <q-radio class="full-width" v-model="form.churchType" label="其他教會" val="1" />
                <q-input v-if="form.churchType === '1'" placeholder="填入教會名稱" v-model="form.anotherChurchName" />
              </c-column>
              <c-column label="教會施洗者(若為旌旗教會者)">
                <q-input placeholder="輸入施洗者姓名" v-model="form.baptizedPerson" />
              </c-column>
            </div>
            <q-radio class="full-width" v-model="form.baptizedType" label="未受洗" val="1" />
            <q-radio class="full-width" v-model="form.baptizedType" label="其他" val="2" />
            <div class="q-pl-xl" v-if="form.baptizedType === '2'">
              <q-input placeholder="填入其他狀態" v-model="form.remark" />
            </div>
          </c-column>
        </q-card>
        <c-subtitle title="社群資料" />
        <q-field :rules="[societyRule]">
          <template v-slot:control>
            <q-card class="q-pa-md q-mb-md full-width">
              <c-column label="社群帳號" required class="col-12" />
              <c-column label="Line" class="col-12">
                <c-input placeholder="" v-model="form.lineId"></c-input>
              </c-column>
              <c-column label="Instagram" class="col-12">
                <c-input placeholder="" v-model="form.instagramId"></c-input>
              </c-column>
              <c-column label="WeChat" class="col-12">
                <c-input placeholder="" v-model="form.weChatId"></c-input>
              </c-column>
              <c-column label="其他" class="col-12">
                <c-input placeholder="若沒有社群帳號請填寫：無" v-model="form.otherSocialId"></c-input>
              </c-column>
            </q-card>
          </template>
        </q-field>
        <c-subtitle title="通訊資料" />
        <q-card class="q-pa-md q-mb-md">
          <c-column label="居住國家" required>
            <c-form-system-config v-model="form.liveCountry" systemConfig="CountryCode" />
          </c-column>
          <c-row v-if="xform.domestic">
            <c-column label="城市" class="col-12 col-sm-6">
              <c-form-system-config v-model="form.liveCity" systemConfig="CityCode" />
            </c-column>
            <c-column label="地區" class="col-12 col-sm-6">
              <c-select v-model="form.liveZipArea" emit-value map-options :options="areaCodeList" class="q-px-md q-mb-md"
                dense option-value="name" option-label="value" />
            </c-column>
            <c-column label="郵遞區號" class="col-12">
              <c-input placeholder="" v-model="form.liveZipCode"></c-input>
            </c-column>
            <c-column label="詳細住址" class="col-12">
              <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
            </c-column>
          </c-row>
          <c-row v-else>
            <c-column label="住址1" class="col-12">
              <q-input placeholder="輸入地址" v-model="form.liveAddress" />
            </c-column>
            <c-column label="住址2" class="col-12">
              <q-input placeholder="輸入地址" v-model="form.liveAddress2" />
            </c-column>
            <c-column label="郵遞區號" class="col-12">
              <q-input placeholder="" v-model="form.liveZipCode" />
            </c-column>
          </c-row>
        </q-card>
        <q-card class="q-pa-md q-mb-md">
          <c-column label="手機號碼">
            <template v-slot:prepend>
              <c-select emit-value map-options :options="countryCodeList" v-model="form.cellAreaCode1"
                option-label="value" option-value="name" :rules="[(val) => !!val || '國碼']" />
            </template>
            <c-input placeholder="輸入手機號碼" v-model="form.cellPhone1" :rules="[(val) => !!val || '手機號碼']"></c-input>
          </c-column>
          <c-column label="手機號碼2">
            <template v-slot:prepend>
              <c-select emit-value map-options :options="countryCodeList" v-model="form.cellAreaCode2"
                option-label="value" option-value="name" />
            </template>
            <c-input placeholder="輸入手機號碼" v-model="form.cellPhone2"></c-input>
          </c-column>
          <c-column label="電話 (市話)">
            <c-input placeholder="輸入電話" v-model="form.phone"></c-input>
          </c-column>
          <c-column label="Email *">
            <c-input placeholder="請輸入Email" v-model="form.email1"></c-input>
          </c-column>
          <c-column label="Email2">
            <c-input placeholder="請輸入Email2" v-model="form.email2"></c-input>
          </c-column>
        </q-card>
        <c-subtitle title="入組意願調查" />
        <q-card class="q-pa-md q-mb-md">
          <q-radio class="full-width" v-model="xform.isJoinChurchGroup" val="0" label="只是訪客，暫無入組意願" />
          <q-radio class="full-width" v-model="xform.isJoinChurchGroup" val="1" label="對加入小組有意願" />
          <div class="q-ml-sm" v-if="xform.isJoinChurchGroup === '1'">
            <q-checkbox v-model="xform.join" label="實體" />
            <q-card flat bordered class="q-pa-md q-ml-xl q-mr-md c-dotted-border">
              <c-form-group-meetup sequence="1" meetupCategory="offline" v-model:day.sync="form.joinInPersonDate1"
                v-model:time.sync="form.joinInPersonTime1" v-model:church.sync="form.joinInPersonLocation1" />
              <c-form-group-meetup sequence="2" meetupCategory="offline" v-model:day.sync="form.joinInPersonDate2"
                v-model:time.sync="form.joinInPersonTime2" v-model:church.sync="form.joinInPersonLocation2" />
              <c-form-group-meetup sequence="3" meetupCategory="offline" v-model:day.sync="form.joinInPersonDate3"
                v-model:time.sync="form.joinInPersonTime3" v-model:church.sync="form.joinInPersonLocation3" />
            </q-card>
            <q-checkbox v-model="xform.online" label="線上" />
            <q-card flat bordered class="q-pa-md q-ml-xl q-mr-md c-dotted-border">
              <c-form-group-meetup sequence="1" meetupCategory="online" v-model:day.sync="form.joinOnlineDate1"
                v-model:time.sync="form.joinOnlineTime1" />
              <c-form-group-meetup sequence="2" meetupCategory="online" v-model:day.sync="form.joinOnlineDate2"
                v-model:time.sync="form.joinOnlineTime2" />
              <c-form-group-meetup sequence="3" meetupCategory="online" v-model:day.sync="form.joinOnlineDate3"
                v-model:time.sync="form.joinOnlineTime3" />
            </q-card>
            <q-radio class="full-width" v-model="xform.isJoinChurchGroup" val="2" label="已參加小組" />
            <c-input-gutter role="edit2" v-model="form.churchGroupNo" placeholder="請填入小組編號"
              v-if="xform.isJoinChurchGroup === '2'" />
          </div>
        </q-card>
      </q-card>

      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">家庭狀況</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <q-card class="q-pa-md q-mb-md">
          <c-column label="父親">
            <c-input-gutter role="edit2" v-model="form.fatherName" />
          </c-column>
          <c-column label="母親">
            <c-input-gutter role="edit2" v-model="form.motherName" />
          </c-column>
        </q-card>
        <q-card class="q-pa-md q-mb-md">
          <c-column label="配偶">
            <c-input-gutter role="edit2" v-model="form.spouseName" />
          </c-column>
          <c-column label="配偶號碼">
            <template v-slot:prepend>
              <c-select emit-value map-options :options="countryCodeList" v-model="form.cellAreaCode1"
                option-label="value" option-value="name" :rules="[(val) => !!val || '國碼']" />
            </template>
            <c-input placeholder="輸入手機號碼" v-model="form.cellPhone1" :rules="[(val) => !!val || '手機號碼']"></c-input>
          </c-column>
        </q-card>
        <q-card class="q-pa-md q-mb-md">
          <div class="text-right">
            <q-btn flat color="indigo" icon="person_add" @click="addContact()">新增緊急聯絡人</q-btn>
          </div>
          <div v-for="item in form.contacts" :key="item.id">
            <c-form-group-emergency v-model:name.sync="item.name" v-model:relative.sync="item.relative"
              v-model:phone.sync="item.phone" />
          </div>
        </q-card>
        <q-card class="q-pa-md q-mb-md">
          <div class="text-right">
            <q-btn flat color="indigo" icon="person_add" @click="addChild()">新增孩童名稱</q-btn>
          </div>
          <div v-for="child in form.children" :key="child.id">
            <c-form-group-kid v-model:name.sync="child.name" v-model:account.sync="child.memo" />
          </div>
        </q-card>
      </q-card>

      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">退款費用專用帳戶</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <q-card class="q-pa-md q-mb-md">
          <c-column label="戶名">
            <c-input-gutter role="edit2" v-model="form.bankName" />
          </c-column>
          <c-column label="銀行代號">
            <c-select v-model="form.bankCode" class="q-px-md q-mb-md" dense outlined :options="bankList" emit-value
              map-options option-label="label" option-value="value" />
          </c-column>
          <c-column label="分行代號">
            <c-input-gutter role="edit2" v-model="form.branchCode" />
          </c-column>
          <c-column label="銀行帳戶">
            <c-input-gutter role="edit2" v-model="form.account" />
          </c-column>
          <p class="text-right text-blue">
            若當初支付方式為現金或匯款一率採取匯款退費</p>
        </q-card>
      </q-card>
      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">多元表現</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <q-card class="q-pa-md q-mb-md">
          <div class="text-right">
            <q-btn flat color="indigo" icon="add" @click="addUserExpertises">新增專長</q-btn>
          </div>
          <div v-for="field in form.userExpertises" :key="field.id">
            <c-column :label="'專長' + field.label">
              <c-input-gutter role="edit2" v-model="field.name">
                <template v-slot:after>
                  <q-btn round dense flat icon="delete" @click="deleteExpertise(field.id)" />
                </template>
              </c-input-gutter>
            </c-column>
          </div>
        </q-card>
        <q-card class="q-pa-md q-mb-md">
          <div class="text-right">
            <q-btn flat color="indigo" icon="add" @click="addUserSociety">新增外部社團 / 工會</q-btn>
          </div>
          <div v-for="field in form.userSocieties" :key="field.id">
            <c-column :label="'外部社團 / 工會' + field.label">
              <c-input-gutter role="edit2" v-model="field.name">
                <template v-slot:after>
                  <q-btn round dense flat icon="delete" @click="deleteSociety(field.id)" />
                </template>
              </c-input-gutter>
            </c-column>
          </div>
        </q-card>
      </q-card>

      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">事工團紀錄</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <c-table :loading="isLoading" :columns="userMinistryColumns" :rows="userMinistryRows" />
      </q-card>

      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">課程歷程</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <c-table :loading="isLoading" :columns="userCourseColumns" :rows="userCourseRows" />
      </q-card>

      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">牧養歷程</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <c-table :loading="isLoading" :columns="userPastoralColumns" :rows="userPastoralRows" />
      </q-card>

      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">小組資訊</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <span class="c-primary-color-500 c-content-body-bold">聚會日： </span>
        <span class="q-mr-lg">星期三</span>
        <span class="c-primary-color-500 c-content-body-bold">聚會時間： </span>
        <span class="q-mr-lg">17:00-19:00</span>
        <span class="c-primary-color-500 c-content-body-bold">聚會地點： </span>
        <span class="q-mr-lg">台中旌旗教會</span>
        <c-table :loading="isLoading" :columns="userGroupColumns" :rows="userCourseRows" />
      </q-card>

      <h6 class="bg-cyan-8 text-white q-px-md q-mb-none">其他備註事項</h6>
      <q-card flat class="bg-grey-2 q-pa-lg q-mb-md">
        <q-card class="q-pa-md q-mb-md">
          <c-column label="中低收入戶">
            <q-checkbox v-model="form.lowIncome" class="q-my-md" dense true-value="1" false-value="0" />
          </c-column>
          <c-column label="備註">
            <q-input type="textArea" v-model="form.memo" dense/>
          </c-column>
        </q-card>
      </q-card>
      <div class="text-center q-gutter-x-md">
        <c-btn-save type="submit" />
        <c-btn-history-back />
      </div>
    </q-form>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import {
  CreateUserBankAccountCommand,
  CreateUserContactCommand,
  CreateUserFamilyCommand,
  FetchAllOrganizationRequest,
  OrganizationView,
  SignUpCommand,
  SystemConfigView,
} from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormBaptizedType from "components/business/FormBaptizedType.vue";
import { Watch } from "vue-property-decorator";
import { formatDate, fromOrganization, SystemConfig, toOrganization } from "src/util";
import { TaiwanCountryCode } from "src/data/constants";
import { RelativeType } from "src/util/RelativeType";

interface FormField$ {
  id: number;
  label: number;
  name: string;
}

interface IdName$ {
  id: number;
  name: string;
}

interface UserCourse$ {
  id: number,
  courseManagementId: number,
  name: string,
  stage: string,
  year: string,
  status: string,
}

interface UserMinistry$ {
  id: number,
  ministryDefId: number,
  name: string,
  level: string,
  attendDate: string,
  attendanceType: number,
}

interface IdName$ {
  id: number;
  name: string;
}

interface Contact$ {
  id: string;
  name: string;
  relative: string;
  phone: string;
}

interface Child$ {
  id: string;
  name: string;
  memo: string;
}

@Options({
  meta() {
    return {
      title: "詳細資料",
    };
  },

  components: {
    "c-form-organization": FormOrganization,
    "c-form-baptized-type": FormBaptizedType,
  },
})
export default class Detail extends DetailComponentBase {

  isLoading = false;
  isPwd = true;

  eduList: Array<SystemConfigView> = [];
  careList: Array<SystemConfigView> = [];
  countryCodeList: Array<SystemConfigView> = [];
  cityCodeList: Array<SystemConfigView> = [];
  contactAreaList: Array<SystemConfigView> = [];
  areaCodeList: Array<SystemConfigView> = [];

  bankList = [
    {
      label: "004 臺灣銀行",
      value: "004",
    },
    {
      label: "807 永豐銀行",
      value: "807",
    },
    {
      label: "812 台新國際商業銀行",
      value: "812",
    },
  ];

  xform = {
    join: false,
    online: false,
    domestic: true,
    isJoinChurchGroup: "",
  };

  form = {
    anotherChurchName: "",
    baptizeGroup: "",
    baptizeOrgName: "",
    baptizeTypeId: "",
    baptizedPerson: "",
    baptizedTime: "",
    baptizedType: "",
    baptizeday: "",
    baptizer: "",
    birthday: "",
    cellAreaCode: "",
    cellAreaCode1: {},
    cellAreaCode2: {},
    cellPhone1: "",
    cellPhone2: "",
    churchGroupNo: "",
    churchName: {},
    churchType: "",
    countryCode: "",
    eduType: undefined,
    jobType: null,
    email1: "",
    email2: "",
    firstName: "",
    genderType: "",
    id: 0,
    idNumber: "",
    instagramId: "",
    isAdmin: "",
    isBaptize: "",
    remark: "",
    isChurchGroup: "",
    isJoinChurchGroup: "",
    isMarried: "",
    isOldMember: "",
    isTerm: "",
    joinInPersonDate1: "",
    joinInPersonDate2: "",
    joinInPersonDate3: "",
    joinInPersonLocation1: {},
    joinInPersonLocation2: {},
    joinInPersonLocation3: {},
    joinInPersonTime1: "",
    joinInPersonTime2: "",
    joinInPersonTime3: "",
    joinOnlineDate1: "",
    joinOnlineDate2: "",
    joinOnlineDate3: "",
    joinOnlineTime1: "",
    joinOnlineTime2: "",
    joinOnlineTime3: "",
    lastName: "",
    lineId: "",
    liveAddress: "",
    liveAddress2: "",
    liveCity: "",
    liveCountry: undefined,
    liveZipArea: undefined,
    liveZipCode: undefined,
    memberType: "",
    name: "",
    otherSocialId: "",
    parentUserId: 0,
    password: "",
    passwordSalt: "",
    pastoralId: "",
    phone: "",
    phoneType: "",
    professionType: "",
    roles: "",
    userBankAccounts: undefined,
    userContracts: undefined,
    userExpertises: new Array<FormField$>(),
    userSocieties: new Array<FormField$>(),
    userFamilies: undefined,
    userNo: "",
    weChatId: "",
    lowIncome: "0",
    memo: "",
    organizationId: 0,

    contacts: new Array<Contact$>(),
    children: new Array<Child$>(),
    motherName: "",
    fatherName: "",
    spouseName: "",

    account: "",
    bankCode: "",
    bankName: "",
    branchCode: "",
  };

  userCourseColumns = [
    {
      label: "課程狀態",
      align: "status",
      name: "name",
      field: (row: UserCourse$) => row.status,
      sortable: true,
    },
    {
      label: "課程分類",
      align: "left",
      name: "courseManagementId",
      field: (row: UserCourse$) => row.courseManagementId,
      sortable: true,
    },
    {
      label: "課程名稱",
      align: "right",
      name: "name",
      field: (row: UserCourse$) => row.name,
      sortable: true,
    },
    {
      label: "梯次",
      align: "right",
      name: "stage",
      field: (row: UserCourse$) => row.stage,
      sortable: true,
    },
    {
      label: "屆別",
      align: "right",
      name: "year",
      field: (row: UserCourse$) => row.year,
      sortable: true,
    },
  ];

  userCourseRows: Array<UserCourse$> = [];

  userMinistryColumns = [
    {
      label: "事工團分類",
      align: "status",
      name: "name",
      field: (row: UserMinistry$) => row.ministryDefId,
      sortable: true,
    },
    {
      label: "事工團名稱",
      align: "left",
      name: "courseManagementId",
      field: (row: UserMinistry$) => row.name,
      sortable: true,
    },
    {
      label: "事工團層級",
      align: "right",
      name: "name",
      field: (row: UserMinistry$) => row.level,
      sortable: true,
    },
    {
      label: "出席日期",
      align: "right",
      name: "stage",
      field: (row: UserMinistry$) => row.attendDate,
      sortable: true,
    },
    {
      label: "出席紀錄",
      align: "right",
      name: "year",
      field: (row: UserMinistry$) => row.attendanceType,
      sortable: true,
    },
  ];

  userGroupColumns = [
    {
      label: "區",
      align: "status",
      name: "name",
      field: (row: UserMinistry$) => row.ministryDefId,
      sortable: true,
    },
    {
      label: "小組",
      align: "left",
      name: "courseManagementId",
      field: (row: UserMinistry$) => row.name,
      sortable: true,
    },
    {
      label: "聚會日期",
      align: "right",
      name: "name",
      field: (row: UserMinistry$) => formatDate(row.attendDate),
      sortable: true,
    },
  ];

  userPastoralColumns = [
    {
      label: "姓名",
      align: "status",
      name: "name",
      field: (row: UserMinistry$) => row.ministryDefId,
      sortable: true,
    },
    {
      label: "類型",
      align: "left",
      name: "courseManagementId",
      field: (row: UserMinistry$) => row.name,
      sortable: true,
    },
    {
      label: "新",
      align: "right",
      name: "name",
      field: (row: UserMinistry$) => row.level,
      sortable: true,
    }, {
      label: "舊",
      align: "right",
      name: "name",
      field: (row: UserMinistry$) => row.level,
      sortable: true,
    }, {
      label: "日期",
      align: "right",
      name: "name",
      field: (row: UserMinistry$) => row.level,
      sortable: true,
    }, {
      label: "異動人員",
      align: "right",
      name: "name",
      field: (row: UserMinistry$) => row.level,
      sortable: true,
    },
  ];

  userMinistryRows: Array<UserMinistry$> = [];
  private organizationList: Array<OrganizationView> = [];

  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.form.name;
  }

  get deleteKey() {
    return this.id as unknown as number;
  }

  @Watch("form.liveCountry", { immediate: true, deep: true })
  onLiveCountryChanged(val: string) {
    this.xform.domestic = val === TaiwanCountryCode;
  }

  @Watch("form.liveCity", { immediate: true, deep: true })
  onLiveCityChanged(val: string) {
    this.areaCodeList = this.$appStore.getters.getSystemConfig(`${SystemConfig.Zip}${val}`);
  }

  @Watch("form.anotherChurchName", { immediate: true, deep: true })
  onAnotherChurchNameChanged(val: string) {
    if (val) {
      this.form.baptizeOrgName = "1";
    }
  }

  @Watch("form.churchName", { immediate: true, deep: true })
  onChurchNameChanged(val: string) {
    if (val) {
      this.form.baptizeOrgName = "0";
    }
  }

  async mounted() {
    this.eduList = this.$appStore.getters.getSystemConfig(SystemConfig.EduType);
    this.careList = this.$appStore.getters.getSystemConfig(SystemConfig.CareType);
    this.countryCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CountryCode);
    this.cityCodeList = this.$appStore.getters.getSystemConfig(SystemConfig.CityCode);
    this.organizationList = (await this.apis.feature.organization.fetchOrganizations({} as FetchAllOrganizationRequest)).data;

    if (this.isUpdateMode) {
      const user = (await this.apis.feature.user.getUser(this.deleteKey)).data;
      Object.assign(this.form, user);
      this.form.password = "";
      this.form.churchName = toOrganization(this.organizationList, user.churchName);
      this.form.lowIncome = user.lowIncome == "1" ? "1" : "0";

      this.form.churchName = toOrganization(this.organizationList, user.churchName);
      this.form.joinInPersonLocation1 = toOrganization(this.organizationList, user.joinInPersonLocation1);
      this.form.joinInPersonLocation2 = toOrganization(this.organizationList, user.joinInPersonLocation2);
      this.form.joinInPersonLocation3 = toOrganization(this.organizationList, user.joinInPersonLocation3);

      this.xform.join = !(this.form.joinInPersonDate1 === ""
        && this.form.joinInPersonDate2 === ""
        && this.form.joinInPersonDate1 === "");
      this.xform.online = !(this.form.joinOnlineDate1 === ""
        && this.form.joinOnlineDate2 === ""
        && this.form.joinOnlineDate3 === "");

      if (this.form.isChurchGroup === "0" && this.form.isJoinChurchGroup === "0") {
      } else if (this.form.isChurchGroup === "1") {
        this.xform.isJoinChurchGroup = "2";
      } else {
        this.xform.isJoinChurchGroup = this.form.isJoinChurchGroup;
      }

      for (let i = 0; i < user.userFamilies.length; i++) {
        let family = user.userFamilies[i];
        if (family.relativeType === RelativeType.Father.toString()) {
          this.form.fatherName = family.name;
        }
        if (family.relativeType === RelativeType.Mother.toString()) {
          this.form.motherName = family.name;
        }
        if (family.relativeType === RelativeType.Spouse.toString()) {
          this.form.spouseName = family.name;
        }
      }

      user.userFamilies.forEach(e => {
        if (e.relativeType === RelativeType.Child.toString()) {
          this.form.children.push(
            {
              id: e.id.toString(),
              name: e.name,
              memo: e.name,
            },
          );
        }
      });

      user.userContacts.forEach(e => {
        this.form.contacts.push({
          id: e.id.toString(),
          name: e.name,
          relative: e.relative,
          phone: e.phone,
        });
      });

      user.userBankAccounts.forEach(e => {
        this.form.account = e.account;
        this.form.bankCode = e.bankCode;
        this.form.bankName = e.bankName;
        this.form.branchCode = e.branchCode;
      });
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
    //
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      let userResp = await this.apis.feature.user.getUser(this.deleteKey);
      let user = userResp.data;
      let request = Object.assign({} as SignUpCommand, user, this.form) as SignUpCommand;

      request.userFamilies = Array<CreateUserFamilyCommand>();
      if (this.form.fatherName) {
        request.userFamilies.push(Object.assign({
          name: this.form.fatherName,
          relativeType: RelativeType.Father,
        } as unknown as CreateUserFamilyCommand));
      }

      if (this.form.motherName) {
        request.userFamilies.push(Object.assign({
          name: this.form.motherName,
          relativeType: RelativeType.Mother,
        } as unknown as CreateUserFamilyCommand));
      }

      if (this.form.spouseName) {
        request.userFamilies.push(Object.assign({
          name: this.form.spouseName,
          relativeType: RelativeType.Spouse,
        } as unknown as CreateUserFamilyCommand));
      }

      request.userContacts = Array<CreateUserContactCommand>();
      for (let i = 0; i < this.form.contacts.length; i++) {
        let c = this.form.contacts[i];
        if (c.relative && c.name) {
          request.userContacts.push(Object.assign({
            name: c.name,
            relative: c.relative,
            phone: c.phone,
          } as CreateUserContactCommand));
        }
      }

      for (let i = 0; i < this.form.children.length; i++) {
        let c = this.form.children[i];
        if (c.memo) {
          request.userFamilies.push(Object.assign({
            name: c.name,
            memo: c.memo,
            relativeType: RelativeType.Child,
          } as unknown as CreateUserFamilyCommand));
        }
      }

      const signupCommand = request as unknown as SignUpCommand;
      signupCommand.churchName = fromOrganization(this.form.churchName as IdName$);
      signupCommand.joinInPersonLocation1 = fromOrganization(this.form.joinInPersonLocation1 as IdName$);
      signupCommand.joinInPersonLocation2 = fromOrganization(this.form.joinInPersonLocation2 as IdName$);
      signupCommand.joinInPersonLocation3 = fromOrganization(this.form.joinInPersonLocation3 as IdName$);

      signupCommand.userBankAccounts.push(
        {
          account: this.form.account,
          bankCode: this.form.bankCode,
          bankName: this.form.bankName,
          branchCode: this.form.branchCode,
        } as CreateUserBankAccountCommand,
      );

      await this.apis.feature.user.updateMember(this.deleteKey, signupCommand);
    });

    this.showSuccessNotify("儲存成功");
  }

  async removeAsync() {
    //
  }

  societyRule() {
    if (this.form.lineId ||
      this.form.instagramId ||
      this.form.weChatId ||
      this.form.otherSocialId) {
      return true;
    }
    return "社群帳號為必填";
  }

  addContact() {
    this.form.contacts.push({
      id: "",
      name: "",
      relative: "",
      phone: "",
    });
  }

  addChild() {
    this.form.children.push({
      id: "",
      name: "",
      memo: "",
    });
  }

  addUserExpertises() {
    this.form.userExpertises.push({
      id: this.form.userExpertises.length,
      label: this.form.userExpertises.length + 1,
      name: "",
    });
  }

  deleteExpertise(id: number) {
    this.form.userExpertises = this.form.userExpertises.filter(e => {
      return e.id !== id;
    });
  }

  addUserSociety() {
    this.form.userSocieties.push({
      id: this.form.userSocieties.length,
      label: this.form.userSocieties.length + 1,
      name: "",
    });
  }

  deleteSociety(id: number) {
    this.form.userSocieties = this.form.userSocieties.filter(e => {
      return e.id !== id;
    });
  }
}
</script>

<style lang="scss" scoped>
.q-card.q-pa-md {
  box-shadow: 0px 0px 2px rgba(0, 0, 0, 0.2), 0px 1px 5px rgba(151, 153, 158, 0.12);
  border-radius: 10px;
}
</style>
