import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Recipe } from '../models/recipe.model';
import { HttpClient } from '@angular/common/http';
import { RecipeForm } from '../models/recipe-form.model';
import { NotificationResult } from 'src/app/shared/models/notification-result';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor(private httpClient: HttpClient) {
  }

  delete(id): Observable<NotificationResult> {
    const url = `${environment.urlApi}/recipe/${id}`;
    return this.httpClient.delete<NotificationResult>(url)
  }

  get(): Observable<Recipe[]> {
    const url = `${environment.urlApi}/recipe`;
    return this.httpClient.get<Recipe[]>(url)
  }

  save(recipe: RecipeForm): Observable<NotificationResult> {
    const url = `${environment.urlApi}/recipe`;
    return this.httpClient.post<NotificationResult>(url, recipe)
  }
}
