import { Component, OnInit } from '@angular/core';
import { IngredientService } from '../services/ingredient.service';
import { Ingredient } from '../models/ingredient.model';

@Component({
  selector: 'app-ingredient',
  templateUrl: './ingredient.component.html',
  styleUrls: ['./ingredient.component.css']
})
export class IngredientComponent implements OnInit {

  ingredients: Ingredient[]
  constructor(private ingredientService: IngredientService) { }

  ngOnInit() {
    this.load()
  }
  load() {
    this.ingredientService.get().subscribe(result => {
      this.ingredients = result
    })
  }
  remove(id) {
    this.ingredientService.remove(id).subscribe(result => {
      this.load()
    })
  }
}
