import { Component, OnInit } from '@angular/core';
import { ShoplistService } from './services/shoplist.service';
import { Shoplist } from './models/shoplist.model';

@Component({
  selector: 'app-shoplist',
  templateUrl: './shoplist.component.html',
  styleUrls: ['./shoplist.component.css']
})
export class ShoplistComponent implements OnInit {

  shoplists: Shoplist[]
  constructor(private shoplist: ShoplistService) { }

  ngOnInit() {
    this.shoplist.get().subscribe(shoplists =>
      this.shoplists = shoplists)
  }

}
