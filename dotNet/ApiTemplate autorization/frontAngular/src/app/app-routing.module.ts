import { NgModule } from '@angular/core';

import { RouterModule, Routes, PreloadAllModules, NoPreloading, ExtraOptions } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SecuredComponent } from './secured/secured.component';
import { SignInComponent } from './signin/signin.component';
import { SignOutComponent } from './signout/signout.component';
import { UserComponent } from './user/user.component';
import { AuthGuard } from './auth/auth-guard';


const routes: Routes = [
  {
      path: '',
      redirectTo: 'signin',
      pathMatch: 'full'
  },
  {
      path: 'user',
      component: UserComponent,
      pathMatch: 'full'
  },
  {
      path: 'signin',
      component: SignInComponent,
      pathMatch: 'full'
  },
  {
      path: 'signout',
      component: SignOutComponent,
      pathMatch: 'full'
  },
  {
      path: 'secured',
      component: SecuredComponent,
      pathMatch: 'full',
      canActivate: [AuthGuard]
  }
];

@NgModule({
  // imports: [RouterModule.forRoot(routes)],
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
