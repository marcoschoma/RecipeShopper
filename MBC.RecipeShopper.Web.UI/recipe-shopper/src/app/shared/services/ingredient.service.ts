import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Ingredient } from '../models/ingredient.model';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  constructor(private httpClient: HttpClient) {
  }

  get(): Observable<Ingredient[]> {
    const url = `${environment.urlApi}/ingredient`;
    return this.httpClient.get<Ingredient[]>(url)
  }
}
