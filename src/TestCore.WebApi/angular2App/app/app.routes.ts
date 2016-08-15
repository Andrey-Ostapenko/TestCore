import { Routes, RouterModule } from "@angular/router";

import { provideRouter, RouterConfig } from "@angular/router";

import { UserComponent } from "./user/user.component";
import { UserService } from "./services/userService";

const appRoutes: Routes = [
    { path: "", component: UserComponent },
    { path: "user", component: UserComponent }
];

export const routing = RouterModule.forRoot(appRoutes);