import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/shared/services/base.service';
import { HelperService } from 'src/app/shared/services/helper.service';
import { SettingsService } from 'src/app/shared/services/settings.service';
import { Observable } from 'rxjs';
import { Ingredient } from '../../models/ingredient';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class IngredientService extends BaseService {

  constructor(private httpClient: HttpClient,
    helperService: HelperService,
    settingsService: SettingsService) {
    super(helperService, settingsService);
  }

  get(): Observable<Ingredient[]> {
    const url = `${this.urlApi}/ingredient`;
    return this.httpClient.get<Ingredient[]>(url)
    //  .catchError(err => this.handleError(err));
  }
}
