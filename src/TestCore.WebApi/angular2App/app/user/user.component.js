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
var common_1 = require("@angular/common");
var userService_1 = require("../services/userService");
var UserComponent = (function () {
    function UserComponent(userService) {
        this.userService = userService;
        this.message = "Hello from UserComponent constructor";
    }
    UserComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.userService
            .getAll()
            .subscribe(function (data) { return _this.values = data; }, function (error) { return console.log(error); }, function () { return console.log("Get all complete"); });
    };
    UserComponent.prototype.createUser = function () {
        var userName = prompt("Enter Username");
        this.userService.add({ userName: userName })
            .subscribe(function (data) { return console.log(data); }, function (error) { return console.log(error); }, function () { return console.log("Add user complete"); });
        location.reload();
    };
    UserComponent.prototype.editUser = function (id, userName) {
        userName = prompt("Enter Username", userName);
        this.userService.update({ id: id, userName: userName })
            .subscribe(function (data) { return console.log(data); }, function (error) { return console.log(error); }, function () { return console.log("Update user complete"); });
        location.reload();
    };
    UserComponent.prototype.deleteUser = function (id) {
        this.userService.delete(id)
            .subscribe(function (data) { return console.log(data); }, function (error) { return console.log(error); }, function () { return console.log("Delete user complete"); });
        location.reload();
    };
    UserComponent = __decorate([
        core_1.Component({
            selector: "usercomponent",
            template: require("./user.component.html"),
            directives: [common_1.CORE_DIRECTIVES],
            providers: [userService_1.UserService]
        }), 
        __metadata('design:paramtypes', [userService_1.UserService])
    ], UserComponent);
    return UserComponent;
}());
exports.UserComponent = UserComponent;
//# sourceMappingURL=user.component.js.map