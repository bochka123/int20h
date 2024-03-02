import { Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';
import { HttpService } from './http.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { IAccessToken, IUser } from '../../models/IUser';
import { Role } from '@shared/data/roles';
import { IResponse, IResponseT, ResponseStatus } from 'src/app/models/IResponse';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    controllerUrl: string;

    constructor(
        private httpService: HttpService,
        private jwtHelper: JwtHelperService,
    ) {
        this.controllerUrl = 'api/auth';
    }

    public getUserId(): string {
        const token = localStorage.getItem('accessToken');

        if (token && !this.jwtHelper.isTokenExpired(token)) {
            const decodedToken = this.jwtHelper.decodeToken(token);
            if (decodedToken && decodedToken.id) {
                return decodedToken.id;
            }
        }

        return '';
    }

    public getUserEmail(): string {
        const token = localStorage.getItem('accessToken');

        if (token && !this.jwtHelper.isTokenExpired(token)) {
            const decodedToken = this.jwtHelper.decodeToken(token);
            if (decodedToken && decodedToken.email) {
                return decodedToken.email;
            }
        }

        return '';
    }

    public getUserRole(): Role {
        const token = localStorage.getItem('accessToken');

        if (token && !this.jwtHelper.isTokenExpired(token)) {
          const decodedToken = this.jwtHelper.decodeToken(token);
          if (decodedToken && decodedToken.role) {
            return decodedToken.role as Role;
          }
        }

        return Role.none;
      }

    public isAuthenticated(): Observable<boolean> {
        const token = localStorage.getItem('accessToken');

        if(!token) return of(false);

        if (this.jwtHelper.isTokenExpired(token)) {
            return this.checkAuthentication();
        }
        return of(true);
    }

    hasRole(role: Role): boolean {
        return this.getUserRole() == role;
    }

    hasAnyRole(roles: Role[]): boolean {
        const userRoles = [Role.admin, Role.teacher, Role.student];
        return roles.some(role => userRoles.includes(role));
    }

    private checkAuthentication(): Observable<boolean> {
        return this.refresh().pipe(
            map((res) => {
                if ((res as IResponseT<IAccessToken>).status == ResponseStatus.Error) {
                    this.logout();
                    return false;
                }
                localStorage.setItem('accessToken', (res as IResponseT<IAccessToken>).value?.accessToken || '');
                return true;
            }),
        );
    }

    signUp(user: IUser) {
        return this.httpService.post(`${this.controllerUrl}/sign-up`, user);
    }

    signIn(user: IUser) {
        return this.httpService.post(`${this.controllerUrl}/sign-in`, user);
    }

    refresh() {
        return this.httpService.post(`${this.controllerUrl}/refresh`, null);
    }

    logout() {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('user');
    }
}
