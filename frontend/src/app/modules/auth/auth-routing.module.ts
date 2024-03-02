import { RouterModule, Routes } from '@angular/router';
import { AuthPageComponent } from './auth-page/auth-page.component';
import { NgModule } from '@angular/core';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';

const routes: Routes = [
    {
        path: '',
        component: AuthPageComponent,
        pathMatch: 'prefix',
        children: [
            {
                path: 'sign-in',
                component: SignInComponent,
                pathMatch: 'prefix',
            },
            {
                path: 'sign-up',
                component: SignUpComponent,
                pathMatch: 'prefix',
            }
        ]
    },
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AuthRoutingModule {}
