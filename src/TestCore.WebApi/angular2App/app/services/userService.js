"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require("rxjs/add/operator/map");
var app_constants_1 = require("../app.constants");
var UserService = (function () {
    function UserService(_http, _configuration) {
        var _this = this;
        this._http = _http;
        this._configuration = _configuration;
        this.getAll = function () {
            return _this._http.get(_this.actionUrl).map(function (response) { return response.json(); });
        };
        this.getSingle = function (id) {
            return _this._http.get(_this.actionUrl + id).map(function (res) { return res.json(); });
        };
        this.add = function (itemName) {
            var toAdd = JSON.stringify({ ItemName: itemName });
            return _this._http.post(_this.actionUrl, toAdd, { headers: _this.headers }).map(function (res) { return res.json(); });
        };
        this.update = function (itemToUpdate) {
            return _this._http
                .put(_this.actionUrl, JSON.stringify(itemToUpdate), { headers: _this.headers })
                .map(function (res) { return res.json(); });
        };
        this.delete = function (id) {
            return _this._http.delete(_this.actionUrl + id);
        };
        this.actionUrl = _configuration.Server + "api/user/";
        this.headers = new http_1.Headers();
        this.headers.append("Content-Type", "application/json");
        this.headers.append("Accept", "application/json");
    }
    UserService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, app_constants_1.Configuration])
    ], UserService);
    return UserService;
}());
exports.UserService = UserService;
//# sourceMappingURL=userService.js.map