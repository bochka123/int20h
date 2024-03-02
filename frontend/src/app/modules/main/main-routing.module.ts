import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MainComponent } from './main.component';
import { MainContentComponent } from './main-content/main-content.component';

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
        path: 'tests',
        pathMatch: 'prefix',
        loadChildren: () =>
          import('../tests/tests.module').then(
            (m) => m.TestsModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MainRoutingModule {}
