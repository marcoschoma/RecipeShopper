import { RecipeIngredient } from "../recipe-ingredient/models/recipe-ingredient.model";

export class Recipe {
    id: number;
    name: string;
    steps: string;
    recipeIngredients?: RecipeIngredient[]
}