import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HelperService } from 'src/app/shared/services/helper.service';
import { BaseService } from 'src/app/shared/services/base.service';
import { SettingsService } from 'src/app/shared/services/settings.service';
import { AmountType } from '../../models/amount-type';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AmountTypeService extends BaseService {

  constructor(private httpClient: HttpClient,
    helperService: HelperService,
    settingsService: SettingsService) {
    super(helperService, settingsService);
  }

  get(): Observable<AmountType[]> {
    const url = `${this.urlApi}/amounttype`;
    return this.httpClient.get<AmountType[]>(url)
    //  .catchError(err => this.handleError(err));
  }
}
