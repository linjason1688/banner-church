function readFileAsync(file: File): Promise<string | ArrayBuffer | null> {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.onload = (e) => {
      if (e.target) {
        resolve(e.target.result);
      } else {
        reject(new Error("read file failed"));
      }
    };
    reader.readAsArrayBuffer(file);
  });
}

function readFileAsyBinaryStringAsync(file: File): Promise<string | ArrayBuffer | null> {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.onload = (e) => {
      if (e.target) {
        resolve(e.target.result);
      } else {
        reject(new Error("read file failed"));
      }
    };
    reader.readAsBinaryString(file);
  });
}

async function readFileAsUnit8ArrayAsync(file: File) {
  const data = await readFileAsync(file);

  const array = new Uint8Array(data as ArrayBuffer);

  return array;
}

function downloadFile(filename: string, blob: Blob) {
  // special case for ie
  if (navigator.msSaveBlob) {
    navigator.msSaveBlob(blob, filename);
    return;
  }

  const url = window.URL.createObjectURL(blob);
  const a = document.createElement("a");
  a.style.display = "none";
  a.href = url;
  a.download = filename;
  document.body.appendChild(a);
  a.click();
  window.URL.revokeObjectURL(url);
  document.body.removeChild(a);
}

function downloadFileFromUrl(filename: string, url: string) {
  const a = document.createElement("a");
  a.style.display = "none";
  a.href = url;
  a.download = filename;
  document.body.appendChild(a);
  a.click();
  document.body.removeChild(a);
}

export const FileUtility = {
  readFileAsync,
  readFileAsUnit8ArrayAsync,
  readFileAsyBinaryStringAsync,
  downloadFile,
  downloadFileFromUrl,
};
