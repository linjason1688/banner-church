<template>
  <div class="c-background-content">
    <div class="row justify-center c-background-content">
      <div class="col-12 col-sm-10 q-pa-lg">
        <c-nav-shopping-cart title="追蹤清單" />
      </div>
    </div>

    <div class="row justify-center q-mb-xl c-background-primary" style="background-clip: content-box">
      <div class="col-12 col-sm-10 q-pa-lg">
        <div class="row items-end">
          <div class="col q-mb-lg c-heading-h2 c-primary-color-400">目前追蹤({{ totalCount }})</div>
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
              isTracking="true"
              :isInShoppingCart="item.isInShoppingCart"
              @onClickClassBtn="onClickClass(item.id)"
              v-on:onClickStarBtn="onClickStarBtn(item.id)"
              v-on:onClickPurchaseBtn="onClickShoppingCartBtn(item)"
            />
          </div>
        </div>
        <div>
          <div class="gt-lg row justify-center" style="width: 100%">
            <div class="col-12 col-lg-2"></div>
            <div class="col-12 col-lg-8 q-pa-md row inline justify-center">
              <q-btn
                class="q-mx-sm c-gray-color-600"
                @click="pagination.firstPage()"
                :disable="isFirstPage"
                label="最前頁"
                outline
                padding="6px 24px"
                rounded
                size="sm"
              />
              <q-btn
                class="q-mx-sm c-gray-color-600"
                @click="pagination.prevPage()"
                :disable="isFirstPage"
                label="上頁"
                outline
                padding="6px 24px"
                rounded
                size="sm"
              />
              <p class="q-px-md q-my-none c-content-body self-center c-gray-color-600">
                <q-pagination v-model="pagination.page" :max="pageLength" color="grey" active-color="grey" />
              </p>
              <q-btn
                class="q-mx-sm c-gray-color-600"
                @click="pagination.nextPage()"
                :disable="isLastPage"
                label="下頁"
                outline
                padding="6px 24px"
                rounded
                size="sm"
              />
              <q-btn
                class="q-mx-sm c-gray-color-600"
                @click="pagination.lastPage()"
                :disable="isLastPage"
                label="最後頁"
                outline
                padding="6px 24px"
                rounded
                size="sm"
              />
            </div>
            <div class="col-12 col-lg-2 row inline justify-end">
              <p class="q-pr-sm q-my-none c-content-body self-center c-gray-color-600">
                第{{ pagination.page }} / {{ pageLength }}頁，共 {{ cardLength }} 筆
              </p>
            </div>
          </div>
          <div class="lt-xl row justify-center" style="width: 100%">
            <div class="gt-md col-lg-3"></div>
            <div class="col-12 col-lg-6 q-pa-sm row inline justify-center">
              <q-btn
                class="q-mx-xs c-gray-color-600"
                @click="pagination.firstPage()"
                :disable="isFirstPage"
                icon="keyboard_double_arrow_left"
                outline
                round
                size="md"
              />
              <q-btn
                class="q-mx-xs c-gray-color-600"
                @click="pagination.prevPage()"
                :disable="isFirstPage"
                icon="keyboard_arrow_left"
                outline
                round
                size="md"
              />
              <p class="q-px-sm q-my-none gt-md c-content-body self-center c-gray-color-600">
                <q-pagination v-model="pagination.page" :max="pageLength" color="grey" active-color="grey" />
              </p>
              <q-btn
                class="q-mx-xs c-gray-color-600"
                @click="pagination.nextPage()"
                :disable="isLastPage"
                icon="keyboard_arrow_right"
                outline
                round
                size="md"
              />
              <q-btn
                class="q-mx-xs c-gray-color-600"
                @click="pagination.lastPage()"
                :disable="isLastPage"
                icon="keyboard_double_arrow_right"
                outline
                round
                size="md"
              />
            </div>
            <div class="lt-lg col-12 q-pa-sm row inline justify-center">
              <p class="q-px-sm q-my-none c-content-body self-center c-gray-color-600">
                <q-pagination v-model="pagination.page" :max="pageLength" color="grey" active-color="grey" />
              </p>
            </div>
            <div class="col-12 col-lg-3 q-pa-sm row inline justify-center">
              <p class="q-pr-sm q-my-none c-content-body self-center c-gray-color-600">
                第{{ pagination.page }} / {{ pageLength }}頁，共 {{ cardLength }} 筆
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>

    <c-dialog-alert
      v-model:dialog.sync="alertDialog"
      title="重要提示"
      content="請至會員中心完善個人資料(身分證、居留證/護照欄位)，才可加入購物車。"
      btnLabel="前往會員中心"
      @click="gotoMember()"
    ></c-dialog-alert>

    <q-dialog v-model="showFilterCard">
      <c-filter-card @completed="onFilterCompleted" />
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { Conditions } from "components/card/FilterCard.vue";
import { Prop } from "vue-property-decorator";
import { ComponentBase } from "src/components";
import { queryShoppingTracks, removeShoppingTrack } from "src/services/ShoppingTrack";
import NavShoppingCart from "components/navs/NavShoppingCart.vue";
import { addShoppingCart, removeShoppingCart, queryShoppingCart } from "src/util";
import { isUserIdNumberDefined } from "src/services/User";

interface CoursePriceViews$ {
  priceName: string;
  price: number;
  isDueDate: string;
}

interface List$ {
  id: number;
  name: string;
  courseId: number;
  signUpDateS: string;
  signUpDateE: string;
  description: string;
  classDate: string;
  price: number;
  discountPrice: number;
  classTime: string;
  coursePrices: Array<CoursePriceViews$>;
  isInShoppingCart: boolean;
  shoppingCartId: number;
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
  alertDialog = false;

  /**
   * route :params props
   */
  @Prop({ type: String })
  readonly keyword!: string;

  rows: Array<List$> = [];
  totalCount: number = 0;
  private filterCondition!: Conditions;

  search() {
    void this.queryAsync();
  }

  filter() {
    this.showFilterCard = true;
  }

  gotoMember() {
    void this.$router.push("/m/member/index");
  }

  async onClickStarBtn(trackId: number) {
    await removeShoppingTrack(trackId);
    void this.queryAsync();
    this.showSuccessNotify("課程已移除");
  }

  async onClickShoppingCartBtn(item: List$) {
    let isValid = await isUserIdNumberDefined(this.$appStore.getters.userProfile.id);
    if (isValid == false) {
      this.showErrorNotify("不符合報名資格");
      return;
    }
    if (item.isInShoppingCart == false) {
      await this.addShoppingCartItem(item);
      void this.queryAsync();
      this.showSuccessNotify("已加入購物車");
    } else {
      await this.removeShoppingCartItem(item);
      void this.queryAsync();
      this.showSuccessNotify("已從購物車移除");
    }
  }
  async addShoppingCartItem(item: List$) {
    try {
      await addShoppingCart(this.$appStore.getters.userProfile.id, item.courseId);
    } catch (e) {
      this.showErrorNotify((e as Error).toString());
    }
  }
  async removeShoppingCartItem(item: List$) {
    await removeShoppingCart(item.shoppingCartId);
  }

  onFilterCompleted(filterConditions: Conditions) {
    this.showFilterCard = false;
    this.filterCondition = filterConditions;
    void this.queryAsync();
  }

  async created() {
    let valid = await isUserIdNumberDefined(this.$appStore.getters.userProfile.id);
    if (valid == false) {
      this.alertDialog = true;
    }
    this.searchText = this.keyword;
    await this.queryAsync();
  }

  onClickClass(courseId: number) {
    void this.$router.push(`/m/shopping-cart/detail/${courseId}`);
  }

  async queryAsync() {
    const shoppingTrack = await queryShoppingTracks(this.$appStore.getters.userProfile.id);
    let shoppingCart = await queryShoppingCart(this.$appStore.getters.userProfile.id);
    this.rows = shoppingTrack.records as unknown as Array<List$>;
    this.totalCount = shoppingTrack.totalCount;
    for (let trackItem of this.rows) {
      let status = false;
      for (let cartItem of shoppingCart.records) {
        if (trackItem.courseId == cartItem.courseId) {
          trackItem.shoppingCartId = cartItem.id;
          status = true;
          break;
        }
      }
      trackItem.isInShoppingCart = status;
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
    return this.rows.length;
  }

  get getData() {
    return this.rows.slice(
      (this.pagination.page - 1) * this.pagination.cardPerPage,
      (this.pagination.page - 1) * this.pagination.cardPerPage + this.pagination.cardPerPage
    );
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
