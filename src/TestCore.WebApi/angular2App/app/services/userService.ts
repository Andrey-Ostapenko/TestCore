import { Injectable } from "@angular/core";
import { Http, Response, Headers } from "@angular/http";
import "rxjs/add/operator/map"
import { Observable } from "rxjs/Observable";
import { Configuration } from "../app.constants";

@Injectable()
export class UserService {

    private actionUrl: string;
    private headers: Headers;

    constructor(private _http: Http, private _configuration: Configuration) {

        this.actionUrl = _configuration.Server + "api/user/";

        this.headers = new Headers();
        this.headers.append("Content-Type", "application/json");
        this.headers.append("Accept", "application/json");
    }

    GetAll = (): Observable<any> => {
        return this._http.get(this.actionUrl).map((response: Response) => <any>response.json());
    };
    GetSingle = (id: number): Observable<Response> => {
        return this._http.get(this.actionUrl + id).map(res => res.json());
    };
    Add = (itemName: string): Observable<Response> => {
        var toAdd = JSON.stringify({ ItemName: itemName });

        return this._http.post(this.actionUrl, toAdd, { headers: this.headers }).map(res => res.json());
    };
    Update = (id: number, itemToUpdate: any): Observable<Response> => {
        return this._http
            .put(this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: this.headers })
            .map(res => res.json());
    };
    Delete = (id: number): Observable<Response> => {
        return this._http.delete(this.actionUrl + id);
    };
}