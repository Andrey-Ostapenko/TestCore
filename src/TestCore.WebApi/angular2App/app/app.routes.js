"use strict";
var router_1 = require("@angular/router");
var user_component_1 = require("./user/user.component");
var appRoutes = [
    { path: "", component: user_component_1.UserComponent },
    { path: "user", component: user_component_1.UserComponent }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routes.js.map