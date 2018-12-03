import { Injectable } from '@angular/core';
import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { environment } from './../../../environments/environment';
import { HelperService } from './helper.service';
import { ErrorObservable } from 'rxjs-compat/Observable/ErrorObservable'
import { SettingsService } from './settings.service';

@Injectable()
export class BaseService {

  public urlApi = environment.urlApi;
    
  constructor(
    private helperService: HelperService,
    private settingsService: SettingsService) { }

  protected getHeaders(apiVersion = '1.0'): HttpHeaders {
    const headers = new HttpHeaders()
      .set('Accept', 'application/json')
      .set('Accept-Language', this.settingsService.locale)
      .set('x-api-version', apiVersion);
    return headers;
  }

  public handleError(error): ErrorObservable<any> {
    this.helperService.message.errorMessage(error.message);
    throw error;
  }

  //AQ
  public handleErrorCustomHttp(error, status, message: string): ErrorObservable<any> {
    if (error instanceof HttpErrorResponse) {
      if (error.status == status) {
        this.helperService.message.errorMessage(message);
      }
      else {
        this.helperService.message.errorMessage(error.message);  
      }
    }
    else {
      this.helperService.message.errorMessage(error.message);
    }
    throw error;
  }



}
