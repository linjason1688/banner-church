<template>
  <div class="c-background-content">
    <div class="row justify-center c-background-content">
      <div class="col-12 col-sm-10 q-pa-lg">
        <div class="row">
          <div class="col-12">
            <q-form @submit="onSubmit" @validation-error="onValidationError">
              <c-sub-title title="報名課程與班級志願序" />
              <c-form-check-course
                v-for="(value, index) in cartItems"
                :key="index"
                :joinList="joinList"
                v-model:cartItem="cartItems[index]"
              ></c-form-check-course>

              <c-sub-title title="訂購人資料" />
              <c-form-card class="q-mb-sm c-card">
                <div class="row">
                  <div class="col-12 col-md-4">
                    <c-column label="姓名">
                      <c-input v-model="form.userName" :rules="[(val) => !!val || '請填入姓名']" role="n"></c-input>
                    </c-column>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12 col-md-5">
                    <c-column label="通信地址">
                      <c-input
                        v-model="form.userAddress"
                        :rules="[(val) => !!val || '請填入通信地址']"
                        role="n"
                      ></c-input>
                    </c-column>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12 col-md-5">
                    <c-column label="行動電話">
                      <c-input
                        v-model="form.userCellPhone"
                        :rules="[
                          (val) => !!val || '輸入手機號碼',
                          (val) => val.length >= 10 || '請輸入10位以上數字',
                          (val) => /^\d+$/.test(val) || '手機號碼只允許數字',
                        ]"
                        role="n"
                      ></c-input>
                    </c-column>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12 col-md-5">
                    <c-column label="聯絡電話">
                      <c-input
                        v-model="form.userPhone"
                        :rules="[(val) => !!val || '輸入聯絡電話', (val) => /^\d+$/.test(val) || '聯絡電話只允許數字']"
                        role="n"
                      ></c-input>
                    </c-column>
                  </div>
                </div>
                <div class="row">
                  <div class="col-12 col-md-5">
                    <c-column label="Email">
                      <c-input
                        v-model="form.userEmail"
                        :rules="[(val) => !!val || '請填入Email', emailRule]"
                        role="n"
                      ></c-input>
                    </c-column>
                  </div>
                </div>
              </c-form-card>

              <c-sub-title title="付款方式" />
              <c-form-card class="q-mb-sm c-card">
                <div class="row">
                  <div class="col-12 col-md-5">
                    <c-column>
                      <q-field v-model="form.paymentType" borderless :rules="[(val) => !!val || '請選擇支付方式']">
                        <div class="col-12 column">
                          <q-radio
                            v-model="form.paymentType"
                            val="0"
                            label="臨櫃現金"
                            dense
                            class="q-py-sm c-content-body c-text-color-100"
                          >
                          </q-radio>
                          <q-radio
                            v-model="form.paymentType"
                            val="1"
                            label="Web ATM繳費"
                            dense
                            class="q-py-sm c-content-body c-text-color-100"
                            disable
                          >
                          </q-radio>
                          <q-radio
                            v-model="form.paymentType"
                            val="2"
                            label="信用卡支付"
                            dense
                            class="q-py-sm c-content-body c-text-color-100"
                            disable
                          >
                          </q-radio>
                          <q-card v-if="form.paymentType === '2'" flat bordered class="q-pa-md q-ml-lg c-dotted-border">
                            <div class="row items-center">
                              <div class="col-12 col-sm-auto self-center">信用卡卡號</div>
                              <div class="col-12 col-sm-grow">
                                <c-column>
                                  <c-input
                                    v-model="form.cardNumber"
                                    :rules="[
                                      (val) => !!val || '輸入信用卡卡號',
                                      (val) => (val.length = 16 || '信用卡卡號為16位數數字'),
                                      (val) => /^\d+$/.test(val) || '信用卡卡號只允許數字',
                                    ]"
                                    role="n"
                                  ></c-input>
                                </c-column>
                              </div>
                            </div>
                            <div class="row items-center">
                              <div class="col-12 col-sm-auto self-center">有效日</div>
                              <div class="col-12 col-sm-grow">
                                <div class="row justify-between flex-center">
                                  <div class="col">
                                    <c-column>
                                      <c-input
                                        v-model="form.cardExpMonth"
                                        :rules="[
                                          (val) => !!val || '請填入有效月份',
                                          (val) => (val.length = 2 || '有效月份為2位數數字'),
                                          (val) => /^\d+$/.test(val) || '有效月份只允許數字',
                                        ]"
                                        role="n"
                                      ></c-input>
                                    </c-column>
                                  </div>
                                  <div class="col-auto">/</div>
                                  <div class="col">
                                    <c-column>
                                      <c-input
                                        v-model="form.cardExpYear"
                                        :rules="[
                                          (val) => !!val || '請填入有效年份',
                                          (val) => (val.length = 2 || '有效年份為2位數數字'),
                                          (val) => /^\d+$/.test(val) || '有效年份只允許數字',
                                        ]"
                                        role="n"
                                      ></c-input>
                                    </c-column>
                                  </div>
                                </div>
                              </div>
                            </div>
                            <div class="row items-center">
                              <div class="col-12 col-sm-auto self-center">安全碼</div>
                              <div class="col-12 col-sm-grow">
                                <c-column>
                                  <c-input
                                    v-model="form.cardCSC"
                                    :rules="[
                                      (val) => !!val || '請填入安全碼',
                                      (val) => (val.length = 3 || '安全碼為3位數數字'),
                                      (val) => /^\d+$/.test(val) || '安全碼只允許數字',
                                    ]"
                                    role="n"
                                  ></c-input>
                                </c-column>
                              </div>
                            </div>
                          </q-card>
                        </div>
                      </q-field>
                    </c-column>
                  </div>
                </div>
                <div class="row items-center justify-end c-shopping-cart-title">
                  <div class="col-auto row justify-end">
                    <div class="q-px-md q-mb-md">本次訂單金額：{{ form.totalAmount }}</div>
                  </div>
                  <div class="col-auto">
                    <q-btn rounded type="submit" class="app-class-cart-btn_filled q-px-lg q-py-xs q-mx-md q-mb-md">
                      確認結帳
                    </q-btn>
                    <q-btn
                      rounded
                      class="app-class-cart-btn_filled q-px-lg q-py-xs q-mx-md q-mb-md"
                      @click="gotoPrevPage()"
                    >
                      取消
                    </q-btn>
                  </div>
                </div>
              </c-form-card>
            </q-form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import SubTitle from "components/SubTitle.vue";
import {
  OrganizationView,
  ShoppingCartView,
  CourseTimeScheduleView,
  QueryShoppingCartRequest,
  CourseView,
  CreateShoppingOrderCommand,
  CreateShoppingOrderDetailCommand,
} from "src/api/feature/api";
import { scroll } from "quasar";
import { User } from "src/services";
import { removeShoppingCart } from "src/util";

const { getScrollTarget, setVerticalScrollPosition } = scroll;

class Cart {
  courseId: number = 0;
  cartItemId: number = 0;
  courseName?: string;
  organizationName?: string;
  courseTimeSchedules?: Array<CourseTimeScheduleView>;
  join1?: string;
  join2?: string;
  join3?: string;
  price?: number;
  isInPlace?: boolean;
  isViggieHelp?: string;
  isMoveHelp?: string;
  isPregnancyHelp?: string;
  isOthersHelp?: string;
  isOthersHelpInformations?: string;
  isCoupleSameClassHelp?: string;
  isCoupleSameClassInformations?: string;
}

@Options({
  components: {
    "c-sub-title": SubTitle,
  },
})
export default class Check extends ComponentBase {
  joinList = [
    {
      value: "志願序標題1",
      name: "志願序值1",
    },
    {
      value: "志願序標題2",
      name: "志願序值2",
    },
  ];

  cartItems = new Array<Cart>();
  cartItems1 = [
    {
      courseName: "【線上 - E1生命更新營】  實現 幸福夢想",
      organizationName: "台中旌旗教會",
      courseTimeSchedules: [
        {
          classDay: "2022/02/19 (六)",
          classTimeS: "9:00",
          classTimeE: "18:00",
          place: "線上ZOOM",
        },
        {
          classDay: "2022/02/20 (日)",
          classTimeS: "9:00",
          classTimeE: "15:00",
          place: "線上ZOOM",
        },
      ],
      join1: "",
      join2: "",
      join3: "",
      specialRequirement: [],
      otherSpecialRequirement: "",
      spouseName: "",
    },
    {
      courseName: "【線上 - E2生命更新營】  實現 幸福夢想",
      organizationName: "台北旌旗教會",
      courseTimeSchedules: [
        {
          classDay: "2022/02/21 (六)",
          classTimeS: "9:00",
          classTimeE: "18:00",
          place: "線上ZOOM",
        },
        {
          classDay: "2022/02/22 (日)",
          classTimeS: "9:00",
          classTimeE: "15:00",
          place: "線上ZOOM",
        },
      ],
      join1: "",
      join2: "",
      join3: "",
      specialRequirement: [],
      otherSpecialRequirement: "",
      spouseName: "",
    },
  ];

  form = {
    userName: undefined, //訂購人姓名
    userAddress: undefined, //訂購人通信地址
    userCellPhone: undefined, //訂購人行動電話
    userPhone: undefined, //訂購人聯絡電話
    userEmail: undefined || "", //訂購人Email

    paymentType: "0", //付款方式
    orderPayStatus: "0", //付款狀態
    orderStatus: "0", //訂單狀態
    cardNumber: undefined, //信用卡卡號
    cardExpMonth: undefined, //有效月份
    cardExpYear: undefined, //有效年份
    cardCSC: undefined, //安全碼

    totalAmount: undefined || "", //訂單金額
  };

  organizationList = new Array<OrganizationView>();

  async mounted() {
    this.organizationList = (await this.apis.feature.organization.fetchOrganizations()).data;
    await this.queryAsync();
  }

  async queryAsync() {
    let userId = this.$appStore.getters.userProfile.id;
    let organizationId = this.$route.query.organizationId as unknown as number;
    let courseId = this.$route.query.courseId as unknown as number;
    if (organizationId == undefined) {
      this.showErrorNotify("找不到堂點");
      return;
    }

    let request = {
      userId: userId,
      courseId: courseId,
    } as QueryShoppingCartRequest;
    let cartRecords: Array<ShoppingCartView> = (await this.apis.feature.shoppingCart.queryShoppingCarts(request)).data
      .records;

    let amount = 0;
    for (let cartRecordsDetail of cartRecords) {
      let courseDetail = {} as CourseView;

      await this.apis.feature.course.getCourse(cartRecordsDetail.courseId).then(
        (response) => {
          courseDetail = response.data;

          if (courseDetail.organizationId != organizationId) {
            return;
          }

          let price = 0;
          for (let p of courseDetail.coursePrices) {
            price += p.price;
            if (p.isDueDate === "Y") {
              amount += p.price;
            }
          }
          let cartItem = {
            courseId: courseDetail.id,
            cartItemId: cartRecordsDetail.id,
            courseName: courseDetail.name,
            organizationName: this.convertOrganization(courseDetail.organizationId),
            isInPlace: this.checkIsInPlace(courseDetail.organizationId),
            courseTimeSchedules: courseDetail.courseTimeSchedules,
            join1: "",
            join2: "",
            join3: "",
            specialRequirement: [],
            otherSpecialRequirement: "",
            spouseName: "",
            price: price,
            amount: price,
            isViggieHelp: "0",
            isMoveHelp: "0",
            isPregnancyHelp: "0",
            isOthersHelp: "0",
            isOthersHelpInformations: "",
            isCoupleSameClassHelp: "0",
            isCoupleSameClassInformations: "",
          } as Cart;

          this.cartItems.push(cartItem);
        },
        () => {
          //
        }
      );
    }
    this.form.totalAmount = amount.toString();
  }

  private convertOrganization(val: number): string {
    if (val === 0) return "";
    const found = this.organizationList.find((e) => e.id === val);
    if (found) return found.name;
    return val?.toString() || "";
  }

  private checkIsInPlace(val: number): boolean {
    const found = this.organizationList.find((e) => e.id === val);
    if (found) return true;
    return false;
  }

  async onSubmit() {
    await this.createOrder();
    await this.removeCartItems();
    void this.$router.push("/m/class/index");
  }

  async createOrder() {
    let shoppingOrderId = 0;
    let request = Object.assign({} as CreateShoppingOrderCommand, this.form);
    await this.apis.feature.shoppingOrder
      .createShoppingOrder(request)
      .then((response) => {
        shoppingOrderId = response.data.id;
      })
      .catch(() => {
        throw Error("建立訂單失敗");
      });

    for (let cartItem of this.cartItems) {
      let detailRequest = Object.assign({} as CreateShoppingOrderDetailCommand, cartItem);
      detailRequest.shoppingOrderId = shoppingOrderId;
      detailRequest.count = 1;
      detailRequest.orderDetailStatus = "0";

      await this.apis.feature.shoppingOrderDetail.createShoppingOrderDetail(detailRequest).catch(() => {
        throw Error("建立訂單明細失敗");
      });
    }
    this.showSuccessNotify("已建立訂單");
  }

  async removeCartItems() {
    for (let cartItem of this.cartItems) {
      await removeShoppingCart(cartItem.cartItemId);
    }
  }

  /* eslint-disable*/
  onValidationError(ref: any) {
    //scroll to error element
    var el = ref.$el;

    //元素距離頁面頂部距離
    var offset = el.getBoundingClientRect().top + window.pageYOffset;
    // console.log(offset)
    var duration = 200;
    setVerticalScrollPosition(getScrollTarget(el), offset, duration);
  }
  /* eslint-enable*/

  emailRule() {
    if (User.emailRule.test(this.form.userEmail)) {
      return true;
    }
    return "Email格式錯誤";
  }

  gotoPrevPage() {
    this.$router.back();
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
