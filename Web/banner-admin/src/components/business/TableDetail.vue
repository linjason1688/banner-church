<template>
    <div class="row q-gutter-sm" style="padding-left: 90px;">
        <div class="col-auto">
            <div class="c-gray-600">訂單收款紀錄</div>
            <div class="row q-gutter-xs">
                <div class="col">
                    <div class="c-text-color-100">訂單金額</div>
                    <div class="q-px-md q-py-sm c-text-color-100 c-gray-bgcolor-100">
                        {{ row.totalAmount || '　' }}
                    </div>
                </div>
                <div class="col">
                    <div class="c-text-color-100">電子收據</div>
                    <div class="q-px-md q-py-sm c-text-color-100 c-gray-bgcolor-100">
                        {{ row.actuallyAmount || '　' }}
                    </div>
                </div>
                <div class="col">
                    <div class="c-text-color-100">應收金額</div>
                    <div class="q-px-md q-py-sm c-text-color-100 c-gray-bgcolor-100">
                        {{ row.actuallyAmount || '　' }}
                    </div>
                </div>
                <div class="col">
                    <div class="c-text-color-100">收款人</div>
                    <div class="q-px-md q-py-sm c-text-color-100 c-gray-bgcolor-100">
                        {{ row.receiveUserId || '　' }}
                    </div>
                </div>
            </div>
        </div>
        <q-separator vertical />
        <div class="col-auto">
            <div class="c-gray-600">報名會友資訊</div>
            <div class="row">
                <div class="col">
                    <div class="c-text-color-100">牧養組織</div>
                    <div class="q-px-md q-py-sm c-text-color-100 c-gray-bgcolor-100">
                        {{ row.pastoralId || '　' }}
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Vue } from "vue-class-component";
import { Prop } from "vue-property-decorator";

export default class TableDetail extends Vue {
    @Prop({}) row!: any;
}
</script>

<style></style>