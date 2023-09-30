import { EnumWrapper } from "src/util/EnumWrapper";

enum WeekDays {
  Monday = "Mon",
}

export const ApiEnum = {
  WeekDays: new EnumWrapper(WeekDays, {
    T: "星期一",
  }),
};
