import { RecipeIngredient } from './recipe-ingredient'

export interface Recipe {
    id: number;
    name: string;
    steps: string;
    RecipeIngredients?: RecipeIngredient[]
}
