import { HashMap } from "src/data/dto";
import { ObjectUtility } from "src/util";

export class EnumWrapper<T> {
  constructor(public value: T, public displayMappings: HashMap<string>) {
    Object.assign(displayMappings, {
      None: "未指定",
      Default: "未指定",
    });
  }

  get options() {
    const options = ObjectUtility.getKeyValues<string>(this.value).map((kv) => {
      return {
        key: kv.key,
        value: kv.value,
        text: this.mappingToDisplayText(kv.key),
      };
    });
    return options;
  }

  mappingToDisplayText(key: string) {
    return this.displayMappings[key] || `${key} (NotMapped)`;
  }
}
