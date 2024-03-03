import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MainComponent } from './main.component';
import { MainContentComponent } from './main-content/main-content.component';
import {AuthGuard} from "@core/guards/auth.guard";

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
        component: MainContentComponent,
      },
      {
        path: 'students',
        pathMatch: 'prefix',
        loadChildren: () =>
          import('../students/students.module').then(
            (m) => m.StudentsModule
          ),
      },
      {
        path: 'groups',
        pathMatch: 'prefix',
        loadChildren: () => import('../groups/groups.module').then((m) => m.GroupsModule),
        canActivate: [AuthGuard],
      },
      {
        path: 'tests',
        pathMatch: 'prefix',
        loadChildren: () => import('../tests/tests.module').then((m) => m.TestsModule),
        canActivate: [AuthGuard],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MainRoutingModule {}
