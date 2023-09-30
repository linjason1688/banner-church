<template>
  <div class="c-background-content">
    <div class="row">
      <div class="col">
        <q-carousel v-model="slide" animated arrows navigation infinite height="287px">
          <template v-slot:navigation-icon="{ active, btnProps, onClick }">
            <q-btn size="sm" :icon="btnProps.icon" :color="active?'amber-5':'white'" flat round dense @click="onClick" />
          </template>

          <q-carousel-slide name="style" img-src="img/class_logo.svg" />
          <q-carousel-slide name="tv" img-src="img/class_logo.svg" />
          <q-carousel-slide name="layers" img-src="img/class_logo.svg" />
          <q-carousel-slide name="map" img-src="img/class_logo.svg" />
        </q-carousel>
      </div>
    </div>

    <div class="row justify-center c-background-content">
      <div class="col-12 col-sm-10 q-pa-lg">
        <div class="row q-mt-md q-mb-lg">
          <div class="col-12 col-sm-5 q-py-sm c-gray-800">個人所在堂點：台中旌旗教會分堂</div>
          <div class="col-12 col-sm-7 text-right">
            <q-btn class="q-px-md" size="sm" flat>
              <q-icon left name="star" />
              <div class="app-class-cart-btn" @click="gotoTrackingItem">追蹤清單</div>
            </q-btn>
            <q-btn class="q-px-md" size="sm" flat>
              <q-icon left name="shopping_cart" />
              <div class="app-class-cart-btn" @click="gotoShoppingCart">購物車</div>
            </q-btn>
            <q-btn class="q-px-md" size="sm" flat>
              <q-icon left name="list" />
              <div class="app-class-cart-btn">訂單管理</div>
            </q-btn>
          </div>
        </div>
        <div class="row items-center">
          <div class="col-12 col-md-5 q-mb-md c-heading-h1 c-primary-color-400">
            生活樂趣百百種
            <br />
            樂活體驗課程隨你選
          </div>
          <div class="col-12 col-md-7">
            <c-form-card>
              <div class="row justify-center">
                <div class="col-12 col-md-10">
                  <div class="row">
                    <div class="col-12">
                      <c-input-gutter role="edit2" placeholder="我想學習？" v-model="searchText">
                        <template v-slot:after>
                          <q-btn color="primary" round dense flat icon="search" @click="gotoSearch(searchText)" />
                        </template>
                      </c-input-gutter>
                    </div>
                  </div>
                  <div class="row justify-center">
                    <div class="col q-mx-sm q-gutter-sm">
                      <c-btn-filter-tag @click="gotoSearch('生命更新營')">生命更新營 </c-btn-filter-tag>
                      <c-btn-filter-tag @click="gotoSearch('門徒建造營')">門徒建造營 </c-btn-filter-tag>
                      <c-btn-filter-tag @click="gotoSearch('基督精兵營')">基督精兵營 </c-btn-filter-tag>
                    </div>
                    <div class="col-12 col-sm-auto">
                      <q-btn
                        class="q-pr-xs q-mr-md"
                        color="primary"
                        icon-right="filter_alt"
                        flat
                        label="篩選"
                        @click="showFilterCard = !showFilterCard"
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

    <!--經典課程-->
    <div class="row justify-center q-mb-xl c-background-primary" style="background-clip: content-box">
      <div class="col-12 col-sm-10 q-pa-lg">
        <div class="row items-end">
          <div class="col q-mb-lg c-heading-h2 c-primary-color-400">經典課程</div>
          <div class="col-auto q-mb-lg justify-end c-content-body c-secondary-color-500">更多經典課程 ——</div>
        </div>
        <div class="row q-mb-lg">
          <div class="col-12">
            <swiper :slidesPerView="slidesPerView" :spaceBetween="50" :navigation="true" :modules="modules">
              <swiper-slide v-for="item in course1Rows" :key="item.id">
                <c-class-card
                  :classImg="item.cover"
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
              </swiper-slide>
              <q-resize-observer @resize="onResize" />
            </swiper>
          </div>
        </div>
      </div>
    </div>

    <!--最新課程-->
    <div class="row justify-center q-mb-xl c-background-primary" style="background-clip: content-box">
      <div class="col-12 col-sm-10 q-pa-lg">
        <div class="row items-end">
          <div class="col q-mb-lg c-heading-h2 c-primary-color-400">最新課程</div>
          <div class="col-auto q-mb-lg justify-end c-content-body c-secondary-color-500">更多最新課程 ——</div>
        </div>
        <div class="row q-mb-lg">
          <div class="col-12">
            <swiper :slidesPerView="slidesPerView" :spaceBetween="50" :navigation="true" :modules="modules">
              <swiper-slide v-for="item in course2Rows" :key="item.id">
                <c-class-card
                  :classImg="item.cover"
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
              </swiper-slide>
              <q-resize-observer @resize="onResize" />
            </swiper>
          </div>
        </div>
      </div>
    </div>

    <!--即將結束報名課程-->
    <div class="row justify-center q-mb-xl c-background-primary" style="background-clip: content-box">
      <div class="col-12 col-sm-10 q-pa-lg">
        <div class="row items-end">
          <div class="col q-mb-lg c-heading-h2 c-primary-color-400">即將結束報名課程</div>
          <div class="col-auto q-mb-lg justify-end c-content-body c-secondary-color-500">更多即將結束報名課程 ——</div>
        </div>
        <div class="row q-mb-lg">
          <div class="col-12">
            <swiper :slidesPerView="slidesPerView" :spaceBetween="50" :navigation="true" :modules="modules">
              <swiper-slide v-for="item in course3Rows" :key="item.id">
                <c-class-card
                  :classImg="item.cover"
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
              </swiper-slide>
              <q-resize-observer @resize="onResize" />
            </swiper>
          </div>
        </div>
      </div>
    </div>

    <q-dialog v-model="showFilterCard">
      <c-filter-card @completed="onFilterCompleted" />
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Options } from "vue-class-component";
import { ref } from "vue";
import { Conditions } from "src/components/card/FilterCard.vue";
import { Swiper, SwiperSlide } from "swiper/vue";
import { Pagination, Navigation } from "swiper";
import "swiper/css";
import "swiper/css/pagination";
import "swiper/css/navigation";
import { QueryCourseRequest } from "src/api/feature";
import { convertDiscountPrice, convertPrice, Course$ } from "src/services/CoursePrice";
import { FileRootUrl } from "src/data/constants/ApiEnums";
import { formatDate } from "src/util";
import { addShoppingTrack, queryShoppingTracks, removeShoppingTrack } from "src/services/ShoppingTrack";
import { addShoppingCart, queryShoppingCart, removeShoppingCart } from "src/util";
import { isUserIdNumberDefined } from "src/services/User";

interface List$ extends Course$ {
  classDate: string;

  id: number;
  trackId: number;
  cartItemId: number;
  isTracking: boolean;
  isInShoppingCart: boolean;
}

@Options({
  components: {
    Swiper,
    SwiperSlide,
  },
})
export default class Index extends ComponentBase {
  slide = ref("style");

  slidesPerView = 3;

  modules = [Pagination, Navigation];

  searchText = "";
  showFilterCard = false;

  private course1Rows: Array<List$> = [{} as List$];
  private course2Rows: Array<List$> = [];
  private course3Rows: Array<List$> = [];
  private filterCondition!: Conditions;

  async search() {
    await this.queryAsync();
  }

  filter() {
    console.log("filter");
  }

  onResize() {
    if (this.$q.screen.width < 930) {
      this.slidesPerView = 1;
    } else if (this.$q.screen.width < 1439.99) {
      this.slidesPerView = 2;
    } else {
      this.slidesPerView = 3;
    }
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
    void this.queryShoppingCartAsync();
    void this.queryTrackingListAsync();
  }

  async mounted() {
    await this.queryAsync();
    await this.queryShoppingCartAsync();
    await this.queryTrackingListAsync();
  }

  async queryShoppingCartAsync() {
    let shoppingCart = await queryShoppingCart(this.$appStore.getters.userProfile.id);

    let fetchCartItem = function (ary: List$[]) {
      for (let course of ary) {
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
    };
    fetchCartItem(this.course1Rows);
    fetchCartItem(this.course2Rows);
    fetchCartItem(this.course3Rows);
  }

  async queryTrackingListAsync() {
    let shoppingTrack = await queryShoppingTracks(this.$appStore.getters.userProfile.id);
    let fetchTrackingItem = function (ary: List$[]) {
      for (let course of ary) {
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
    };
    fetchTrackingItem(this.course1Rows);
    fetchTrackingItem(this.course2Rows);
    fetchTrackingItem(this.course3Rows);
  }

  onClickClass(courseId: number) {
    void this.$router.push(`/m/class/detail/${courseId}`);
  }

  gotoSearch(searchText: string = "") {
    void this.$router.push(`/m/class/search/${searchText}`);
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

    const rowMapper = (e: List$) => {
      if (e.courseAppendices) {
        e.courseAppendices.forEach((c) => {
          e.cover = FileRootUrl + "/" + c.path;
        });
      }

      if (e.coursePrices) {
        e.discountPrice = convertDiscountPrice(e);
        e.price = convertPrice(e);
      }

      e.classDate = `${formatDate(e.openDateS)} - ${formatDate(e.openDateE)}`;
    };

    this.course1Rows = Object.assign(
      [],
      (await this.apis.feature.course.queryCourses(request)).data.records
    ) as Array<List$>;
    this.course1Rows.forEach(rowMapper);

    this.course2Rows = Object.assign(
      [],
      (await this.apis.feature.course.queryCourses(request)).data.records
    ) as Array<List$>;
    this.course2Rows.forEach(rowMapper);

    this.course3Rows = Object.assign(
      [],
      (await this.apis.feature.course.queryCourses(request)).data.records
    ) as Array<List$>;
    this.course3Rows.forEach(rowMapper);
  }

  convertPrice(e: List$) {
    return convertPrice(e);
  }

  convertDiscountPrice(e: List$) {
    return convertDiscountPrice(e);
  }

  gotoTrackingItem() {
    void this.$router.push("/m/tracking-item");
  }
  gotoShoppingCart() {
    void this.$router.push("/m/shopping-cart");
  }
}
</script>

<style lang="scss" scoped>
@import "../../css/quasar.variables.scss";
</style>
