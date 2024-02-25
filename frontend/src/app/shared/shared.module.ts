import { NgModule } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { ErrorComponent } from './components/error/error.component';

@NgModule({
    imports: [CommonModule, RouterLink, RouterLinkActive],
    declarations: [HeaderComponent, ErrorComponent],
    exports: [HeaderComponent, ErrorComponent],
})
export class SharedModule {}
