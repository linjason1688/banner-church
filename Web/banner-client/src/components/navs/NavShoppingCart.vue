<template>
  <div class="row items-center q-mt-md q-mb-lg">
    <div class="col-12 col-sm-5">
      <q-breadcrumbs class="c-hyper-link" separator="〉">
        <q-breadcrumbs-el to="/m/class/index" label="課程選購首頁" />
        <q-breadcrumbs-el :label="title" />
      </q-breadcrumbs>
    </div>
    <div class="col-12 col-sm-7 row items-end justify-end">
      <q-btn class="q-px-md q-py-sm" size="sm" flat>
        <q-icon left name="star" />
        <div class="app-class-cart-btn" @click="gotoTrackingItem">追蹤清單</div>
      </q-btn>
      <q-btn class="q-px-md q-py-sm" size="sm" flat>
        <q-icon left name="shopping_cart" />
        <div class="app-class-cart-btn" @click="gotoShoppingCart">購物車</div>
      </q-btn>
      <q-btn class="q-px-md q-py-sm" size="sm" flat>
        <q-icon left name="list" />
        <div class="app-class-cart-btn" @click="gotoOrder">訂單管理</div>
      </q-btn>
    </div>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components";
import { Prop } from "vue-property-decorator";

export default class NavShoppingCart extends ComponentBase {

  @Prop({ type: String })
  title!: string;

  async mounted() {
    //
  }

  gotoTrackingItem() {
    void this.$router.push("/m/tracking-item");
  }

  gotoShoppingCart() {
    void this.$router.push("/m/shopping-cart/index");
  }

  gotoOrder() {
    //
  }
}
</script>

<style lang="scss" scoped>
@import '../../css/quasar.variables.scss';

</style>
