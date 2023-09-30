export class BusinessError extends Error {
  data: unknown;
  constructor(message: string, data?: unknown, stack?: string | undefined) {
    super(message);
    this.data = data;
    if (stack) {
      this.stack = stack;
    }
  }
}

export class ApiBadRequestError extends Error {
  public code: string;

  public data: unknown;

  constructor(code: string, message: string, data?: unknown) {
    super(message);
    this.code = code;
    this.data = data;
  }
}

export class ApiError extends Error {
  public code: string;

  public data: unknown;

  constructor(code: string, message: string, data?: unknown) {
    super(message);
    this.code = code;
    this.data = data;
  }
}
