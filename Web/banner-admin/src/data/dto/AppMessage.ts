export enum MessageLevel {
  warning = "warning",
  error = "error",
}

export interface AppMessage {
  id: number;
  message: string;
  ocurredAt: string;
  level: MessageLevel;
}
