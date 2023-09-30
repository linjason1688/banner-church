import dayjs, { Dayjs } from "dayjs";

class TimeSpan {
  /**
   *
   * @param milliseconds
   */
  constructor(public milliseconds: number) {}

  /***
   * float
   */
  get totalSeconds() {
    return this.milliseconds / 1000.0;
  }

  /**
   * float
   */
  get totalMinutes() {
    return this.totalSeconds / 60.0;
  }

  get totalHours() {
    return this.totalMinutes / 60.0;
  }

  get totalDays() {
    return this.totalHours / 24.0;
  }
}

export class MyDateTime {
  private date: Dayjs;

  constructor(dateTime: Date | string | null | undefined) {
    //
    this.date = dayjs(dateTime || new Date());
  }

  get Value() {
    return this.date.toDate();
  }

  get datePart() {
    const str = this.date.format("YYYY-MM-DD");
    return dayjs(str).toDate();
  }

  addSeconds(value: number) {
    this.addTimeSpan(value, "seconds");
    return this;
  }

  addMinutes(value: number) {
    this.addTimeSpan(value, "minutes");
    return this;
  }

  addHours(value: number) {
    this.addTimeSpan(value, "hours");
    return this;
  }

  addDays(value: number) {
    this.addTimeSpan(value, "days");
    return this;
  }

  addMonths(value: number) {
    this.addTimeSpan(value, "months");
    return this;
  }
  addYears(value: number) {
    this.addTimeSpan(value, "years");
    return this;
  }

  /**
   * default to :  "YYYY-MM-DD"
   * @param format  "YYYY-MM-DD"
   * @returns
   */
  format(format: string = "YYYY-MM-DD") {
    return this.date.format(format);
  }

  /**
   * default to :  "HH:mm:ss"
   * @param format  "HH:mm:ss"
   * @returns
   */
  formatTime(format: string = "HH:mm:ss") {
    return this.date.format(format);
  }

  toFullDateTime() {
    return this.date.format("YYYY-MM-DD HH:mm:ss");
  }

  /**
   *
   * @param date "099/01/01"
   * @param separator
   * @returns
   */
  fromTwDate(date: string, separator: string = "/") {
    const values = date.split(separator).map((v) => parseInt(v, 10));

    this.date = dayjs(new Date(values[0] + 1911, values[1] - 1, values[2]));
    return this;
  }

  /**
   *  this -  argument dateTime
   * @param dateTime
   * @returns
   */
  diff(dateTime: Date | string) {
    return new TimeSpan(this.date.diff(dateTime));
  }

  /**
   *
   * @param value
   * @param unit  'milliseconds' | 'seconds' | 'minutes' | 'hours' | 'days' | 'months' | 'years' | 'dates'
   */
  private addTimeSpan(value: number, unit: dayjs.ManipulateType) {
    this.date = this.date.add(value, unit);
  }
}
