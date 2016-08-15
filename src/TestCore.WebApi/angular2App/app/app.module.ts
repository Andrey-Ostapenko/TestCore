
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { Configuration } from "./app.constants";
import { routing } from "./app.routes";
import { HttpModule, JsonpModule } from "@angular/http";

import { provideRouter, RouterConfig } from "@angular/router";
import { UserComponent } from "./user/user.component";
import { UserService } from "./services/userService";

@NgModule({
    imports: [
        BrowserModule,
        CommonModule,
        FormsModule,
        routing,
        HttpModule,
        JsonpModule
    ],
    declarations: [
        AppComponent,
        UserComponent
    ],
    providers: [
        UserService,
        Configuration
    ],
    bootstrap: [AppComponent],
})
export class AppModule {
}