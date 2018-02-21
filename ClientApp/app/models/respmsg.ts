export interface IRespMsg
{
    status: boolean;
    errMsg: string;
    data: any;
}

export class RespMsg
{
    public status: boolean = false;
    public errMsg: string = "";
    public data: any;

    contructor(val: RespMsg) {
        this.status = val.status;
        this.errMsg = val.errMsg;
        this.data = val.data;    
    }
}