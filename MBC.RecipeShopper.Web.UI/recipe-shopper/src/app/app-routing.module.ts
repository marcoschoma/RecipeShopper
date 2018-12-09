import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RecipeComponent } from './recipe/recipe.component';
import { RecipeModule } from './recipe/recipe.module';
import { RecipeFormComponent } from './recipe/recipe-form/recipe-form.component';
import { ShoplistComponent } from './shoplist/shoplist.component';
import { ShoplistModule } from './shoplist/shoplist.module';
import { ShoplistFormComponent } from './shoplist/shoplist-form/shoplist-form.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'recipe', component: RecipeComponent },
  { path: 'create-recipe', component: RecipeFormComponent },
  { path: 'shoplist', component: ShoplistComponent },
  { path: 'create-shoplist', component: ShoplistFormComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    RecipeModule,
    ShoplistModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
