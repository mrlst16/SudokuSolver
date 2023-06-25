export class ApiResponse<T>{
    Data: T;

    constructor(){
        this.Data = {} as T;
    }
}