<template>
  <c-column label="信仰狀態及受洗資料" required>
    <q-field v-model="syncedBaptizedType" borderless :rules="[(val) => !!val || '請選擇受洗狀態']">
      <div class="col-12 column">
        <q-radio v-model="syncedBaptizedType" val="0" label="已受洗" dense class="q-py-sm c-content-body c-text-color-100" />
        <q-card v-if="syncedBaptizedType === '0'" flat bordered class="q-pa-md q-ml-lg q-mr-md c-dotted-border">
          <div class="row">
            <div class="col-12">
              <c-column label="受洗時間">
                <c-date-picker v-model="syncedBaptizeday" min="1900-01-01" role="n"></c-date-picker>
              </c-column>
              <c-column label="曾經待過的教會">
                <q-field v-model="syncedChurchType" borderless bottom-slots :rules="[(val) => !!val || '請選擇教會']"
                  class="q-px-md">
                  <div class="col-12 column">
                    <c-column label="1.旌旗教會" dense class="q-py-sm q-mb-sm c-content-body c-text-color-100">
                      <c-form-organization class="q-py-sm" v-model="syncedChurchName" role="o"
                        :rules="[(val) => !!val || '請選擇教會']"></c-form-organization>
                    </c-column>
                    <c-column label="2.其他教會" dense class="q-py-sm c-content-body c-text-color-100">
                      <c-input role="edit2" v-model="syncedAnotherChurchName" placeholder="輸入其他教會"
                        :rules="[(val) => !!val || '請輸入其他教會']" />
                    </c-column>
                    <c-column class="q-mt-lg" label="教會施洗者（若為旌旗教會者">
                      <c-input role="edit2" v-model="syncedBaptizer" />
                    </c-column>
                  </div>
                </q-field>
              </c-column>
            </div>
          </div>
        </q-card>
        <q-radio v-model="syncedBaptizedType" val="1" label="未受洗" dense class="q-py-sm c-content-body c-text-color-100" />
        <q-radio v-model="syncedBaptizedType" val="2" label="其他" dense class="q-py-sm c-content-body c-text-color-100" />
        <div class="q-mr-md">
          <c-input v-if="syncedBaptizedType === '2'" placeholder="填入其他狀態" v-model="syncedOtherComment"
            :rules="[(val) => !!val || '請填入其他狀態']"></c-input>
        </div>
      </div>
    </q-field>
  </c-column>
</template>

<script lang="ts">
// Component
import { Options } from "vue-class-component";
import { FormGroupBase } from "./FormGroupBase";
import { PropSync } from "vue-property-decorator";
import FormOrganization2 from "components/business/FormOrganization2.vue";

@Options({
  components: {
    "c-form-organization": FormOrganization2,
  },
})
export default class FormGroupBaptized extends FormGroupBase {
  @PropSync("baptizedType", { type: String }) syncedBaptizedType!: string;

  @PropSync("baptizeday", { type: String }) syncedBaptizeday!: string;

  @PropSync("churchType", { type: String }) syncedChurchType!: string;

  @PropSync("churchName", { type: String }) syncedChurchName!: string;

  @PropSync("anotherChurchName", { type: String }) syncedAnotherChurchName!: string;

  @PropSync("baptizer", { type: String }) syncedBaptizer!: string;

  @PropSync("otherComment", { type: String }) syncedOtherComment!: string;

  created() {
    //
  }
}
</script>
