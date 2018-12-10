import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RecipeComponent } from './recipe/recipe.component';
import { RecipeModule } from './recipe/recipe.module';
import { RecipeFormComponent } from './recipe/recipe-form/recipe-form.component';
import { ShoplistComponent } from './shoplist/shoplist.component';
import { ShoplistModule } from './shoplist/shoplist.module';
import { ShoplistFormComponent } from './shoplist/shoplist-form/shoplist-form.component';
import { IngredientComponent } from './shared/ingredient/ingredient.component';
import { SharedModule } from './shared/shared.module';
import { IngredientFormComponent } from './shared/ingredient/ingredient-form/ingredient-form.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'recipe', component: RecipeComponent },
  { path: 'create-recipe', component: RecipeFormComponent },
  { path: 'shoplist', component: ShoplistComponent },
  { path: 'create-shoplist', component: ShoplistFormComponent },
  { path: 'ingredient', component: IngredientComponent },
  { path: 'create-ingredient', component: IngredientFormComponent },
  { path: 'edit-ingredient/:id', component: IngredientFormComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    RecipeModule,
    ShoplistModule,
    SharedModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
