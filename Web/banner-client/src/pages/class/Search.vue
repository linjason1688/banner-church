<template>
  <div class="c-background-content">
    <div class="row justify-center c-background-content">
      <div class="col-12 col-sm-10 q-pa-lg">
        <c-nav-shopping-cart title="搜尋結果" />
        <div class="row items-center justify-center">
          <div class="col-12 col-sm-9 col-md-8 col-lg-7">
            <c-form-card>
              <div class="row justify-center">
                <div class="col-12 col-md-10">
                  <div class="row">
                    <div class="col-12">
                      <c-input-gutter role="edit2" placeholder="我想學習？" v-model="searchText">
                        <template v-slot:after>
                          <q-btn color="primary" round dense flat icon="search" @click="search" />
                        </template>
                      </c-input-gutter>
                    </div>
                  </div>
                  <div class="row justify-center">
                    <div class="col q-mx-sm q-gutter-sm">
                      <c-btn-filter-tag @click="searchText = '生命更新營';queryAsync();">生命更新營</c-btn-filter-tag>
                      <c-btn-filter-tag @click="searchText = '門徒建造營';queryAsync();">門徒建造營</c-btn-filter-tag>
                      <c-btn-filter-tag @click="searchText = '基督精兵營';queryAsync();">基督精兵營</c-btn-filter-tag>
                    </div>
                    <div class="col-12 col-sm-auto">
                      <q-btn
                        class="q-pl-none q-pr-xs q-mx-md"
                        color="primary"
                        icon-right="filter_alt"
                        flat
                        label="篩選"
                        @click="filter"
                      />
                    </div>
                  </div>
                </div>
              </div>
            </c-form-card>
          </div>
        </div>
      </div>
    </div>

    <div class="row justify-center q-mb-xl c-background-primary" style="background-clip: content-box">
      <div class="col-12 col-sm-10 q-pa-lg">
        <div class="row items-end">
          <div class="col q-mb-lg c-heading-h2 c-primary-color-400">搜尋結果({{getData.length}})</div>
        </div>
        <div class="row">
          <div v-for="(item, i) in getData" :key="i" class="col-12 col-md-6 col-lg-4 column items-center q-mb-xl">
            <c-class-card
              classImg="img/class_logo.svg"
              :classTitle="item.name"
              :earlybird="convertDiscountPrice(item)"
              :participator="item.description"
              :originalprice="convertPrice(item)"
              :classDate="item.classDate"
              joinType="線上課程"
              :isTracking="item.isTracking"
              :isInShoppingCart="item.isInShoppingCart"
              @onClickClassBtn="onClickClass(item.id)"
              v-on:onClickStarBtn="onClickStarBtn(item)"
              v-on:onClickPurchaseBtn="onClickShoppingCartBtn(item)"
            />
          </div>
        </div>
        <c-simple-pagination :page="pagination.page" :limit="pagination.cardPerPage" :total="cardLength" @change="pagination.page=$event"></c-simple-pagination>
      </div>
    </div>

    <q-dialog v-model="showFilterCard">
      <c-filter-card @completed="onFilterCompleted" />
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { QueryCourseRequest } from "src/api/feature";
import { Conditions } from "components/card/FilterCard.vue";
import { Prop } from "vue-property-decorator";
import { ComponentBase } from "src/components";
import NavShoppingCart from "components/navs/NavShoppingCart.vue";
import { addShoppingTrack, queryShoppingTracks, removeShoppingTrack } from "src/services/ShoppingTrack";
import { addShoppingCart, queryShoppingCart, removeShoppingCart } from "src/util";
import { isUserIdNumberDefined } from "src/services/User";

interface CoursePriceViews$ {
  priceName: string;
  price: number;
  isDueDate: string;
}
interface List$ {
  id: number;
  name: string;
  signUpDateS: string;
  signUpDateE: string;
  description: string;
  classDate: string;
  price: number;
  discountPrice: number;
  classTime: string;
  coursePrices: Array<CoursePriceViews$>;
  isTracking: boolean;
  isInShoppingCart: boolean;
  trackId: number;
  cartItemId: number;
}
@Options({
  components: {
    "c-nav-shopping-cart": NavShoppingCart,
  },
})
export default class Search extends ComponentBase {
  @Prop({ type: String })
  searchText = "";
  showFilterCard = false;

  /**
   * route :params props
   */
  @Prop({ type: String })
  readonly keyword!: string;

  private course1Rows: Array<List$> = [];
  private filterCondition!: Conditions;

  search() {
    void this.queryAsync();
    void this.queryShoppingCartAsync();
    void this.queryTrackingListAsync();
  }

  filter() {
    this.showFilterCard = true;
  }

  async onClickStarBtn(item: List$) {
    if (item.isTracking == false) {
      await addShoppingTrack(this.$appStore.getters.userProfile.id, item.id);
      void this.queryTrackingListAsync();
      this.showSuccessNotify("已加入追蹤清單");
    } else {
      await removeShoppingTrack(item.trackId);
      void this.queryTrackingListAsync();
      this.showSuccessNotify("課程已移除");
    }
  }

  async onClickShoppingCartBtn(item: List$) {
    let isValid = await isUserIdNumberDefined(this.$appStore.getters.userProfile.id);
    if (isValid == false) {
      this.showErrorNotify("不符合報名資格");
      return;
    }
    if (item.isInShoppingCart == false) {
      await this.addShoppingCartItem(item);
      void this.queryShoppingCartAsync();
      this.showSuccessNotify("已加入購物車");
    } else {
      await this.removeShoppingCartItem(item);
      void this.queryShoppingCartAsync();
      this.showSuccessNotify("已從購物車移除");
    }
  }
  async addShoppingCartItem(item: List$) {
    try {
      await addShoppingCart(this.$appStore.getters.userProfile.id, item.id);
    } catch (e) {
      this.showErrorNotify((e as Error).toString());
    }
  }
  async removeShoppingCartItem(item: List$) {
    await removeShoppingCart(item.cartItemId);
  }

  onFilterCompleted(filterConditions: Conditions) {
    this.showFilterCard = false;
    this.filterCondition = filterConditions;
    void this.queryAsync();
  }

  async mounted() {
    this.searchText = this.keyword;
    await this.queryAsync();
    await this.queryShoppingCartAsync();
    await this.queryTrackingListAsync();
  }

  onClickClass(courseId: number) {
    void this.$router.push(`/m/shopping-cart/detail/${courseId}`);
  }

  async queryAsync() {
    let request = {
      searchText: this.searchText,
    } as QueryCourseRequest;

    const filter = this.filterCondition;
    if (filter) {
      request = {
        ...request,
        // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
        openDateS: filter.selectedDateS,
        // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
        openDateE: filter.selectedDateE,
        // eslint-disable-next-line @typescript-eslint/no-unsafe-return,@typescript-eslint/no-unsafe-member-access
        organizations: Object.values(filter.selectedOrganizations).map((e) => e.id),
        // eslint-disable-next-line @typescript-eslint/no-unsafe-return,@typescript-eslint/no-unsafe-member-access
        courseType: Object.values(filter.selectedClassType).map((e) => e.index),
      } as QueryCourseRequest;
    }

    this.course1Rows = Object.assign(
      [],
      (await this.apis.feature.course.queryCourses(request)).data.records
    ) as Array<List$>;
    this.course1Rows.forEach((e) => {
      e.coursePrices = new Array<CoursePriceViews$>();
      e.coursePrices.push({
        isDueDate: "N",
        price: 1200,
        priceName: "原價",
      });
      e.coursePrices.push({
        isDueDate: "Y",
        price: 900,
        priceName: "早鳥價",
      });
    });
  }

  async queryShoppingCartAsync() {
    let shoppingCart = await queryShoppingCart(this.$appStore.getters.userProfile.id);
    for (let course of this.course1Rows) {
      let status = false;
      for (let cartItem of shoppingCart.records) {
        if (course.id == cartItem.courseId) {
          course.cartItemId = cartItem.id;
          status = true;
          break;
        }
      }
      course.isInShoppingCart = status;
    }
  }

  async queryTrackingListAsync() {
    let shoppingTrack = await queryShoppingTracks(this.$appStore.getters.userProfile.id);
    for (let course of this.course1Rows) {
      let status = false;
      for (let trackingItem of shoppingTrack.records) {
        if (course.id == trackingItem.courseId) {
          course.trackId = trackingItem.id;
          status = true;
          break;
        }
      }
      course.isTracking = status;
    }
  }

  convertPrice(e: List$) {
    if (e.coursePrices) {
      let result = "";
      e.coursePrices.forEach((e) => {
        if (e.isDueDate == "N") {
          result = `${e.priceName} NT$${e.price}`;
        }
      });
      return result;
    }
    return "";
  }
  convertDiscountPrice(e: List$) {
    if (e.coursePrices) {
      let result = "";
      e.coursePrices.forEach((e) => {
        if (e.isDueDate == "Y") {
          result = `${e.priceName} NT$${e.price}`;
        }
      });
      return result;
    }
    return "";
  }

  pagination = {
    page: 1,
    cardPerPage: 5,
    length: this.cardLength,
    prevPage: () => {
      if (this.pagination.page > 1) {
        this.pagination.page = this.pagination.page - 1;
      }
    },
    nextPage: () => {
      if (this.pagination.page < this.cardLength / this.pagination.cardPerPage + 1) {
        this.pagination.page = this.pagination.page + 1;
      }
    },
    firstPage: () => {
      this.pagination.page = 1;
    },
    lastPage: () => {
      this.pagination.page = Math.floor(this.cardLength / this.pagination.cardPerPage) + 1;
    },
  };

  get isFirstPage(): boolean {
    return this.pagination.page == 1;
  }

  get isLastPage(): boolean {
    return this.pagination.page == Math.floor(this.cardLength / this.pagination.cardPerPage) + 1;
  }

  get pageLength(): number {
    return Math.floor(this.cardLength / this.pagination.cardPerPage) + 1;
  }

  get cardLength() {
    return this.course1Rows.length;
  }

  get getData() {
    return this.course1Rows.slice(
      (this.pagination.page - 1) * this.pagination.cardPerPage,
      (this.pagination.page - 1) * this.pagination.cardPerPage + this.pagination.cardPerPage
    );
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
