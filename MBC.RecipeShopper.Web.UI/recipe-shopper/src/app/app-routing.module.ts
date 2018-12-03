import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './dbo/pages/home/home.component';
import { RecipeComponent } from './dbo/pages/recipe/recipe.component';
import { CreateRecipeComponent } from './dbo/pages/recipe/create-recipe/create-recipe.component';
import { ShoplistComponent } from './dbo/pages/shoplist/shoplist.component';
import { CreateShoplistComponent } from './dbo/pages/shoplist/create-shoplist/create-shoplist.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'recipe', component: RecipeComponent },
  { path: 'create-recipe', component: CreateRecipeComponent },
  { path: 'shoplist', component: ShoplistComponent },
  { path: 'create-shoplist', component: CreateShoplistComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
