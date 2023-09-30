/* eslint-disable @typescript-eslint/no-non-null-assertion */
export interface AppConfig {
  env: string;
  version: string;
  apiUrl: string;
}

export const env: AppConfig = {
  env: process.env.env!,
  version: process.env.version!,
  apiUrl: process.env.apiUrl!,
};
