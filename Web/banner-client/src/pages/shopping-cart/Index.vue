<template>
  <div class="c-background-content">
    <div class="row justify-center c-background-content">
      <div class="col-12 col-sm-10 q-pa-lg">
        <c-nav-shopping-cart title="購物車" />

        <div class="row">
          <div class="col-12">
            <c-form-card class="c-gray-bgcolor-50 q-mb-xl" v-for="(value, index) in cart" :key="index">
              <c-sub-title :title="`開課堂點：${value.organizationName}`" />
              <div class="gt-md row c-shopping-cart-title c-bgcolor-gray-white q-px-md q-py-sm q-mb-lg">
                <div class="col-lg-6">課程名稱</div>
                <div class="col-lg-2">售價</div>
                <div class="col-lg-3">課程日期</div>
                <div class="col-lg-1">其他操作</div>
              </div>
              <c-cart-item-card
                v-for="(c, index) in value.class"
                :key="index"
                :courseId="c.id"
                :name="c.name"
                image="img/class-cover.svg"
                :price="currentType + calcCoursePrices(c.coursePrices)"
                :dateAry="[c.openDateS.substring(0, 10),c.openDateE.substring(0, 10)]"
                @removeFromCart="removeItem(value.cart.id)"
              ></c-cart-item-card>
              <div class="row items-center justify-end c-shopping-cart-title">
                <div class="col-auto row justify-end">
                  <div class="q-px-md q-mb-md">商品總金額： {{ currentType }}{{ calcDefaultAmount(value.class) }}</div>
                  <div class="q-px-md q-mb-md">折價金額： {{ currentType }}{{ calcDiscount(value.class) }}</div>
                  <div class="q-px-md q-mb-md">總金額： {{ currentType }}{{ calcAmount(value.class) }}</div>
                </div>
                <div class="col-auto">
                  <q-btn
                    rounded
                    class="app-class-cart-btn_filled q-px-lg q-py-xs q-mx-md q-mb-md"
                    @click="onClickCheck(value.organizationId)"
                    >結帳({{ value.class.length }})
                  </q-btn>
                </div>
              </div>
            </c-form-card>
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
import NavShoppingCart from "components/navs/NavShoppingCart.vue";
import { queryShoppingCart, removeShoppingCart } from "src/util";
import { OrganizationView, CourseView, ShoppingCartView, CoursePriceView } from "src/api/feature/api";

interface ShoppingCart$ {
  organizationId: number;
  organizationName: string;
  defaultAmount: number;
  discount: number;
  amount: number;
  class: Array<CourseView>;
  cart: ShoppingCartView;
}

@Options({
  components: {
    "c-nav-shopping-cart": NavShoppingCart,
    "c-sub-title": SubTitle,
  },
})
export default class Index extends ComponentBase {
  currentType = "NT$";
  cart: Array<ShoppingCart$> = [];
  cart1 = [
    {
      organizations: "台中旌旗教會",
      class: [
        {
          name: "【線上-E1生命更新營】實現 幸福夢想",
          image: "img/class-cover.svg",
          price: "NT$900",
          date: ["2022/02/19 (六) 9:00-18:00", "2022/02/20 (日) 9:00-15:00"],
        },
        {
          name: "【線上-E2門徒建造營】實現 幸福夢想",
          image: "img/class-cover.svg",
          price: "NT$900",
          date: ["2022/02/19 (六) 9:00-18:00", "2022/02/20 (日) 9:00-15:00"],
        },
      ],
      defaultAmount: "NT$1800",
      discount: "NT$0",
      amount: "NT$1800",
    },
    {
      organizations: "高雄旌旗教會",
      class: [
        {
          name: "【線上-E3基督精兵營】實現 幸福夢想",
          image: "img/class-cover.svg",
          price: "NT$900",
          date: ["2022/02/19 (六) 9:00-18:00", "2022/02/20 (日) 9:00-15:00"],
        },
      ],
      defaultAmount: "NT$900",
      discount: "NT$0",
      amount: "NT$900",
    },
  ];
  organizationList = new Array<OrganizationView>();

  async mounted() {
    this.organizationList = (await this.apis.feature.organization.fetchOrganizations()).data;
    await this.queryAsync();
  }

  async queryAsync() {
    const response = await queryShoppingCart(this.$appStore.getters.userProfile.id);
    this.cart = await this.coursesClassify(response.records);
  }

  async coursesClassify(cartAry: ShoppingCartView[]): Promise<ShoppingCart$[]> {
    let groups: Array<ShoppingCart$> = [];
    for (let cart of cartAry) {
      let response = await this.apis.feature.course.findCourse(cart.courseId);
      let course = response.data.records[0];
      if (course == undefined) {
        continue;
      }
      course.coursePrices;

      let organizationGroup = groups.find((x) => x.organizationId == course.organizationId);
      if (organizationGroup == undefined) {
        let group: ShoppingCart$ = {
          organizationId: course.organizationId,
          organizationName: this.convertOrganization(course.organizationId),
          defaultAmount: 0,
          discount: 0,
          amount: 0,
          class: [course],
          cart: cart,
        };
        groups.push(group);
      } else {
        organizationGroup.class.push(course);
      }
    }
    return groups;
  }

  calcCoursePrices(prices: Array<CoursePriceView>): number {
    if(prices.length == 0){
      return 0;
    }
    let price = Infinity;
    prices.map(function(x){
      if(x.price < price){
        price = x.price;
      }
    })
    if(price != Infinity){
      return price;
    }
    return 0;
  }

  calcDefaultAmount(courses: Array<CourseView>): number{
    let defaultAmount = 0;
    courses.map(function(course){
      let min = 0;
      course.coursePrices.map(function(price){
        if(price.price > min){
          min = price.price;
        }
      })
      defaultAmount += min;
    })
    return defaultAmount
  }

  calcDiscount(courses: Array<CourseView>): number{
    let spread = 0;//價差
    courses.map(function(course){
      let defaultAmount = 0;//原價
      let discountedAmount = 0;//早鳥價
      course.coursePrices.map(function(price){
        if(price.priceName == "原價"){
          defaultAmount += price.price;
        }
        else if(price.priceName == "早鳥價"){
          discountedAmount += price.price;
        }
      })
      if(discountedAmount != 0){
        spread += (defaultAmount-discountedAmount);
      }
    })
    return spread
  }

  calcAmount(courses: Array<CourseView>): number{
    let amount = 0;
    courses.map(function(course){
      let max = Infinity;
      course.coursePrices.map(function(price){
        if(price.price < max){
          max = price.price
        }
      })
      if(max != Infinity){
        amount += max;
      }
    })
    return amount
  }

  async removeItem(id: number) {
    await removeShoppingCart(id);

    this.cart.forEach((c) => {
      const index = c.class.findIndex((e) => e.id == id);
      c.class.splice(index, 1);
    });
  }

  onClickCheck(value: number) {
    void this.$router.push({
      path: "/m/shopping-cart/check",
      query: {
        organizationId: value,
      },
    });
  }

  convertOrganization(val: number): string {
    if (val === 0) return "";
    const found = this.organizationList.find((e) => e.id === val);
    if (found) return found.name;
    return val?.toString() || "";
  }

  findObject(organizationId: number): ShoppingCart$ | undefined {
    const found = this.cart.find((e) => e.organizationId === organizationId);
    if (found) {
      return found;
    } else {
      return undefined;
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
