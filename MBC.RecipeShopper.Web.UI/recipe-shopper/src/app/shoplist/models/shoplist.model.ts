import { ShoplistIngredient } from './shoplist-ingredient.model'

export class Shoplist {
    id: number;
    creationDate: Date;
    ShoplistIngredients?: ShoplistIngredient[]
}
