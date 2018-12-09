import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HelperService } from 'src/app/shared/services/helper.service';
import { SettingsService } from 'src/app/shared/services/settings.service';
import { BaseService } from 'src/app/shared/services/base.service';
import { RecipeIngredient } from '../../models/recipe-ingredient';
import { environment } from 'src/environments/environment';
import { NotificationResult } from 'src/app/shared/models/notification-result';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipeIngredientService extends BaseService {
  
  constructor(private httpClient: HttpClient,
    helperService: HelperService,
    settingsService: SettingsService) {
    super(helperService, settingsService);
  }
  
  post(recipeIngredient: RecipeIngredient): Observable<NotificationResult> {
    const url = `${environment.urlApi}/recipeIngredient`
    return this.httpClient.post<NotificationResult>(url, recipeIngredient)
    //.catchError(err => this.handleError(err));
  }

}
