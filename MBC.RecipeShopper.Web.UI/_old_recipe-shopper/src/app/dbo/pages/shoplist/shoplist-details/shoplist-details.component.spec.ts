import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoplistDetailsComponent } from './shoplist-details.component';

describe('ShoplistDetailsComponent', () => {
  let component: ShoplistDetailsComponent;
  let fixture: ComponentFixture<ShoplistDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShoplistDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShoplistDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
