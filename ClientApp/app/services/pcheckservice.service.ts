import { Injectable }     from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/observable/throw';

import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map'

import { PalinItem } from '../models/palinItem';
import { RespMsg } from '../models/respmsg';

@Injectable()
export class PCheckService {
    private baseUrl = "api/palindrome";  // URL to web api

    constructor (private http: Http) { }

    Check(inputStr: string, insert: boolean = false): Observable<RespMsg>  {
        console.log('PCheckService :: Check');
        let url = this.baseUrl + "/check";
        let body = JSON.stringify({ inputStr, insert });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
    
        return this.http.post(url, body, options)
                        .map(this.extractData)
                        .catch(this.handleError);
    }

    getAll(): Observable<RespMsg> {
        console.log('PCheckService :: getAll');
        let url = this.baseUrl + "/getall";
        return this.http.get(url)
                      .map(this.extractData)
                      .catch(this.handleError);
    }

    private extractData(res: Response) {
        console.log('extractData :: res', res);
        if (res.status < 200 || res.status >= 300) {
            throw new Error('Bad response status: ' + res.status);
        }
        let body = res.json();
        return body || { };
    }
  
    private handleError (error: any) {
        let errMsg = error.message || 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}