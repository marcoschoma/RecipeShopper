import { Component, OnInit, Input } from '@angular/core';
import { RecipeIngredient } from 'src/app/dbo/models/recipe-ingredient';
import { IngredientService } from 'src/app/dbo/services/ingredient/ingredient.service';
import { AmountTypeService } from 'src/app/dbo/services/amount-type/amount-type.service';
import { RecipeIngredientService } from 'src/app/dbo/services/recipe-ingredient/recipe-ingredient.service';
import { AmountType } from 'src/app/dbo/models/amount-type';
import { Ingredient } from 'src/app/dbo/models/ingredient';
import { RecipeService } from 'src/app/dbo/services/recipe/recipe.service';
import { Recipe } from 'src/app/dbo/models/recipe';

// import { MatExpansionModule } from '@angular/material/expansion';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent implements OnInit {

  constructor(
    private recipeService: RecipeService,
    private ingredientService: IngredientService,
    private amountTypeService: AmountTypeService,
    private recipeIngredientService: RecipeIngredientService) {
  }
  @Input() model: Recipe = {} as Recipe
  ingredientsAdded: RecipeIngredient[] = []
  ingredients: Ingredient[] = []
  amountTypes: AmountType[] = []

  ngOnInit() {
    this.ingredientService.get().subscribe(data => {
      this.ingredients = data;
    })
    this.amountTypeService.get().subscribe(data => {
      this.amountTypes = data;
    })
  }

  save() {
    this.recipeService.post(this.model)
    this.ingredientsAdded.forEach(ingredient => {
      this.recipeIngredientService.post(ingredient);
    });
  }

}
