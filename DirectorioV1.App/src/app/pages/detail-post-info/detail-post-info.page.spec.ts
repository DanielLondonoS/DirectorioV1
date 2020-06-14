import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { DetailPostInfoPage } from './detail-post-info.page';

describe('DetailPostInfoPage', () => {
  let component: DetailPostInfoPage;
  let fixture: ComponentFixture<DetailPostInfoPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailPostInfoPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(DetailPostInfoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
