import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthService } from '../Services/auth.service';
import { inject } from '@angular/core';
import { Observable, of, switchMap } from 'rxjs';

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> => {

  const router = inject(Router);
  const seguridadService = inject(AuthService);

    return of(seguridadService.estaLogueado()).pipe(
        switchMap((estaLogueado) => {
            if (!estaLogueado) {
                const redirectURL = state.url === '/sign-out' ? '' : `redirectURL=${state.url}`;
                const urlTree = router.parseUrl(`/login?${redirectURL}`);
                return of(urlTree);
            }
            return of(true);
        })
    );
};
