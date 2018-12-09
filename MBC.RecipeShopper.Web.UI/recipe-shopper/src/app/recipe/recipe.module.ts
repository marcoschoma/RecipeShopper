import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { RecipeIngredientComponent } from './recipe-ingredient/recipe-ingredient.component';
import { RecipeFormComponent } from './recipe-form/recipe-form.component';
import { RecipeComponent } from './recipe.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { NgxMaskModule } from 'ngx-mask'
import { HttpClientModule } from '@angular/common/http'

@NgModule({
  declarations: [ListComponent, RecipeComponent, RecipeIngredientComponent, RecipeFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
    HttpClientModule
  ]
})
export class RecipeModule { }
