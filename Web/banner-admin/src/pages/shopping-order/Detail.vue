<template>
  <q-page class="q-pa-lg">
    <q-form @submit="submit" class="q-gutter-y-md">
      <c-subtitle title="訂單詳情" />
      <div class="row q-gutter-md">
        <span>訂單編號：12345678</span>
        <q-separator vertical />
        <span>訂單日期：2022/03/01</span>
      </div>
      <c-form-card v-for="course in courses" :key="course.id">
        <b>課程名稱</b>
        <p>【線上 - E1生命更新營】 實現 幸福夢想</p>
        <b>開課堂點</b>
        <p>台中旌旗教會 - 國光分點</p>
        <b>課程日期與地點</b>
        <p>
          日期：2022/02/19 (六) 9:00-18:00 <br>
          2022/02/20 (日) 9:00-15:00
          地點：線上ZOOM
        </p>
        <b>班級志願序填報</b>
        <p>班級志願序1：志願序1</p>
        <p>班級志願序2：志願序1</p>
      </c-form-card>
      <c-subtitle title="訂購人資料" />
      <c-form-card style="background:#F7F7F9;">
        <c-column label="姓名">
          <q-input dense v-model="form.name" />
        </c-column>
        <c-column label="通信地址">
          <q-input dense v-model="form.userAddress" />
        </c-column>
        <c-column label="行動電話">
          <q-input dense v-model="form.cellPhone" />
        </c-column>
        <c-column label="聯絡電話">
          <q-input dense v-model="form.tel" />
        </c-column>
        <c-column label="Email">
          <q-input dense v-model="form.email" />
        </c-column>
      </c-form-card>
      <c-subtitle title="付款方式" />
      <c-form-card class="column" style="background:#F7F7F9;">
        <q-radio v-model="form.paymentType" val="0" label="臨櫃現金" />
        <q-radio v-model="form.paymentType" val="1" label="Web ATM繳費" />
        <q-radio v-model="form.paymentType" val="2" label="信用卡支付" />
        <div class="q-ml-xl q-mb-md q-pa-md" style="border-radius:8px; border:1px dashed dodgerblue;width:fit-content;">
          <div class="flex items-center">
            <b class="q-mr-md">信用卡卡號</b>
            <q-input dense v-model="form.creditCard" />
          </div>
          <div class="flex items-center">
            <b class="q-mr-md">有效日</b>
            <q-input dense v-model="form.validYear" />
            <b class="text-h6 q-mx-md">/</b>
            <q-input dense v-model="form.validMonth" />
          </div>
          <div class="flex items-center">
            <b class="q-mr-md">安全碼</b>
            <q-input dense v-model="form.securityCode" />
          </div>
        </div>
      </c-form-card>
      <c-subtitle title="付款資訊" />
      <c-form-card style="background:#F7F7F9;">
        <p>訂單總金額：NT$1800</p>
        <p>訂單狀態：已完成</p>
        <p>付款日期：2022/03/12</p>
        <p>電子收據：A12345</p>
        <p>收款人(如為臨櫃現金)：XXO</p>
      </c-form-card>
    </q-form>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import {
  CoursePriceView, CourseTimeScheduleView,
  CreateShoppingOrderCommand,
  DeleteShoppingOrderCommand, QueryShoppingOrderDetailRequest, ShoppingOrderView, UpdateShoppingOrderCommand,
} from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import { Prop } from "vue-property-decorator";

interface Course$ {
  coursePrices: Array<CoursePriceView>;
  courseTimeSchedules: Array<CourseTimeScheduleView>;
  id: number;
  courseManagementId: number;
  organizationId: number;
  questionnaireId: number;
  year: string;
  name: string;
  classNum: string;
  season: string;
  openDate: string;
  signUpDateS: string;
  signUpDateE: string;
  discountSignUpDate: string;
  courseSignUpType: string;
  wishCount: number;
  needRecommend: string;
  acceptNewMember: string;
  description: string;
  classCount: number;
  quota: number;
  graduationType: string;
  specialRequirement: string;
  graduationQualification: string;
  courseContext: string;
  homeworkDate: string;
}

@Options({ meta() { return { title: "詳細資料", }; }, })
export default class Detail extends DetailComponentBase {
  @Prop({}) detail = {} as ShoppingOrderView;
  form = {
    name: "",
    userAddress: "",
    cellPhone: "",
    tel: "",
    email: "",
    paymentType: "",
    creditCard: "",
    validYear: "",
    validMonth: "",
    securityCode: "",
    courseName: "",
  };
  courses = [] as Course$[];

  async mounted() {
    if (this.detail.id) {
      let res = await this.apis.feature.shoppingOrder.getShoppingOrder(this.detail.id);
      Object.assign(this.form, res.data);
      let resShoppingOrderDetail = await this.apis.feature.shoppingOrderDetail.queryShoppingOrderDetails({
        shoppingOrderId: res.data.id,
      } as QueryShoppingOrderDetailRequest);
      for (let e of resShoppingOrderDetail.data.records) {
        let resCourse = await this.apis.feature.course.getCourse(e.courseId);
        this.form.courseName = resCourse.data.name;
        this.courses.push(Object.assign({}, resCourse.data));
      }
    }
  }

  @WithLoading()
  async submit() {
    if (this.detail.id) await this.updateAsync();
    else await this.createAsync();
  }
  async updateAsync() {
    await this.executeAsync(async () => await this.apis.feature.shoppingOrder.putShoppingOrder(this.form as unknown as UpdateShoppingOrderCommand))
  }
  async createAsync() {
    await this.executeAsync(async () => await this.apis.feature.shoppingOrder.createShoppingOrder(this.form as unknown as CreateShoppingOrderCommand))
  }
  async remove() {
    const courseName = this.detail.shoppingOrderDetailViews?.[0].courseViews?.[0].name || "";
    const confirm = await this.showConfirmDialogAsync(`確定刪除 ${courseName}？`, "請再次確認");
    if (!confirm) return;
    await this.apis.feature.shoppingOrder.deleteShoppingOrder({ id: this.detail.id } as unknown as DeleteShoppingOrderCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${courseName}`);
  }
}
</script>
