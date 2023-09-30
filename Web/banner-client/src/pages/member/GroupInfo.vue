<template>
  <q-page class="q-mx-auto">
    <div class="q-mx-auto" style="width:fit-content">
      <q-breadcrumbs class="text-indigo text-subtitle1 text-bold">
        <template v-slot:separator>
          <q-icon size="1.5em" name="chevron_right" color="primary" />
        </template>
        <q-breadcrumbs-el label="小組資訊" />
        <q-breadcrumbs-el :label="tab" @click="editPage = ''" />
        <q-breadcrumbs-el :label="editPage" v-if="editPage" />
      </q-breadcrumbs>
      <template v-if="editPage">
        <c-subtitle :title="editPage" />
        <template v-if="tab == '小組聚會資訊更新'">
          <c-form-card>
            <c-column label="堂點">
              <q-select v-model="form.organizationId" />
            </c-column>
            <c-row>
              <c-column label="牧區">
                <q-select v-model="form.areaId" />
              </c-column>
              <c-column label="督區">
                <q-select v-model="form.leadAreaId" />
              </c-column>
            </c-row>
            <c-row>
              <c-column label="區">
                <q-select v-model="form.zoneId" />
              </c-column>
              <c-column label="小組">
                <q-select v-model="form.churchGroupNo" />
              </c-column>
            </c-row>
            <c-column label="聚會日">
              <q-select v-model="form.meetingDay" />
            </c-column>
            <c-column label="聚會時間">
              <c-date-picker range time :value="{ from: form.meetingTimeS, to: form.meetingTimeE }"
                @update:model-value="form.meetingTimeS = $event.from; form.meetingTimeE = form.meetingTimeE" />
            </c-column>
            <c-column label="聚會地點">
              <q-input v-model="form.place" dense />
            </c-column>
          </c-form-card>
        </template>
        <template v-if="tab == '組員名單管理'">
          <c-form-card class="bg-grey-2">
            <c-row>
              <c-column label="姓名">
                <q-input v-model="form.name" />
              </c-column>
              <c-column label="手機">
                <q-input v-model="form.cellPhone" />
              </c-column>
              <c-column label="性別">
                <c-form-gender v-model="form.genderType" />
              </c-column>
              <c-column class="col text-right">
                <c-btn-search type="submit" />
              </c-column>
            </c-row>
          </c-form-card>
          <c-table :rows="teamMembers" :columns="teamMemberTransferColumns">
            <template v-slot:body-cell-edit="scope">
              <q-checkbox v-model="scope.check" />
            </template>
          </c-table>
        </template>
        <template v-if="tab == '新人跟進進度'">
          <c-table v-if="區長以上" :rows="newcomers" :columns="newcomerColumns.slice(1)"></c-table>

          <c-form-card v-else>
            <c-column label="回報跟進進度">
              <q-radio v-model="form.progress" val="0" label="跟進中" />
              <q-radio v-model="form.progress" val="1" label="沒興趣" />
              <q-radio v-model="form.progress" val="2" label="聯絡不上" />
              <q-radio v-model="form.progress" val="3" label="加入小組" />
              <q-radio v-model="form.progress" val="4" label="其他" />
              <q-input v-model="form.progress" dense />
            </c-column>
            <c-column label="跟進組員名稱">
              <q-input v-model="form.name" dense />
            </c-column>

            <c-column label="跟進備註">
              <q-input type="textarea" v-model="form.memo" />
            </c-column>
            <c-column label="小組聚會次數">
              <q-input type="textarea" v-model="form.memo" />
            </c-column>
          </c-form-card>
        </template>
      </template>
      <template v-else>
        <c-subtitle title="小組資訊" />
        <q-tabs v-model="tab" indicator-color="transparent" inline-label active-class="text-bold"
          class="text-indigo text-underline">
          <q-tab dense name="小組聚會資訊更新" label="小組聚會資訊更新" icon="img:/img/groupMeetings.svg"></q-tab>
          <q-tab dense name="組員名單管理" label="組員名單管理" icon="img:/img/teamMember.svg"></q-tab>
          <q-tab dense name="新人跟進進度" label="新人跟進進度" icon="img:/img/newcomer.svg"></q-tab>
          <q-tab dense name="小組聚會登記" label="小組聚會登記" icon="img:/img/groupRegister.svg"></q-tab>
          <q-tab dense name="小組聚會統計" label="小組聚會統計" icon="img:/img/statistic.svg"></q-tab>
        </q-tabs>
        <q-tab-panels v-model="tab" animated class="q-pa-none" style="background: transparent;">
          <q-tab-panel name="小組聚會資訊更新">
            <c-form-card v-if="區長以上">
              <c-table :rows="groupMeetings" :columns="groupMeetingsColumns">
                <template v-slot:body-cell-edit="scope">
                  <q-btn class="bg-grey-2" rounded @click="editRow = scope; editPage = '編輯'">編輯</q-btn>
                </template>
              </c-table>
            </c-form-card>
            <c-form-card v-else class="flex column items-center">
              <c-row>
                <c-column label="聚會日" class="col-12">
                  <q-select dense v-model="form.meetingDay" placeholder="請選擇" />
                </c-column>
                <c-column label="聚會時間" class="col-12">
                  <c-date-picker range time dense :value="{ from: form.meetingTimeS, to: form.meetingTimeE }"
                    @update:model-value="form.meetingTimeS = $event.from; form.meetingTimeE = form.meetingTimeE" />
                </c-column>
                <c-column label="聚會地點" class="col-12">
                  <q-input v-model="form.place" dense />
                </c-column>
              </c-row>
            </c-form-card>
          </q-tab-panel>
          <q-tab-panel name="組員名單管理">
            <!--<q-btn class="q-mb-md" color="indigo" icon="group_add" rounded>移入組員</q-btn>-->
            <q-card flat>
              <c-table :rows="teamMembers" :columns="teamMemberColumns">
                <template v-slot:body-cell-edit="scope">
                  <q-btn color="indigo" rounded @click="editRow = scope; editPage = '未入組名單'">落戶</q-btn>
                </template>
                <template v-slot:body-cell-agent="scope">
                  <q-checkbox v-model="scope.agent" />
                </template>
              </c-table>
            </q-card>
          </q-tab-panel>
          <q-tab-panel name="新人跟進進度">
            <c-form-card class="bg-grey-1">
              <c-row>
                <c-column label="跟進組員名單" class="col-12 col-sm-4">
                  <q-select v-model="form.churchGroupNo" outlined dense class="bg-white" />
                </c-column>
                <c-column label="回報跟進進度" class="col-12 col-sm-4">
                  <q-select v-model="form.churchGroupNo" outlined dense class="bg-white" />
                </c-column>
                <c-column class="col text-right">
                  <c-btn-search />
                </c-column>
              </c-row>
            </c-form-card>
            <q-btn class="q-mb-md" color="indigo" icon="add" rounded>新增</q-btn>
            <c-form-card>
              <c-table :rows="newcomers" :columns="newcomerColumns">
                <template v-slot:body-cell-edit="scope">
                  <q-btn rounded @click="editRow = scope; editPage = '編輯'">編輯</q-btn>
                </template>
              </c-table>
            </c-form-card>
          </q-tab-panel>
          <q-tab-panel name="小組聚會登記">
            <c-form-card class="bg-grey-1">
              <c-row>
                <c-column label="聚會時間" class="col-12 col-sm-4">
                  <c-date-picker range time dense :value="{ from: form.meetingTimeS, to: form.meetingTimeE }"
                    @update:model-value="form.meetingTimeS = $event.from; form.meetingTimeE = form.meetingTimeE" />
                </c-column>
                <c-column label="聚會狀態" class="col">
                  <q-radio v-model="form.status" val="1" label="正常舉行" />
                  <q-radio v-model="form.status" val="0" label="本次暫停" />
                </c-column>
              </c-row>
            </c-form-card>
            <c-table :rows="groupRegisters" :columns="groupRegisterColumns">
              <template v-slot:body-cell-select="scope">
                <q-checkbox v-model="scope.select" />
              </template>
            </c-table>
          </q-tab-panel>
          <q-tab-panel name="小組聚會統計">
            <c-form-card class="bg-grey-1">
              <c-row>
                <c-column label="堂點" class="col-12 col-sm-4">
                  <q-input v-model="form.organizationId" outlined dense class="bg-white" />
                </c-column>
                <c-column label="牧區" class="col-12 col-sm-4">
                  <q-select v-model="form.areaId" outlined dense class="bg-white" />
                </c-column>
                <c-column label="督區" class="col-12 col-sm-4">
                  <q-select v-model="form.leadAreaId" outlined dense class="bg-white" />
                </c-column>
                <c-column label="區" class="col-12 col-sm-4">
                  <q-select v-model="form.zoneId" outlined dense class="bg-white" />
                </c-column>
                <c-column label="小組" class="col-12 col-sm-4">
                  <q-select v-model="form.churchGroupNo" outlined dense class="bg-white" />
                </c-column>
                <c-column label="聚會日期" class="col-12 col-sm-4">
                  <c-date-picker range time dense :value="{ from: form.openDateS, to: form.openDateE }"
                    @update:model-value="form.openDateS = $event.from; form.openDateE = form.openDateE" />
                </c-column>
                <c-column label="聚會狀態" class="col">
                  <q-radio v-model="form.status" val="" label="全部" />
                  <q-radio v-model="form.status" val="1" label="已回報" />
                  <q-radio v-model="form.status" val="0" label="未回報" />
                </c-column>
                <c-column class="col text-right">
                  <c-btn-search />
                </c-column>
              </c-row>
            </c-form-card>
            <q-btn class="q-mb-md" color="indigo" icon="save_alt" rounded>匯出</q-btn>
            <c-form-card>
              <c-table :rows="statistics" :columns="statisticColumns"></c-table>
            </c-form-card>
          </q-tab-panel>
        </q-tab-panels>
      </template>
    </div>
    <c-savecancel-group @save="save()" @cancel="cancel()" />
  </q-page>
</template>

<script lang="ts">

import { ComponentBase } from "src/components";
import { PagedRequest } from "src/data/dto";
import { MinistryMeetingUserView, QueryMinistryMeetingUserRequest } from "src/api/feature";

export default class GroupInfo extends ComponentBase {

  rowsNumber = 0;
  action = false;
  isLoading = true;
  tab = "小組聚會資訊更新";
  editPage = "";
  editRow = {};
  teamMembers = [{}];
  form = {
    organizationId: "",
    areaId: "",
    leadAreaId: "",
    zoneId: "",
    churchGroupNo: "",
    openDateS: "",
    openDateE: "",
    status: "",
    meetingDay: "",
    meetingTimeS: "",
    meetingTimeE: "",
    place: "",
    name: "",
    progress: "",
    memo: "",
    cellPhone: "",
    genderType: "",
  };
  groupMeetings = [{}];
  groupMeetingsColumns = [
    { label: "", name: "edit" },
    { label: "堂點", name: "堂點" },
    { label: "牧區", name: "牧區" },
    { label: "督區", name: "督區" },
    { label: "區", name: "區" },
    { label: "小組", name: "小組" },
    { label: "聚會日", name: "聚會日" },
    { label: "聚會時間", name: "聚會時間" },
    { label: "聚會地點", name: "聚會地點" },
  ];
  teamMemberColumns = [
    { label: "操作", name: "edit" },
    { label: "代理人設定", name: "agent" },
    { label: "職分", name: "職分" },
    { label: "姓名", name: "姓名" },
    { label: "手機", name: "手機" },
  ];
  teamMemberTransferColumns = [
    { label: "", name: "edit" },
    { label: "姓名", name: "姓名" },
    { label: "性別", name: "性別" },
    { label: "手機", name: "手機" },
  ];
  newcomers = [{}];
  newcomerColumns = [
    { label: "", name: "edit" },
    { label: "跟進組員名稱", name: "跟進組員名稱" },
    { label: "回報跟進進度", name: "回報跟進進度" },
    { label: "跟進備註", name: "跟進備註" },
    { label: "小組聚會次數", name: "小組聚會次數" },
  ];
  groupRegisters = [{}];
  groupRegisterColumns = [
    { label: "出席", name: "select" },
    { label: "身分", name: "身分" },
    { label: "組員", name: "組員" },
    { label: "手機", name: "手機" },
  ];
  statistics = [{}];
  statisticColumns = [
    { label: "堂點", name: "堂點" },
    { label: "牧區", name: "牧區" },
    { label: "督區", name: "督區" },
    { label: "區", name: "區" },
    { label: "小組", name: "小組" },
    { label: "聚會日期", name: "聚會日期" },
    { label: "出席統計(實/應)", name: "出席統計" },
    { label: "出席率", name: "出席率" },
    { label: "聚會狀態", name: "聚會狀態" },
  ];

  get 區長以上() {
    return false;
  }

  rows: Array<MinistryMeetingUserView> = [];

  async mounted() {
    await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.queryAsync(req);
    });
  }

  async queryAsync(pagedRequest?: PagedRequest) {
    this.isLoading = true;

    let request = {} as QueryMinistryMeetingUserRequest;
    request = Object.assign(request, {
      userId: this.$appStore.getters.userProfile.id,
    });
    request = Object.assign(request, this.form);
    request = Object.assign(request, pagedRequest);

    const res = await this.usePreviousRequestParamsAsync(async (req) => {
      return await this.apis.feature.ministryMeetingUser.queryMinistryMeetingUsers(
        req as QueryMinistryMeetingUserRequest,
      );
    }, request);

    this.rows = res.data.records;
    this.rowsNumber = this.rows.length;
    this.isLoading = false;
  }
  async save() {
    await new Promise(() => 1);
  }
  async cancel() {
    await new Promise(() => 1);
  }
}
</script>

<style>
.text-underline .q-tab__label {
  text-decoration: underline;
}

.text-bold .q-tab__label {
  text-decoration: none;
  font-weight: bold;
}
</style>
