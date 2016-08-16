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

        this.actionUrl = _configuration.server + "api/user/";

        this.headers = new Headers();
        this.headers.append("Content-Type", "application/json");
        this.headers.append("Accept", "application/json");
    }

    getAll = (): Observable<any> => {
        return this._http.get(this.actionUrl).map((response: Response) => <any>response.json());
    };
    getSingle = (id: string): Observable<Response> => {
        return this._http.get(this.actionUrl + id).map(res => res.json());
    };
    add = (userModel: any): Observable<Response> => {
        var toAdd = JSON.stringify(userModel);

        return this._http.post(this.actionUrl, toAdd, { headers: this.headers }).map(res => res.json());
    };
    update = (userModel: any): Observable<Response> => {
        return this._http
            .put(this.actionUrl, JSON.stringify(userModel), { headers: this.headers })
            .map(res => res.json());
    };
    delete = (id: string): Observable<Response> => {
        return this._http.delete(this.actionUrl + id);
    };
}