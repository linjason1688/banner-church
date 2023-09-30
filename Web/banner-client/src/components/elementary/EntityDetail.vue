<template>
  <div>
    <div>
      <strong>ApiHandledId：</strong>
      {{ value.handledId }}
    </div>
    <div>
      <strong>建立日期：</strong>
      {{ createdAt }}
    </div>
    <div>
      <strong>建立人員：</strong>
      {{ value.userCreate }}
    </div>
    <div>
      <strong>最後修改日期：</strong>
      {{ modifiedAt }}
    </div>
    <div>
      <strong>最後修改人員：</strong>
      {{ value.userUpdate }}
    </div>
  </div>
</template>

<script lang="ts">
// Component
import { IEntityBase } from "src/data/dto";
import { formatDateTime } from "src/util";
import { Options } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { ElementaryBase } from "./ElementaryBase";

@Options({})
export default class EntityDetail extends ElementaryBase {
  @Prop({ default: () => ({}) })
  private value!: IEntityBase;

  get createdAt() {
    return formatDateTime(this.value.dateCreate);
  }

  get modifiedAt() {
    if (!this.value.dateUpdate) {
      return "";
    }
    return formatDateTime(this.value.dateUpdate);
  }
}
</script>
