import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateShoplistComponent } from './create-shoplist.component';

describe('CreateShoplistComponent', () => {
  let component: CreateShoplistComponent;
  let fixture: ComponentFixture<CreateShoplistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateShoplistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateShoplistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
