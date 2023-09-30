import { MyDateTime } from "src/util/DateUtility";

interface FormatNumberOptions {
  value: number | string;
  targetDigits?: number;
  unit?: string;
  factor?: number;
}

export interface IFormatters {
  /**
   *
   * @param options
   */
  formatNumber(options: FormatNumberOptions): string;
  /**
   *
   * @param value
   * @param targetDigits
   * @param factor
   */
  formatPercentage(value: number | string, targetDigits: number, factor: number): string;
  /**
   *
   * @param value
   */
  formatBoolean(value: boolean): string;
  /**
   *
   * @param value
   * @param format
   */
  formatDate(value: Date, format?: string): string;
  /**
   *
   * @param value
   * @param format
   */
  formatDateTime(value: Date, format?: string): string;
  /**
   *
   * @param value
   * @param format
   */
  formatTime(value: Date, format?: string): string;
  /**
   *
   * @param value
   */
  formatBooleanAsYN(value: boolean): string;
  /**
   *
   * @param value
   * @param separator
   */
  toChineseDate(value: Date, separator?: string): string;

  /**
   *
   * @param ms
   */
  toTime(ms: number): string;

  /**
   * 將毫秒轉換成一個時段
   * @param ms 毫秒
   */
  millisecondToDayTime(ms: number): string;

  /**
   *
   * @param data
   * @param maxLength
   * @param paddingChar
   */
  padLeft(data: string | number, maxLength: number, paddingChar?: string): string;

  /**
   *
   * @param data
   */
  toJson(data: unknown): string;
}

export function formatNumber({ value, targetDigits = 0, unit = "", factor = 0 }: FormatNumberOptions) {
  // keep 原始 NaN
  if (value === "NaN") {
    return value;
  }

  value = Number(value);

  // parse 後 nan 者以空白顯示
  if (isNaN(value)) {
    return "-";
  }

  if (factor) {
    value = value * Number(factor);
  }

  const currencyFormatter = new Intl.NumberFormat("en-US", {
    maximumFractionDigits: targetDigits,
    minimumFractionDigits: targetDigits,
  });

  const fmtValue = currencyFormatter.format(value);
  if (!unit) {
    return fmtValue;
  }
  return `${fmtValue} ${unit}`;
}

export function formatPercentage(value: number | string, targetDigits: number, factor: number) {
  return formatNumber({ value, targetDigits, unit: "%", factor });
}

export function formatBoolean(value: boolean) {
  return value ? "Y" : "N";
}

/**
 *
 * @param value
 * @param format "YYYY-MM-DD"
 */
export function formatDate(value: Date | string | null | undefined, format: string = "YYYY-MM-DD") {
  if (!value) {
    return "";
  }
  return new MyDateTime(value).format(format);
}

/**
 *
 * @param value
 * @param format "YYYY-MM-DD HH:mm:ss"
 */
export function formatDateTime(value: Date | string | null | undefined, format: string = "YYYY-MM-DD HH:mm:ss") {
  if (!value) {
    return "";
  }

  return new MyDateTime(value).format(format);
}

/**
 *
 * @param value
 * @param format "HH:mm:ss"
 */
export function formatTime(value: Date | string | null | undefined, format: string = "HH:mm:ss") {
  if (!value) {
    return "";
  }
  return new MyDateTime(value).format(format);
}

/**
 *
 * @param value
 */
export function formatBooleanAsYN(value: boolean) {
  return value ? "Y" : "N";
}

/**
 *
 * @param value
 * @param format "YYYY-MM-DD"
 */
export function toChineseDate(value: Date | string | null | undefined, separator = "/") {
  return new MyDateTime(value).fromTwDate(separator);
}

export function toTime(ms: number): string {
  if (0 >= ms) {
    return "00:00:00";
  }

  if (!ms) {
    return "";
  }

  const time = new Date(ms);

  return [
    //
    time.getUTCHours(),
    time.getUTCMinutes(),
    time.getUTCSeconds(),
  ]
    .map((v) => v.toString().padStart(2, "0"))
    .join(":");
}

const daySeconds = 86400;

/**
 * 將毫秒轉換成一個時段
 * @param ms 毫秒
 */
export function millisecondToDayTime(ms: number): string {
  if (0 >= ms) {
    return "000 days 00:00:00";
  }

  if (!ms) {
    return "";
  }

  const totalSeconds = ms / 1000;

  const days = Math.floor(totalSeconds / daySeconds);

  const remainSeconds = totalSeconds % daySeconds;

  const result = `${days.toString().padStart(3, "0")} days ${toTime(remainSeconds * 1000)}`;

  return result;
}

export function padLeft(data: string | number, maxLength: number, paddingChar = "0"): string {
  const val = (data || "").toString();

  return val.padStart(maxLength, paddingChar);
}

export function toJson(data: unknown): string {
  if (null === data || undefined === data) {
    return "";
  }

  return JSON.stringify(data);
}
