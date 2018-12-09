import { ShoplistIngredient } from './shoplist-ingredient'

export interface Shoplist {
    id: number;
    creationDate: Date;
    ShoplistIngredients?: ShoplistIngredient[]
}
