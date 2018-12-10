import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Ingredient } from '../models/ingredient.model';
import { NotificationResult } from '../models/notification-result';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {
  post(ingredient: Ingredient): Observable<NotificationResult> {
    const url = `${environment.urlApi}/ingredient`;
    return this.httpClient.post<NotificationResult>(url, ingredient)
  }
  put(ingredientId: number, ingredient: Ingredient): Observable<NotificationResult> {
    const url = `${environment.urlApi}/ingredient/${ingredientId}`;
    return this.httpClient.put<NotificationResult>(url, ingredient)
  }
  getById(ingredientId: number): Observable<Ingredient> {
    const url = `${environment.urlApi}/ingredient/${ingredientId}`;
    return this.httpClient.get<Ingredient>(url)
  }

  constructor(private httpClient: HttpClient) {
  }

  get(): Observable<Ingredient[]> {
    const url = `${environment.urlApi}/ingredient`;
    return this.httpClient.get<Ingredient[]>(url)
  }
  remove(id): Observable<NotificationResult> {
    const url = `${environment.urlApi}/ingredient/${id}`;
    return this.httpClient.delete<NotificationResult>(url)
  }
}
