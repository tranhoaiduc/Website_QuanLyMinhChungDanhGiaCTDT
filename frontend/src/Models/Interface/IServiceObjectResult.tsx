import { IServiceResult } from "./IServiceResult";

export interface IServiceObjectResult<T> extends IServiceResult {
  Object: T;
}
