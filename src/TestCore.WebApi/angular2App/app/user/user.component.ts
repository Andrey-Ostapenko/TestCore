import { Observable } from "rxjs/Observable";
import { Component, OnInit } from "@angular/core";
import { CORE_DIRECTIVES } from "@angular/common";
import { Http } from "@angular/http";
import { UserService } from "../services/userService";

@Component({
    selector: "usercomponent",
    template: require("./user.component.html"),
    directives: [CORE_DIRECTIVES],
    providers: [UserService]
})
export class UserComponent implements OnInit {

    message: string;
    values: any[];

    constructor(private userService: UserService) {
        this.message = "Hello from UserComponent constructor";
    }

    ngOnInit() {
        this.userService
            .getAll()
            .subscribe(data => this.values = data,
                error => console.log(error),
                () => console.log("Get all complete"));
    }

    createUser() {
        var userName = prompt("Enter Username");
        this.userService.add({ userName: userName })
            .subscribe(data => console.log(data),
                error => console.log(error),
                () => console.log("Add user complete"));
        location.reload();
    }

    editUser(id: string, userName: string) {
        userName = prompt("Enter Username", userName);
        this.userService.update({ id, userName })
            .subscribe(data => console.log(data),
                error => console.log(error),
                () => console.log("Update user complete"));
        location.reload();
    }

    deleteUser(id: string) {
        this.userService.delete(id)
            .subscribe(data => console.log(data),
                error => console.log(error),
                () => console.log("Delete user complete"));
        location.reload();
    }
}