import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NotificationResult } from 'src/app/shared/models/notification-result';
import { environment } from 'src/environments/environment';
import { BaseService } from 'src/app/shared/services/base.service';
import { HelperService } from 'src/app/shared/services/helper.service';
import { SettingsService } from 'src/app/shared/services/settings.service';
import { Shoplist } from '../../models/shoplist';

@Injectable({
  providedIn: 'root'
})
export class ShoplistService extends BaseService {

  constructor(
    private httpClient: HttpClient,
    helperService: HelperService,
    settingsService: SettingsService) {
    super(helperService, settingsService);
  }

  post(item: Shoplist): Observable<NotificationResult> {
    const url = `${environment.urlApi}/shoplist`;
    return this.httpClient.post<NotificationResult>(url, item)
      //.catchError(err => this.handleError(err));
  }

  put(id: number, item: Shoplist): Observable<NotificationResult> {
    const url = `${this.urlApi}/shoplist/${id}`;
    return this.httpClient.put<NotificationResult>(url, item)
      //.catchError(err => this.handleError(err));
  }

  getById(id: number): Observable<Shoplist> {
    const url = `${this.urlApi}/shoplist/${id}`;
    return this.httpClient.get<Shoplist>(url)
      // .catch(err => super.handleError(err));
  }

  get(): Observable<Shoplist[]> {
    const url = `${this.urlApi}/shoplist`;
    return this.httpClient.get<Shoplist[]>(url)
      // .catch(err => this.handleError(err));
  }
}
