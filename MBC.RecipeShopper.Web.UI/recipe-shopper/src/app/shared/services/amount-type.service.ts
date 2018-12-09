import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AmountType } from '../models/amount-type.model';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AmountTypeService {

  constructor(private httpClient: HttpClient) { }

  get(): Observable<AmountType[]> {
    const url = `${environment.urlApi}/amounttype`;
    return this.httpClient.get<AmountType[]>(url)
  }
}
