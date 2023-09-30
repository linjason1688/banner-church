<template>
  <c-select
    v-bind="$attrs"
    :options="options"
    option-label="text"
    option-value="value"
    map-options
    @filter="filterItemAsync"
    :hint="hint"
    clearable
  >
    <template v-slot:option="scope">
      <q-item v-bind="scope.itemProps">
        <q-item-section avatar>
          <q-icon name="corporate_fare" />
        </q-item-section>
        <q-item-section>
          <q-item-label>{{ scope.opt.text }}</q-item-label>
          <q-item-label caption>{{ scope.opt.description }}</q-item-label>
        </q-item-section>
      </q-item>
    </template>
  </c-select>
</template>

<script lang="ts">
// Component
/* eslint-disable */
import Enumerable from "linq";
/* eslint-enable */
import { debounce } from "typescript-debounce-decorator";
import { Options, Vue } from "vue-class-component";
import { Prop } from "vue-property-decorator";

@Options({})
export default class OrganizationSelect extends Vue {
  @Prop({ type: String, default: () => "" })
  deptId!: string;

  @Prop({ type: String, default: () => "" })
  bindingValue!: string;

  lastKeyword = "";

  hint = "";

  items: { id: number; name: string; description: string }[] = [];

  get options() {
    return this.items.map((it) => {
      return Object.assign(
        {
          //
          value: `${it.id}`,
          text: `${it.name}(${it.id})`,
          description: `${it.description}`,
        },
        it
      );
    });
  }

  async mounted() {
    //
    //
    if (!this.bindingValue) {
      return;
    }

    await this.filterItemAsync(
      this.bindingValue,
      // eslint-disable-next-line @typescript-eslint/ban-types
      (executor: Function) => {
        if (executor) {
          executor();
        }
      },
      () => {
        //
      },
      this.bindingValue
    );

    this.$emit("update:modelValue", this.options[0]);
  }

  @debounce(500)
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  async filterItemAsync(val: string, update: CallableFunction, abort: CallableFunction, bindingValue: string) {
    if (!val || this.lastKeyword === val || val.length < 3) {
      update(() => {
        //
      });
      return;
    }

    // TODO: ap call here
    const res = await Promise.resolve({
      data: [
        //
        { id: 0, name: "text", description: "xxx" },
      ],
    });

    this.hint = res.data.length === 0 ? "查無資料" : "";

    update(() => {
      this.items = res.data;
      this.lastKeyword = val;
    });
  }
}
</script>
