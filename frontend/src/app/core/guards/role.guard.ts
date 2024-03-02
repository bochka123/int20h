import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { Role } from '@shared/data/roles';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const roles = next.data?.['roles'] as Role[];

    if (roles && roles.length > 0) {
        if (this.authService.hasAnyRole(roles)) {
          return true;
        }
    }

    this.router.navigate(['/unauthorized']);
    return false;
  }
}
