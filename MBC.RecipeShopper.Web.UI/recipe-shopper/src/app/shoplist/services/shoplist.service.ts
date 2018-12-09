import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NotificationResult } from 'src/app/shared/models/notification-result';
import { environment } from 'src/environments/environment';
import { Shoplist } from '../models/shoplist.model';

@Injectable({
  providedIn: 'root'
})
export class ShoplistService {

  constructor(
    private httpClient: HttpClient) {
  }

  post(item: Shoplist): Observable<NotificationResult> {
    const url = `${environment.urlApi}/shoplist`;
    return this.httpClient.post<NotificationResult>(url, item)
  }

  put(id: number, item: Shoplist): Observable<NotificationResult> {
    const url = `${environment.urlApi}/shoplist/${id}`;
    return this.httpClient.put<NotificationResult>(url, item)
  }

  getById(id: number): Observable<Shoplist> {
    const url = `${environment.urlApi}/shoplist/${id}`;
    return this.httpClient.get<Shoplist>(url)
  }

  get(): Observable<Shoplist[]> {
    const url = `${environment.urlApi}/shoplist`;
    return this.httpClient.get<Shoplist[]>(url)
  }

  createFromRecipeIdList(ids: number[]): Observable<NotificationResult> {
    const url = `${environment.urlApi}/createShoplistFromRecipes`;
    return this.httpClient.post<NotificationResult>(url, ids)
  }
}
