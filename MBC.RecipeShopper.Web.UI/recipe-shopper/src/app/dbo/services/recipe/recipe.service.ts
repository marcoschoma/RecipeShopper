import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NotificationResult } from 'src/app/shared/models/notification-result';
import { environment } from 'src/environments/environment';
import { BaseService } from 'src/app/shared/services/base.service';
import { HelperService } from 'src/app/shared/services/helper.service';
import { SettingsService } from 'src/app/shared/services/settings.service';
import { Recipe } from '../../models/recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService extends BaseService {

  constructor(
    private httpClient: HttpClient,
    helperService: HelperService,
    settingsService: SettingsService) {
    super(helperService, settingsService);
  }

  post(item: Recipe): Observable<NotificationResult> {
    const url = `${environment.urlApi}/dbo/recipe`;
    return this.httpClient.post<NotificationResult>(url, item)
    //.catchError(err => this.handleError(err));
  }

  put(id: number, item: Recipe): Observable<NotificationResult> {
    const url = `${this.urlApi}/dbo/recipe/${id}`;
    return this.httpClient.put<NotificationResult>(url, item)
    //.catchError(err => this.handleError(err));
  }

  getById(id: number): Observable<Recipe> {
    const url = `${this.urlApi}/dbo/recipe/${id}`;
    return this.httpClient.get<Recipe>(url, { headers: this.getAuthHeaders() })
    // .catch(err => super.handleError(err));
  }

  get(): Observable<Recipe[]> {
    const url = `${this.urlApi}/dbo/recipe`;
    return this.httpClient.get<Recipe[]>(url, { headers: this.getAuthHeaders() })
    // .catch(err => this.handleError(err));
  }
}
