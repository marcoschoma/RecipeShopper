import { Component, Input, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';
import { RecipeIngredient } from 'src/app/dbo/models/recipe-ingredient';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-recipe-ingredient',
  templateUrl: './recipe-ingredient.component.html',
  styleUrls: ['./recipe-ingredient.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RecipeIngredientComponent {

  @Input('group') public recipeIngredient: FormGroup
  @Input() index: number
  @Output() deleteRecipe: EventEmitter<number> = new EventEmitter()

  constructor() {
    
  }

  delete() {
    this.deleteRecipe.emit(this.index)
  }
}
