<template>
  <!-- ========== menu ========== -->
  <q-drawer v-model="isLeftDrawerShow" :breakpoint="768" :width="180" class="c-drawer" side="left" show-if-above bordered>
    <q-tabs v-model="tab" vertical inline-label align="left" class="c-tab" active-class="c-tab-active"
      indicator-color="primary">
      <q-tab class="q-my-sm" name="profile" label="基本資料" icon="img:/img/profile.svg" />
      <q-tab class="q-my-sm" name="family" label="家庭狀況" icon="img:/img/family.svg" />
      <q-tab class="q-my-sm" name="payment" label="退款費用專用帳戶" icon="img:/img/chargeback.svg" />
      <q-tab class="q-my-sm" name="other" label="多元表現" icon="img:/img/other.svg" />
      <q-tab class="q-my-sm" name="working" label="事工團紀錄" icon="img:/img/working-group.svg" />
      <q-tab class="q-my-sm" name="course" label="課程歷程" icon="img:/img/class.svg" />
      <q-tab class="q-my-sm" name="resources" label="資源下載區" icon="img:/img/resources.svg" />
      <q-tab class="q-my-sm" name="care" label="牧養歷程" icon="img:/img/shepherd.svg" />
      <q-tab class="q-my-sm" name="group" label="小組聚會歷程" icon="img:/img/group.svg" />
      <q-tab class="q-my-sm" name="groupInfo" label="小組資訊(小組長)" icon="img:/img/groupInfo.svg" />
    </q-tabs>
  </q-drawer>
  <Stepper class="q-ma-md" :stepIndex="stepIndex" :steps="steps"></Stepper>
  <q-tab-panels v-model="tab" animated class="c-need-background">
    <q-tab-panel name="profile">
      <c-member-profile></c-member-profile>
    </q-tab-panel>
    <q-tab-panel name="family">
      <c-member-family></c-member-family>
    </q-tab-panel>
    <q-tab-panel name="payment">
      <c-member-payment></c-member-payment>
    </q-tab-panel>
    <q-tab-panel name="other">
      <c-member-other></c-member-other>
    </q-tab-panel>
    <q-tab-panel name="working">
      <c-member-ministry-meeting></c-member-ministry-meeting>
    </q-tab-panel>
    <q-tab-panel name="course">
      <c-member-course-history></c-member-course-history>
    </q-tab-panel>
    <q-tab-panel name="resources">
      <c-member-resources></c-member-resources>
    </q-tab-panel>
    <q-tab-panel name="care">
      <c-member-pastoral-care></c-member-pastoral-care>
    </q-tab-panel>
    <q-tab-panel name="group">
      <c-member-group></c-member-group>
    </q-tab-panel>
    <q-tab-panel name="groupInfo">
      <c-member-group-info></c-member-group-info>
    </q-tab-panel>
  </q-tab-panels>
  <div v-if="!tab" class="q-pa-md">
    <b class="block bg-blue-2 text-indigo-10 q-px-md q-py-xs q-mb-sm">會員職分</b>
    <c-form-card>
      <c-row class="q-pt-md">
        <div class="col-12 col-md">
          <div class="flex align-center">
            <q-avatar class="inline-block">
              <img src="/img/avatar.svg" />
            </q-avatar>
            <ul class="q-mt-none">
              <li>{{ pastoralName }}</li>
              <li>{{ ministryName }}</li>
            </ul>
          </div>
          <b class="bg-grey-4 text-grey-8 q-pa-xs rounded-borders">{{ belongsPastoral }}</b>
        </div>
        <div class="col-12 col-sm-6 col-md border-left">
          <b>小組聚會資訊</b>
          <div class="q-pa-md">
            <b class="text-indigo-10">聚會日：</b>
            <b class="text-blue-8">{{ meetingDayOfWeek }}</b>
            <br>
            <b class="text-indigo-10">聚會時間：</b>
            <b class="text-blue-8">{{ meetingTime }}</b>
            <br>
            <b class="text-indigo-10">聚會地點：</b>
            <b class="text-blue-8">{{ meetingAddress }}</b>
          </div>
        </div>
        <div class="col-12 col-sm-6 col-md border-left">
          <b>未結案歷程</b>
          <div class="q-pa-md">
            <b class="text-indigo-10">課程名稱：</b>
            <b class="text-blue-8">{{ courseName }}</b>
            <br>
          </div>
        </div>
      </c-row>
    </c-form-card>
    <b class="block bg-blue-2 text-indigo-10 q-px-md q-py-xs q-mb-sm">小組資訊-樹狀圖</b>
    <c-form-card>
      <q-chip class="text-indigo" icon="place" square>台中旌旗教會分堂</q-chip>
      <OrgChart @select="org = $event" :value="org" :item="orgTree"></OrgChart>
    </c-form-card>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import { Emit, Watch } from "vue-property-decorator";
import Profile from "pages/member/Profile.vue";
import Family from "pages/member/Family.vue";
import Payment from "pages/member/Payment.vue";
import Other from "pages/member/Other.vue";
import MinistryMeeting from "pages/member/MinistryMeeting.vue";
import PastoralCare from "pages/member/PastoralCare.vue";
import Group from "pages/member/Group.vue";
import GroupInfo from "pages/member/GroupInfo.vue";
import Menu from "components/Menu.vue";
import CourseHistory from "pages/member/CourseHistory.vue";
import Resources from "pages/member/Resources.vue";
import OrgChart, { Org, Org2Tree } from "src/components/elementary/OrgChart.vue";
import Stepper from "src/components/elementary/Stepper.vue";
import {
  PastoralView,
  QueryMinistryRespUserRequest,
  QueryPastoralRequest,
  QueryShoppingOrderDetailRequest
} from "src/api/feature";
import { convertDisplayText, SystemConfig } from "src/util";
import { OrderDetailStatus } from "src/data/constants/OrderDetailStatus";

interface User$ {
  PastoralId: number;
}
interface UserProfile$ {
  User: User$;
}

/* eslint-disable */
@Options({
  meta() {
    return {
      title: "Role List",
    };
  },

  components: {
    "c-member-profile": Profile,
    "c-member-family": Family,
    "c-member-payment": Payment,
    "c-member-other": Other,
    "c-member-ministry-meeting": MinistryMeeting,
    "c-member-course-history": CourseHistory,
    "c-member-resources": Resources,
    "c-member-pastoral-care": PastoralCare,
    "c-member-group": Group,
    "c-member-group-info": GroupInfo,
    "c-menu": Menu,
    OrgChart,
    Stepper,
  },
})
export default class Index extends ComponentBase {
  alignSetting = "right";
  isLeftDrawerShow = false;
  tab = "";
  orgs: Org[] = [];
  flatOrgs: PastoralView[] = [];
  org = this.orgs[0];
  pastoralName = "";
  ministryName = "";
  identity!: UserProfile$;
  meetingDayOfWeek = "";
  meetingTime = "";
  meetingAddress = "";
  courseName = "";
  steps = [
    { src: "/img/step-check.svg", name: "開始", tab: "", },
    { src: "/img/step-profile.svg", name: "基本資料", tab: "profile", },
    { src: "/img/step-family.svg", name: "家庭狀況", tab: "family", },
    { src: "/img/step-payment.svg", name: "支付工具", tab: "payment", },
    { src: "/img/step-other.svg", name: "多元表現", tab: "other", },
    { src: "", name: "完成", tab: "", },
  ];
  get stepIndex() {
    if (String(this.tab) == "") return 0;
    const index = this.steps.findIndex(x => x.tab == String(this.tab));
    return index == -1 ? this.steps.length : index;
  }
  get orgTree() {
    return Org2Tree(this.orgs);
  }
  get belongsPastoral() {
    let groupName: number = 0;
    let name: string[] = [];
    for (let row of this.flatOrgs) {
      name.push(row.name)
      groupName = row.id;
      if (groupName === this.identity.User.PastoralId) {
        break;
      }
    }
    return `${name.join(" / ")} (小組編號：${groupName})`
  }

  @Emit("changedTabName")
  onTabChange(tabName: string) {
    return tabName;
  }

  @Watch("tab")
  handleTabChange(newVal: string) {
    this.onTabChange(newVal);
  }

  async mounted() {
    this.identity = this.parseJwt(this.$appStore.state.userProfile.jwt) as UserProfile$;
    this.apis.feature.pastoral.fetchPastoralFlat({ id: this.identity.User.PastoralId })
      .then(e => {
        this.flatOrgs = e.data;
        this.orgs = e.data.map((row): Org => ({ ...row, expand: true, parentNode: undefined, children: [], }));
      })

    this.apis.feature.ministryRespUser.queryMinistryRespUsers({ userId: this.$appStore.state.userProfile.id } as QueryMinistryRespUserRequest)
      .then(e => {
        if (e.data.size != 0) {
          this.ministryName = e.data.records[0].ministryName;
        }
      });

    this.apis.feature.pastoral.queryPastorals({ id: this.identity.User.PastoralId } as QueryPastoralRequest)
      .then(e => {
        if (e.data.size != 0) {
          this.pastoralName = e.data.records[0].name
        }
      });

    this.apis.feature.ministryMeetingUser.queryMinistryMeetingUsers({ userId: this.$appStore.state.userProfile.id } as QueryMinistryRespUserRequest)
      .then(e => {
        if (e.data.size != 0) {
          this.meetingDayOfWeek = convertDisplayText(this.$appStore.getters.getSystemConfig(SystemConfig.JoinDate), e.data.records[0].meetingDayOfWeek);
          this.meetingTime = e.data.records[0].meetingTime
          this.meetingAddress = e.data.records[0].meetingAddress
        }
      });

    this.getCourseName().then(e => {
      this.courseName = e;
    });
  }

  async getCourseName() {
    let courseName = "";
    const res = await this.apis.feature.shoppingOrderDetail.queryShoppingOrderDetails({
      userId: this.$appStore.state.userProfile.id,
      orderDetailStatus: OrderDetailStatus.PaidCompleted
    } as QueryShoppingOrderDetailRequest);
    if (res.data.totalCount > 0) {
      const resCourse = await this.apis.feature.course.getCourse(res.data.records[0].courseId);
      courseName = resCourse.data.name;
    }

    return courseName;
  }

  parseJwt(token: string) {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const payload = decodeURIComponent(window.atob(base64).split('').map(x => '%' + ('00' + x.charCodeAt(0).toString(16)).slice(-2)).join(''));
    return JSON.parse(payload);
  }
}
</script>

<style lang="scss" scoped>
.c-tab {
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 16px;
  font-feature-settings: "tnum" on, "lnum" on;
  color: #282828;
  border-radius: 8px 0px 0px 8px;
}

.c-tab .q-tab {
  justify-content: start !important;
}

.c-tab-active {
  font-family: $primary-font-family;
  font-style: normal;
  font-weight: 400;
  font-size: 16px;
  font-feature-settings: "tnum" on, "lnum" on;
  color: #3764ac;
  background-color: #edf0f6;
  border-radius: 8px 0px 0px 8px;
}

.c-drawer {
  background-color: #ffffff;
  border: 1px solid rgba(157, 162, 170, 0.25);
  box-shadow: 0px 0px 2px rgba(0, 0, 0, 0.2), 0px 5px 10px rgba(151, 153, 158, 0.12);
}

.border-left {
  border-left: 1px solid rgba(12, 49, 118, 0.1);
}
</style>
