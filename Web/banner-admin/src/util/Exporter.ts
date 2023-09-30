import * as XLSX from "xlsx";
interface LooseObject {
    // eslint-disable-next-line
    [key: string]: any
}

export interface column {
    label:string
    name:string
}

export function JSONtoExcelJSON(columns: Array<column>, rows: Array<LooseObject>) {
    const newRows:LooseObject[] = [];
    rows.map(row=>{
        const newObj:LooseObject = {};
        columns.map(col=>{
            newObj[col.label] = row[col.name];
        })
        newRows.push(newObj);
    });
    return newRows
  }

export function exportExcel(fileName: string, sheetName: string, json: Array<unknown>) {
  const worksheet = XLSX.utils.json_to_sheet(json);
  const workbook = XLSX.utils.book_new();
  XLSX.utils.book_append_sheet(workbook, worksheet, sheetName);
  const buffer = XLSX.write(workbook, { type: "buffer" });
  const blob = new Blob([buffer], { type: "application/octet-stream" });
  downloadFile(blob, `${fileName}.xlsx`);
}

function downloadFile(blob: Blob, fileName: string) {
  const url = URL.createObjectURL(blob);
  const a = document.createElement("a");
  a.download = fileName;
  a.href = url;
  document.body.appendChild(a);
  a.click();
  setTimeout(() => a.remove(), 200);
}
