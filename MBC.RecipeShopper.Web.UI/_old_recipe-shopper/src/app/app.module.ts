import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastaModule } from 'ngx-toasta';
import { NgxMaskModule } from 'ngx-mask'
import { AppRoutingModule } from './app-routing.module';

import { HelperService } from './shared/services/helper.service';
import { SettingsService } from './shared/services/settings.service';

import { AppComponent } from './app.component';
import { RecipeComponent } from './dbo/pages/recipe/recipe.component';
import { HomeComponent } from './dbo/pages/home/home.component';
import { MenuComponent } from './shared/pages/menu/menu.component';
import { ShoplistComponent } from './dbo/pages/shoplist/shoplist.component';
import { CreateRecipeComponent } from './dbo/pages/recipe/create-recipe/create-recipe.component';

import { RecipeIngredientService } from './dbo/services/recipe-ingredient/recipe-ingredient.service';
import { CreateShoplistComponent } from './dbo/pages/shoplist/create-shoplist/create-shoplist.component';
import { DescribeIngredients } from './dbo/pages/shoplist/describe-ingredients-pipe';
import { ShoplistDetailsComponent } from './dbo/pages/shoplist/shoplist-details/shoplist-details.component';
// import { AmountTypeService } from './dbo/services/amount-type/amount-type.service';
//import { IngredientService } from './dbo/services/ingredient/ingredient.service';
import { ModalModule } from 'ngx-bootstrap/modal';
import { RecipeIngredientComponent } from './dbo/pages/recipe/recipe-ingredient/recipe-ingredient.component';


@NgModule({
  declarations: [
    AppComponent,
    CreateRecipeComponent,
    RecipeComponent,
    HomeComponent,
    MenuComponent,
    ShoplistComponent,
    CreateShoplistComponent,
    DescribeIngredients,
    ShoplistDetailsComponent,
    RecipeIngredientComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastaModule.forRoot(),
    NgxMaskModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [
    HelperService,
    SettingsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
