import { Component } from '@angular/core';

import { PCheckService } from '../../services/pcheckservice.service'

@Component({
    selector: 'palindrome-check',
    templateUrl: './palindromecheck.component.html',
    styleUrls: ['./palindromecheck.component.css']
})
export class PalindromeCheckComponent {
    private submitted: boolean = false;
    public inputStr: string = "";

    public submitText: string = "";
    public respData:any;
    public showData: boolean = false;
    public isPalindrome: boolean = true;
    public isInvalidRequest: boolean = false;

    constructor(private pcheckService: PCheckService) {

    }

    public onSubmit() { 
        let self = this;
        this.submitted = true; 
        this.pcheckService.Check(this.inputStr, true)
                            .subscribe( resp => {
                                if( !resp.status) {
                                    self.isPalindrome = false;
                                }                             
                            }, err => {
                                self.isInvalidRequest = true;
                            });
    }

    public getAll() { 
        let self = this;
        this.submitted = true; 
        this.pcheckService.getAll()
                            .subscribe( resp => {
                                console.log("getAll resp : ", JSON.stringify(resp));
                                self.showData = true;
                                self.respData = resp.data;
                            }, err => {
                                self.isInvalidRequest = true;
                            });
    }

    public onTextChange() {
        this.isPalindrome = true;
        this.isInvalidRequest = false;
    }
}