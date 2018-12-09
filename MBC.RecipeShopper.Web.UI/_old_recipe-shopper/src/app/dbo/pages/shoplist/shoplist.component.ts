import { Component, OnInit } from '@angular/core';
import { ShoplistService } from '../../services/shoplist/shoplist.service';
import { HelperService } from 'src/app/shared/services/helper.service';
import { Shoplist } from '../../models/shoplist';
import { ShoplistIngredient } from '../../models/shoplist-ingredient';

@Component({
  selector: 'app-shoplist',
  templateUrl: './shoplist.component.html',
  styleUrls: ['./shoplist.component.css']
})
export class ShoplistComponent implements OnInit {
  items: Shoplist[] = []
  shoplist: Shoplist
  constructor(
    private shoplistService: ShoplistService,
    private helperService: HelperService
  ) { }

  ngOnInit() {
    this.shoplistService.get().subscribe(data => {
      this.items = data
    })
  }
  details(id: number) {
    this.shoplistService.getById(id).subscribe(data => {
      this.shoplist = data
      console.log(this.shoplist);
    })
  }
}
