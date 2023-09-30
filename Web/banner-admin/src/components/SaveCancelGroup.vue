<template>
  <div class="row justify-center app-savecancel-group">
    <q-btn outline rounded class="q-my-sm q-mx-md c-primary-color-500 text-bold c-btn-bold" 
            v-if="save" icon="save" label="儲存" @click="onClickSave" />
    <q-btn outline rounded class="q-my-sm q-mx-md c-error-color-600 text-bold c-btn-bold" 
            v-if="remove" icon="delete" label="刪除" @click="onClickRemove" />
    <q-btn outline rounded class="q-my-sm q-mx-md c-primary-color-500 text-bold c-btn-bold" 
            v-if="cancel" icon="cancel" label="取消" @click="onClickCancel"/>
  </div>
</template>

<script lang="ts">
import { ComponentBase } from "src/components/ComponentBase";
import { Emit, Prop } from "vue-property-decorator";

export default class SaveCancelGroup extends ComponentBase {

  // ========== props ==========
  @Prop({ type: Boolean, default: false, required: false })
  readonly save!: boolean;

  @Prop({ type: Boolean, default: false, required: false })
  readonly remove!: boolean;

  @Prop({ type: Boolean, default: false, required: false })
  readonly cancel!: boolean;

  // ========== vuex ==========

  // ========== data ==========

  // ========== computed ==========
  
  // ========== watch ==========

  // ========== refs ==========

  // ========== hook ==========
  mounted() {
    //
  }

  // ========== methods ==========

  // ========== listening ==========

  // ========== emit ==========
  @Emit("save")
  onClickSave(){
    //
  }

  @Emit("remove")
  onClickRemove(){
    //
  }

  @Emit("cancel")
  onClickCancel(){
    //
  }
}
</script>