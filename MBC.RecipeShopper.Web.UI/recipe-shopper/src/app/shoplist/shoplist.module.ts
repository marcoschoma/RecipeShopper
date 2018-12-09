import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShoplistComponent } from './shoplist.component';
import { ShoplistFormComponent } from './shoplist-form/shoplist-form.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ShoplistComponent, ShoplistFormComponent],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class ShoplistModule { }
