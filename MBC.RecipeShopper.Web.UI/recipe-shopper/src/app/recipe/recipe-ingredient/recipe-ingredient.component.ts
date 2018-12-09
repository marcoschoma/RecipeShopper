import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Ingredient } from 'src/app/shared/models/ingredient.model';
import { AmountType } from 'src/app/shared/models/amount-type.model';

@Component({
  selector: 'recipe-recipeIngredient',
  templateUrl: './recipe-ingredient.component.html',
  styleUrls: ['./recipe-ingredient.component.css']
})
export class RecipeIngredientComponent implements OnInit {

  @Input() recipeIngredientForm: FormGroup
  @Input() index: number
  @Output() deleteRecipeIngredient: EventEmitter<number> = new EventEmitter()
  
  @Input() ingredients: Ingredient[]
  @Input() amountTypes: AmountType[]
  constructor() {
  }

  ngOnInit() {}

  delete() {
    this.deleteRecipeIngredient.emit(this.index)
  }


}
