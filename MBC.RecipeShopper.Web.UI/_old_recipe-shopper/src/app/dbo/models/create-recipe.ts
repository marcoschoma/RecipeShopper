import { RecipeIngredient } from './recipe-ingredient'
import { FormControl, FormArray } from '@angular/forms';
import { Recipe } from './recipe';

export class CreateRecipe {
    name = new FormControl()
    recipeIngredients = new FormArray([])

    constructor(recipe: Recipe) {
        this.name.setValue(recipe.name)
        this.recipeIngredients.setValue([this.recipeIngredients])
    }
}
