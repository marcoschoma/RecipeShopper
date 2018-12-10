import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IngredientComponent } from './ingredient/ingredient.component';
import { IngredientFormComponent } from './ingredient/ingredient-form/ingredient-form.component';
import { IngredientGridComponent } from './ingredient/ingredient-grid/ingredient-grid.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'

@NgModule({
  declarations: [IngredientComponent, IngredientFormComponent, IngredientGridComponent],
  imports: [
    CommonModule,
    FormsModule, ReactiveFormsModule
  ]
})
export class SharedModule { }
