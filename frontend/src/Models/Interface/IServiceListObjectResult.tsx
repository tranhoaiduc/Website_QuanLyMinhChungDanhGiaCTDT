import { IServiceResult } from "./IServiceResult";

export interface IServiceListObjectResult<T> extends IServiceResult {
  ListObject: T[];
}
