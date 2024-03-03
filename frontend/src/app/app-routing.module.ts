import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guards/auth.guard';
import { NotFoundComponent } from '@shared/components/not-found/not-found.component';
import { UnauthorizedComponent } from '@shared/components/unauthorized/unauthorized.component';

const routes: Routes = [
    {
        path: 'auth',
        loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
    },
    {
        path: '',
        pathMatch: 'prefix',
        loadChildren: () => import('./modules/main/main.module').then((m) => m.MainModule),
    },
    {
      path: 'profile',
      pathMatch: 'prefix',
      loadChildren: () => import('./modules/profile/profile.module').then((m) => m.ProfileModule),
      canActivate: [AuthGuard],
    },
    {
        path: 'unauthorized',
        component: UnauthorizedComponent,
    },
    {
        path: '**',
        component: NotFoundComponent,
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
