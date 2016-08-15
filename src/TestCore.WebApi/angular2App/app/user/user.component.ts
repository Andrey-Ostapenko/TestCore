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
}