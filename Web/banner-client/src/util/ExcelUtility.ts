import Enumerable from "linq";
import { FileUtility } from "src/util/FileUtility";
import xlsx from "xlsx";

export interface XlsxOptions {
  sheetName?: string;
  columnWidths?: number[];
}

/**
 *
 * @param filename
 * @param columnNames
 * @param data
 * @param sheetName
 */
function exportFile(
  filename: string,
  heading: Array<{ key: string; value: unknown }>,
  columnNames: string[],
  data: string[][],
  options?: XlsxOptions
) {
  const opt: XlsxOptions = Object.assign(
    {
      sheetName: "sheet",
      columnWidths: [],
    },
    options || {}
  );

  let rows: string[][] = [];

  if (heading.length > 0) {
    heading.map((kv) => [kv.key, kv.value] as string[]).forEach((it) => rows.push(it));
    rows.push(["-----"]);
  }

  rows = rows.concat([columnNames]).concat(data);

  const workbook = xlsx.utils.book_new();
  const worksheet = xlsx.utils.aoa_to_sheet(rows);

  if (opt.columnWidths && opt.columnWidths.length > 0) {
    worksheet["!cols"] = opt.columnWidths.map((wd) => ({ wch: wd }));
  }

  /* add worksheet to workbook */
  xlsx.utils.book_append_sheet(workbook, worksheet, opt.sheetName);

  /* write workbook */
  xlsx.writeFile(workbook, filename);
}

/**
 * 第一欄為 欄位名稱
 * @param file
 */
async function readExcelAsJson(file: File, sheetIndex = 0) {
  const data = await FileUtility.readFileAsUnit8ArrayAsync(file);

  const workbook = xlsx.read(data, { type: "array" });
  const sheetName = workbook.SheetNames[sheetIndex];
  const sheet = workbook.Sheets[sheetName];

  const rows = xlsx.utils.sheet_to_json<string[]>(sheet, { header: 1 });

  const columnNames = rows[0];

  // 將 array 資料轉成 key-value map array
  const json = Enumerable.from(rows)
    .skip(1)
    .select((row) => {
      return columnNames.reduce((acc, it, idx) => {
        acc[it] = row[idx];
        return acc;
      }, {} as { [key: string]: string });
    })
    .toArray();

  return json;
}

/**
 * excel 讀取為 jagged array
 * P.S. 第一個 array 可能為欄位名稱
 * @param file
 */
async function readExcelAsJaggedArray(file: File, sheetIndex = 0): Promise<string[][]> {
  const data = await FileUtility.readFileAsUnit8ArrayAsync(file);

  const workbook = xlsx.read(data, { type: "array" });
  const sheetName = workbook.SheetNames[sheetIndex];
  const sheet = workbook.Sheets[sheetName];

  const rows = xlsx.utils.sheet_to_json<string[]>(sheet, { header: 1 });

  return rows;
}

export const ExcelUtility = {
  exportFile,
  readExcelAsJson,
  readExcelAsJaggedArray,
};
