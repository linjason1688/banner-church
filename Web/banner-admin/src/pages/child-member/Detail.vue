<template>
  <q-page class="q-pa-lg">
    <q-form @submit="submitAsync" class="q-gutter-y-md">
      <div class="row">
        <div class="col">
          <c-page-title>
            兒童會友資料管理
          </c-page-title>
        </div>
      </div>

      <div class="c-content-title c-primary-color-500 c-primary-bgcolor-100 q-pl-lg">基本資料</div>

      <div class="row">
        <div class="col-12">
          <c-subtitle title="帳戶資訊" />
        </div>
      </div>

      <c-field label="帳號">
        <c-input placeholder="請輸入帳號" v-model="form.name" :rules="[(val) => !!val || '請輸入帳號']"></c-input>
      </c-field>

      <c-field label="密碼">
        <c-input
          placeholder="請輸入8-12位英數字"
          v-model="form.password"
          :type="isPwd ? 'password' : 'text'"
        >
          <template v-slot:append>
            <q-icon
              :name="isPwd ? 'visibility_off' : 'visibility'"
              class="cursor-pointer"
              @click="isPwd = !isPwd"
            />
          </template>
        </c-input>
      </c-field>

      <div class="row">
        <div class="col-12">
          <c-subtitle title="個人資料" />
        </div>
      </div>

      <c-field label="姓名">
        <div class="row">
          <div class="col-4 inline-block q-pr-md">
            <c-input placeholder="姓" v-model="form.firstName"></c-input>
          </div>
          <div class="col-8 inline-block">
            <c-input placeholder="名" v-model="form.lastName"></c-input>
          </div>
        </div>
      </c-field>
      <c-field label="性別">
        <div class="q-pt-md"></div>
        <c-form-gender v-model="form.genderType" />
      </c-field>

      <c-field label="身分證字號 (或居留證 / 護照號碼)">
        <c-input placeholder="請輸入身分證字號或居留證 / 護照號碼" v-model="form.idNumber"></c-input>
      </c-field>

      <c-field label="出生年月日(西元)">
        <c-date-picker v-model="form.birthday"></c-date-picker>
      </c-field>

      <div class="row">
        <div class="col-12">
          <c-subtitle title="信仰資料" />
        </div>
      </div>

      <div class="c-content-body inline-block">信仰狀態及受洗資料</div>
      <div class="inline-block app-required">*</div>

      <div>
        <q-list>
          <q-item tag="label" class="q-pa-none">
            <q-item-section avatar>
              <q-radio v-model="form.baptizedType" val="0" />
            </q-item-section>
            <q-item-section>
              <q-item-label>已受洗</q-item-label>
            </q-item-section>
          </q-item>
          <q-item class="q-pl-xl" v-if="form.baptizedType === '0'">
            <q-item-section>
              <q-list bordered>
                <q-item>
                  <q-item-section>
                    <c-field class="col" label="受洗時間">
                      <c-date-picker v-model="form.baptizedTime" />
                    </c-field>

                    <div class="app-wizard-subtitle">過去在哪個教會</div>

                    <q-list>
                      <q-item tag="label" class="q-pa-none">
                        <q-item-section avatar>
                          <q-radio v-model="form.churchType" val="0" />
                        </q-item-section>
                        <q-item-section>
                          <q-item-label>旌旗教會</q-item-label>
                        </q-item-section>
                      </q-item>

                      <q-item v-if="form.churchType === '0'">
                        <q-item-section>
                          <c-form-organization v-model="form.churchName" class="q-px-md q-mb-md" dense />
                        </q-item-section>
                      </q-item>

                      <q-item tag="label" class="q-pa-none">
                        <q-item-section avatar>
                          <q-radio v-model="form.churchType" val="1" />
                        </q-item-section>
                        <q-item-section>
                          <q-item-label>其他教會</q-item-label>
                        </q-item-section>
                      </q-item>

                      <q-item tag="label" v-if="form.churchType === '1'">
                        <q-item-section>
                          <c-input placeholder="填入教會名稱" v-model="form.anotherChurchName"></c-input>
                        </q-item-section>
                      </q-item>

                      <q-item tag="label">
                        <q-item-section>
                          <div>教會施洗者 (若為旌旗教會者)</div>
                        </q-item-section>
                      </q-item>
                      <q-item>
                        <q-item-section>
                          <c-input placeholder="輸入施洗者姓名" v-model="form.baptizedPerson"></c-input>
                        </q-item-section>
                      </q-item>

                    </q-list>
                  </q-item-section>
                </q-item>
              </q-list>
            </q-item-section>
          </q-item>

          <q-item tag="label" class="q-pa-none">
            <q-item-section avatar>
              <q-radio v-model="form.baptizedType" val="1" />
            </q-item-section>
            <q-item-section>
              <q-item-label>未受洗</q-item-label>
            </q-item-section>
          </q-item>

          <q-item tag="label" class="q-pa-none">
            <q-item-section avatar>
              <q-radio v-model="form.baptizedType" val="2" />
            </q-item-section>
            <q-item-section>
              <q-item-label>其他</q-item-label>
            </q-item-section>
          </q-item>
          <q-item class="q-pl-xl" v-if="form.baptizedType === '2'">
            <q-item-section>
              <c-input placeholder="填入其他狀態" v-model="form.remark"></c-input>
            </q-item-section>
          </q-item>
        </q-list>
      </div>

      <div class="row">
        <div class="col-12">
          <c-subtitle title="通訊資料" />
        </div>
      </div>

      <div class="app-wizard-information-content1">
        <div>
          <c-field label="居住國家">
            <c-form-system-config v-model="form.liveCountry" systemConfig="CountryCode" />
          </c-field>
        </div>
        <div v-if="xform.domestic">
          <div class="row">
            <div class="col-6">
              <c-field label="城市">
                <c-form-system-config v-model="form.liveCity" systemConfig="CityCode" />
              </c-field>
            </div>
            <div class="col-6">
              <c-field label="地區">
                <c-select v-model="form.liveZipArea" emit-value map-options :options="areaCodeList"
                          class="q-px-md q-mb-md" dense
                          option-value="name"
                          option-label="value" />
              </c-field>
            </div>
          </div>
          <div class="row">
            <div class="col-12">
              <c-field label="郵遞區號">
                <c-input placeholder="" v-model="form.liveZipCode"></c-input>
              </c-field>
            </div>
          </div>
          <div>
            <c-field label="詳細住址">
              <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
            </c-field>
          </div>
        </div>
        <div v-else>
          <div>
            <c-field label="住址1">
              <c-input placeholder="輸入地址" v-model="form.liveAddress"></c-input>
            </c-field>
          </div>

          <div>
            <c-field label="住址2">
              <c-input placeholder="輸入地址" v-model="form.liveAddress2"></c-input>
            </c-field>
          </div>
          <div>
            <c-field label="郵遞區號">
              <c-input placeholder="" v-model="form.liveZipCode"></c-input>
            </c-field>
          </div>
        </div>
      </div>

      <c-field label="手機號碼">
        <div class="row">
          <div class="col-4">
            <c-select class="inline-block full-width"
                      emit-value map-options :options="countryCodeList" v-model="form.cellAreaCode1"
                      option-label="value" option-value="name" :rules="[(val) => !!val || '國碼']" />
          </div>
          <div class="col-8">
            <c-input
              placeholder="輸入手機號碼"
              class="inline-block full-width"
              v-model="form.cellPhone1" :rules="[(val) => !!val || '手機號碼']" 
            ></c-input>
          </div>
        </div>
      </c-field>
      <c-field label="手機號碼2">
        <div class="row">
          <div class="col-4">
            <c-select class="inline-block full-width"
                      emit-value map-options :options="countryCodeList" v-model="form.cellAreaCode2"
                      option-label="value" option-value="name" />
          </div>
          <div class="col-8">
            <c-input
              placeholder="輸入手機號碼"
              class="inline-block full-width"
              v-model="form.cellPhone2"
            ></c-input>
          </div>
        </div>
      </c-field>
      <c-field label="電話 (市話)">
        <c-input placeholder="輸入電話" v-model="form.phone"></c-input>
      </c-field>
      <c-field label="Email">
        <c-input placeholder="請輸入Email" v-model="form.email1"></c-input>
      </c-field>
      <c-field label="Email2">
        <c-input placeholder="請輸入Email2" v-model="form.email2"></c-input>
      </c-field>

      <div class="c-content-title c-primary-color-500 c-primary-bgcolor-100 q-pl-lg">退款費用專用帳戶</div>
      <div v-for="item in form.userBankAccounts" :key="item.id">
        <c-field label="戶名">
          <c-input placeholder="" v-model="item.bankName"></c-input>
        </c-field>
        <c-field label="銀行代號">
          <c-input placeholder="" v-model="item.bankCode"></c-input>
        </c-field>
        <c-field label="分行代號">
          <c-input placeholder="" v-model="item.branchCode"></c-input>
        </c-field>
        <c-field label="銀行帳戶">
          <c-input placeholder="" v-model="item.account"></c-input>
        </c-field>
      </div>

      <div class="row">
        <div class="col-8 text-right">
          <div class="c-helper-text-lg c-info-color-600">若當初支付方式為現金或匯款一率採取匯款退費</div>
        </div>
      </div>

      <div class="c-content-title c-primary-color-500 c-primary-bgcolor-100 q-pl-lg">其他資訊</div>

      <div class="row c-primary-color-500 c-button-lg">新增專長</div>
      <div v-for="(item, index) in form.userExpertises" :key="item.id">
        <c-field :label="'專長' + (index + 1)">
          <c-input placeholder="" v-model="item.name"></c-input>
        </c-field>
      </div>

      <div class="row c-primary-color-500 c-button-lg">新增外部社團 / 工會</div>
      <div v-for="(item, index) in form.userSocieties" :key="item.id">
        <c-field :label="'外部社團 / 工會' + (index + 1)">
          <c-input placeholder="" v-model="item.name"></c-input>
        </c-field>
      </div>

      <c-field label="中低收入戶">
        <q-checkbox v-model="form.lowIncome" class="q-px-md q-mb-md" dense
                    true-value="1" false-value="0"/>
      </c-field>

      <c-field label="備註">
        <c-input type="textArea" v-model="form.memo"></c-input>
      </c-field>

      <div class="c-content-title c-primary-color-500 c-primary-bgcolor-100 q-pl-lg">事工團紀錄</div>
      <c-table :loading="isLoading" :columns="userMinistryColumns" :rows="userMinistryRows" row-key="id">
        <template v-slot:body-cell-dateCreate="props">
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
        </template>

        <template v-slot:expand="props">
          <c-column-detail :detailColumns="detailColumns" :props="props">
            <template v-slot:detail-cell-name="row">
              <strong>{{ row.label }}
                <c-colon />
              </strong>
              {{ row.value }}
            </template>
          </c-column-detail>

          <c-entity-detail :value="props.row" />
        </template>
      </c-table>

      <div class="c-content-title c-primary-color-500 c-primary-bgcolor-100 q-pl-lg">
        課程歷程
      </div>
      <c-table :loading="isLoading" :columns="userCourseColumns" :rows="userCourseRows" row-key="id">
        <template v-slot:body-cell-dateCreate="props">
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
        </template>

        <template v-slot:expand="props">
          <c-column-detail :detailColumns="detailColumns" :props="props">
            <template v-slot:detail-cell-name="row">
              <strong>{{ row.label }}
                <c-colon />
              </strong>
              {{ row.value }}
            </template>
          </c-column-detail>

          <c-entity-detail :value="props.row" />
        </template>
      </c-table>

      <div class="row">
        <div class="col">
          <c-btn-save type="submit" />
          <c-btn-history-back class="q-mr-md" />
        </div>
      </div>
    </q-form>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import { FetchAllOrganizationRequest, OrganizationView, SignUpCommand, SystemConfigView } from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import FormBaptizedType from "components/business/FormBaptizedType.vue";
import { Watch } from "vue-property-decorator";
import { fromOrganization, SystemConfig, toOrganization } from "src/util";
import { TaiwanCountryCode } from "src/data/constants";

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

  xform = {
    join: false,
    online: false,
    domestic: true,
    isJoinChurchGroup: "",
  };

  form = {
    account: "",
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
    cellAreaCode1: "",
    cellAreaCode2: "",
    cellPhone1: "",
    cellPhone2: "",
    churchGroupNo: "",
    churchName: {},
    churchType: "",
    countryCode: "",
    eduType: "",
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
    joinInPersonLocation1: "",
    joinInPersonLocation2: "",
    joinInPersonLocation3: "",
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
    userExpertises: undefined,
    userFamilies: undefined,
    userSocieties: [],
    userNo: "",
    weChatId: "",
    lowIncome: "0",
    memo: "",
    organizationId: 0,
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
      const res = await this.apis.feature.user.getUser(this.deleteKey);
      Object.assign(this.form, res.data);
      this.form.password = "";
      this.form.churchName = toOrganization(this.organizationList, res.data.churchName);
      this.form.lowIncome = res.data.lowIncome == "1" ? "1" : "0";
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
      const request = Object.assign({}, this.form);
      request.churchName = fromOrganization(request.churchName as IdName$);
      await this.apis.feature.user.updateMember(this.deleteKey, request as unknown as SignUpCommand);
    });

    this.showSuccessNotify("儲存成功");
  }

  async removeAsync() {
    //
  }
}
</script>

<style lang="scss" scoped></style>
