<template>
  <q-page class="q-pa-lg">
    <div class="row">
      <div class="col-12">
        <c-subtitle title="櫃檯收費 - 確認付款"></c-subtitle>
      </div>
    </div>
    <c-form-card :rounded="true">
      <div class="row justify-evenly">
        <div class="col-12 col-md-5">
          <div class="q-pa-lg q-gutter-md">
            <div>
              <div class="c-content-body c-gray-500">訂購人</div>
              <div class="c-content-body c-text-color-100">{{ form.userEmail }}</div>
            </div>
            <div>
              <div class="c-content-body c-gray-500">訂購項目</div>
              <div class="c-content-body c-text-color-100">
                <div class="row justify-between">
                  <span>【線上 - E1生命更新營】 實現 幸福夢想 {{ form.name }} </span>
                  <span>NT$3000</span>
                </div>
              </div>
            </div>
            <q-separator />
            <div class="row justify-end">
              <span class="c-content-subtitle c-gray-700">本次訂單金額：</span>
              <span class="c-content-subtitle c-text-color-100">NT$ {{ form.totalAmount }} </span>
            </div>
          </div>
        </div>
        <q-separator vertical />
        <div class="col-12 col-md-5 column justify-between">
          <div class="q-pt-lg q-px-lg q-gutter-md">
            <div>
              <div class="c-content-body c-gray-500">輸入應收金額</div>
              <div class="c-content-body-bold c-text-color-100">實收金額</div>
              <c-input v-model="form.paymentAmount"></c-input>
            </div>
          </div>
          <div class="q-pb-lg q-px-lg row justify-end q-gutter-sm">
            <c-btn type="submit" @click="submitAsync">送出</c-btn>
            <c-btn-history-back :outlined="true"></c-btn-history-back>
          </div>
        </div>
      </div>
    </c-form-card>

    <div class="row">
      <div class="col-12">
        <c-subtitle title="訂購人資料"></c-subtitle>
      </div>
    </div>
    <c-form-card :rounded="true" :filled="true" :outlined="false">
      <div class="row justify-evenly">
        <div class="col-12 col-md-5 q-pa-lg">
          <c-row>
            <div class="col-12">
              <c-column label="通信地址">
                <c-input readonly dense v-model="form.userAddress"></c-input>
              </c-column>
            </div>
          </c-row>
          <c-row>
            <div class="col-12">
              <c-column label="行動電話">
                <c-input readonly dense v-model="form.userCellPhone"></c-input>
              </c-column>
            </div>
          </c-row>
          <c-row>
            <div class="col-12">
              <c-column label="聯絡電話">
                <c-input readonly dense v-model="form.userPhone"></c-input>
              </c-column>
            </div>
          </c-row>
          <c-row>
            <div class="col-12">
              <c-column label="Email">
                <c-input readonly dense v-model="form.userEmail"></c-input>
              </c-column>
            </div>
          </c-row>
        </div>
        <div class="col-12 col-md-5"></div>
      </div>
    </c-form-card>

    <div class="row">
      <div class="col-12">
        <c-subtitle title="訂單詳情"></c-subtitle>
      </div>
    </div>
    <div v-for="index of 2" :key="index">
      <c-form-card :rounded="true" :filled="true" :outlined="false">
        <div class="row justify-evenly">
          <div class="col-12 col-md-5 q-pa-lg q-gutter-md">
            <div class="q-gutter-y-sm">
              <div class="c-content-title c-text-color-100">課程名稱</div>
              <div class="c-content-body c-text-color-100">【線上 - E1生命更新營】  實現 幸福夢想</div>
            </div>
            <div class="q-gutter-y-sm">
              <div class="c-content-title c-text-color-100">開課堂點</div>
              <div class="c-content-body c-text-color-100">台中旌旗教會</div>
            </div>
            <div class="q-gutter-y-sm">
              <div class="c-content-title c-text-color-100">課程日期與地點</div>
              <div>
                <div class="row c-content-body c-text-color-100">
                  <div class="col-auto">日期：</div>
                  <div class="col q-gutter-xs">
                    <div>2022/02/19 (六) 9:00-18:00</div>
                    <div>2022/02/19 (六) 9:00-18:00</div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-auto">地點：</div>
                  <div class="col q-gutter-xs">
                    <div>form.place</div>
                  </div>
                </div>
              </div>
            </div>
            <div class="q-gutter-y-sm">
              <div class="c-content-title c-text-color-100">特殊需求</div>
              <div class="c-content-body c-text-color-100 q-gutter-sm">
                <span>素食</span>
                <span>夫妻同班 (配偶：XXX)</span>
              </div>

            </div>
          </div>
          <div class="col-12 col-md-5"></div>
        </div>
      </c-form-card>
    </div>
  </q-page>
</template>

<script lang="ts">
import { Options } from "vue-class-component";
import { DetailComponentBase } from "src/components/DetailComponentBase";
import { WithLoading } from "src/util/TsDecorators";
import {
  CreateShoppingOrderCommand,
  DeleteShoppingOrderCommand,
  ShoppingOrderView,
  UpdateShoppingOrderCommand
} from "src/api/feature";
import FormOrganization from "components/business/FormOrganization.vue";
import {OrderDetailStatus} from "src/data/constants/OrderDetailStatus";

interface Detail$ extends ShoppingOrderView {
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
  },
})
export default class Detail extends DetailComponentBase {

  form: Detail$ = <Detail$>{};

  get isUpdateMode() {
    return !!this.id;
  }

  get tipName() {
    return this.form.id;
  }

  get deleteKey() {
    return this.id as unknown as number;
  }

  async mounted() {
    if (this.isUpdateMode) {
      const res = await this.apis.feature.shoppingOrder.getShoppingOrder(this.deleteKey);
      Object.assign(this.form, res.data);
    }
  }

  @WithLoading()
  async submitAsync() {
    await this.updateAsync();
  }

  async createAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign({}, this.form) as unknown as CreateShoppingOrderCommand;
      await this.apis.feature.shoppingOrder.createShoppingOrder(request);
      this.$router.go(-1);
    });
  }

  get postFormState() {
    return {
      orderPayStatus: OrderDetailStatus.PaidComplete,
      paymentTransactionDate: new Date(),
    }
  }

  get preFormState() {
    return {}
  }

  async updateAsync() {
    await this.executeAsync(async () => {
      const request = Object.assign(this.preFormState, this.form, this.postFormState);
      await this.apis.feature.shoppingOrder.putShoppingOrder(request as unknown as UpdateShoppingOrderCommand);
      this.$router.go(-1);
      this.showSuccessNotify(`繳費成功 定單編號${this.tipName}`);
    });
  }

  async removeAsync() {
    const confirm = await this.showConfirmDialogAsync(`是否要刪除 ${this.tipName}？`, "請再次確認");

    if (!confirm) {
      return;
    }

    const request = { id: this.deleteKey };
    await this.apis.feature.shoppingOrder.deleteShoppingOrder(request as unknown as DeleteShoppingOrderCommand);
    this.$router.go(-1);
    this.showSuccessNotify(`已刪除 ${this.tipName}`);
  }
}
</script>

<style lang="scss" scoped>

</style>
