import { FormArray, FormControl } from '@angular/forms'
import { Recipe } from './recipe.model';

export class RecipeForm {
    name = new FormControl();
    steps = new FormControl();
    recipeIngredients? = new FormArray([])

    constructor(recipe: Recipe) {
        if (recipe.name) {
            this.name.setValue(recipe.name)
        }
        if (recipe.steps) {
            this.steps.setValue(recipe.steps)
        }
        if (recipe.recipeIngredients) {
            this.recipeIngredients.setValue(recipe.recipeIngredients)
        }
    }
}