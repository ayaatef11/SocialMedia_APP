import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
// import {SocialAuthServiceConfig,GoogleLoginProvider} from '@abacritt/angularx-social-login';
import {provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi} from '@angular/common/http';
// import {NgxSpinnerModule } from 'ngx-spinner';
// import {ToastrModule } from 'ngx-toastr';
import {authenticationInterceptor} from '../Interceptors/Authentication/authentication.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(
    withFetch(),
    withInterceptors([authenticationInterceptor]),
    withInterceptorsFromDi()
    ),
    provideZoneChangeDetection({ eventCoalescing: true }),    
    //  AuthService,
          {
      provide: 'SocialAuthServiceConfig',
      useValue: {
      autoLogin: false,
      // providers: [
      //     {
      //       id: GoogleLoginProvider.PROVIDER_ID,
      //       provider: new GoogleLoginProvider('663678654421-v7k61u0sie7jql2bt3co7ebm8savo688.apps.googleusercontent.com'//,{ //  ux_mode: 'redirect' }
      //         )
      //     }
      //   ],
      //     onError: (err) => {
      //     console.error(err);
      //   }
      // } as SocialAuthServiceConfig
    }
  }
,
     provideClientHydration(),
     importProvidersFrom(
    // NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
      //  ToastrModule.forRoot({
      //   timeOut: 3000,
      //   positionClass: 'toast-bottom-right',
      //   preventDuplicates: true,
      // })
    ),
    provideAnimationsAsync()
    ]
};
