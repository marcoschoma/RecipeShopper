import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoplistFormComponent } from './shoplist-form.component';

describe('ShoplistFormComponent', () => {
  let component: ShoplistFormComponent;
  let fixture: ComponentFixture<ShoplistFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShoplistFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShoplistFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
