/* eslint-disable no-unused-vars */
export {};
// // for all

declare global {
  interface Navigator {
    msSaveBlob?: (blob: Blob, defaultName?: string) => boolean;
  }
}
