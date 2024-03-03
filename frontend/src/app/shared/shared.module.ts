import { NgModule } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { ErrorComponent } from './components/error/error.component';
import { ModalComponent } from './components/modal/modal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { InfoSidebar } from './components/info-sidebar/info-sidebar.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';

@NgModule({
  imports: [
    CommonModule,
    RouterLink,
    RouterLinkActive,
    MatDialogModule,
    MatIconModule,
  ],
  declarations: [HeaderComponent, ErrorComponent, ModalComponent, InfoSidebar, NotFoundComponent, UnauthorizedComponent],
  exports: [HeaderComponent, ErrorComponent, InfoSidebar, NotFoundComponent, UnauthorizedComponent],
})
export class SharedModule {}
